using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class manager : MonoBehaviour
{
    public static manager ins;
    public GameObject[] pathObjects;
    public Vector3[] pathPositions;
    public player[] player;
    public int currentPlayer;
    public float playerSpeed = 1f;
    public bool playerMoving = false;

    private void Awake()
    {
        if (ins != null) Destroy(this.gameObject);
        else
        {
            ins = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    public void Start()
    {
        currentPlayer = 0;
        pathPositions = new Vector3[pathObjects.Length];
        for(int i = 0; i < pathObjects.Length; ++i)
        {
            pathPositions[i] = pathObjects[i].transform.position;
            pathObjects[i].SetActive(false);
        }
    }
    
    public void moveNextPlayer(int steps)
    {
        player[currentPlayer].moveSteps(steps);
    }
    
    public void spinDieAndMoveNextPlayer()
    {
        if (playerMoving)
        {
            Debug.Log("Player still moving...");
            return;
        }
        int steps = Random.Range(1, 8);
        Debug.Log(steps);
        moveNextPlayer(steps);
        currentPlayer = (currentPlayer + 1) % player.Length;
        Debug.Log("Finished");
    }
}
