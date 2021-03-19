using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcherEnemy : Enemy
{
    [SerializeField] private GameObject arrow;
    
    private float archerSpeedFactor = 0.05f;
    private float archerHealthFactor = 1f;
    private float archerDamageFactor = 0.5f;

    public float finalDamage;
    private void Start()
    {
        speed *= archerSpeedFactor;

        health *= archerHealthFactor;
        startHealth = health;

        damage *= archerDamageFactor;
        finalDamage = damage;

        radiusToAttack = 2f;
    }

    public override void Attack()
    {
        GameObject arrowClone = Instantiate(arrow, transform.position, Quaternion.identity);
        arrowClone.GetComponent<ArrowMovement>().archerDamage = damage;
    }

}
