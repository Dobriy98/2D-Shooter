using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFootman : Enemy
{
    private float footmanSpeedFactor = 0.02f;
    private float footmanHealthFactor = 2;
    private float footmanDamageFactor = 1;
    private void Start() {
        speed *= footmanSpeedFactor;

        health *= footmanHealthFactor;
        startHealth = health;

        damage *= footmanDamageFactor;

        radiusToAttack = 0.7f;
    }
}
