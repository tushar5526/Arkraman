using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FightSceneManager : MonoBehaviour
{
    public Animator player, enemy;
    public ParticleSystem[] fxPlayer;
    public ParticleSystem[] fxEnemy;
    public ParticleSystem death;

    public void playPlayerfx()
    {
        foreach (ParticleSystem p in fxPlayer)
            p.gameObject.SetActive(true);
        foreach (ParticleSystem p in fxEnemy)
            p.gameObject.SetActive(true);
    }

    public void attack1()
    {
        player.SetTrigger("attack1");
        playPlayerfx();
    }
    public void attack2()
    {
        player.SetTrigger("attack2");
        playPlayerfx();
    }
    public void attack3()
    {
        player.SetTrigger("attack3");
        playPlayerfx();
    }

    public void death1()
    {
        enemy.SetTrigger("death1");
        playPlayerfx();
        death.Play();
    }
    public void death2()
    {
        enemy.SetTrigger("death2");
        playPlayerfx();
        death.Play();
    }
}
