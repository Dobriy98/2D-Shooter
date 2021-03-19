using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombEnemy : Enemy
{
    private float footmanSpeedFactor = 0.1f;
    private float footmanHealthFactor = 0.5f;
    private float footmanDamageFactor = 2;
    private void Start() {
        speed *= footmanSpeedFactor;

        health *= footmanHealthFactor;
        startHealth = health;

        damage *= footmanDamageFactor;

        radiusToAttack = 0.5f;
    }

    public override void Attack()
    {
        base.Attack();
        Destroy(this.gameObject);
    }
}
