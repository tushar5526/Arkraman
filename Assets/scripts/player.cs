using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public int currentBlockId = 0;
    public Animator soldierAnimator;

    public void Start()
    {
        soldierAnimator = this.GetComponent<Animator>();
    }

    IEnumerator move(int steps)
    {
        if (steps == 0)
        {
            manager.ins.playerMoving = false;
            ToggleWalking();
            ToggleIdle();
            yield break;
        }

        Vector3 a = manager.ins.pathPositions[currentBlockId];
        int nextBlockId = (currentBlockId + 1) % manager.ins.pathObjects.Length;
        Vector3 b = manager.ins.pathPositions[nextBlockId];

        float speed = manager.ins.playerSpeed;
        float step = (speed / (a - b).magnitude) * Time.fixedDeltaTime;
        float t = 0;
        Quaternion currRotation = transform.localRotation;
        Vector3 relativePos = b - a;
        Quaternion finalRotation = Quaternion.LookRotation(relativePos);
        while (t <= 1.0f)
        {
            t += step;
            transform.localRotation = Quaternion.Lerp(currRotation, finalRotation, t*3);
            this.transform.localPosition = Vector3.Lerp(a, b, t);
            yield return new WaitForFixedUpdate();
        }
        this.transform.localPosition = b;
        this.transform.localRotation = finalRotation;
        currentBlockId = nextBlockId;
        StartCoroutine(move(steps - 1));
    }

    public void ToggleWalking()
    {
        soldierAnimator.SetBool("walking", !soldierAnimator.GetBool("walking"));
    }

    public void ToggleIdle()
    {
        soldierAnimator.SetBool("isIdle", !soldierAnimator.GetBool("isIdle"));
    }

    public void moveSteps(int steps)
    {
        manager.ins.playerMoving = true;
        ToggleIdle();
        ToggleWalking();
        StartCoroutine(move(steps));
    }
}
