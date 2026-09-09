using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStates : MonoBehaviour//用于战斗系统的数值变化
{
    [Header("all Channel")]
    public HealthChannelOS healthChannelOS;

    [Header("Battale Data")]

    public EntityData myData;


    public int maxHeath;
    public int currentHeath;
    public int moveSpeed;
    public int attackPower;

    public bool isDead;



    private void Awake()
    {
        maxHeath = myData.maxHeath;
        currentHeath = maxHeath;
        moveSpeed = myData.moveSpeed;
        attackPower = myData.attackPower;
        isDead = false;
    }

    public void BeAttack(int Damage)
    {
        if (currentHeath <= 0) return;
        currentHeath -= Damage;
        //通知ui改变
        HealthChange();

        if (currentHeath <= 0)
        {
            currentHeath = 0;
            Die();
        }
    }


    public void Die()
    {
        if (isDead) { return; }
        isDead = true;

        GetComponent<Entity>()?.Die();
    }

    public void HealthChange()
    {
        healthChannelOS.EventRaise(this);
    }

}
