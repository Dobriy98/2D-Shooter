using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Enemy : MonoBehaviour
{
    [SerializeField] private HealthBar healthBar;
    private Text scoreValue;
    protected float health;
    protected float startHealth;
    protected float damage;
    protected float speed;
    protected float radiusToAttack;

    private bool canAttack = false;
    private bool hasInteract = false;
    private bool canMove = true;

    private float secondsToAttack = 2;
    private float interval = 0;

    private int points = 1;

    protected GameObject player;
    private Player playerScript;

    private void Awake()
    {
        health = GameSettings.GetInstance().enemyHealth;
        damage = GameSettings.GetInstance().enemyDamage;
        startHealth = GameSettings.GetInstance().enemyHealth;
        speed = GameSettings.GetInstance().enemySpeed;

        player = GameObject.Find("Player");
        if (player != null)
        {
            playerScript = player.GetComponent<Player>();
        }

        scoreValue = GameObject.Find("ScoreValue").GetComponent<Text>();
    }

    private void Update()
    {
        if (!hasInteract && player != null)
        {
            float distance = Vector3.Distance(player.transform.position, transform.position);
            if (distance <= radiusToAttack)
            {
                canMove = false;
                canAttack = true;
                hasInteract = true;
            }
        }
        if (canAttack)
        {
            interval -= Time.deltaTime;
            if (interval <= 0)
            {
                Attack();
                interval = secondsToAttack;
            }
        }
        if (canMove)
        {
            Move();
        }
    }

    public void Move()
    {
        if (player != null)
        {
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, step);
        }
    }

    public void TakeDamage(float damageTaken)
    {
        if (healthBar != null)
        {
            float damageToReduceHB = damageTaken / startHealth;
            healthBar.ReduceHealthBar(damageToReduceHB);

            health -= damageTaken;
            if (health <= 0)
            {
                Die();
            }
        }
    }

    public virtual void Attack()
    {
        playerScript.TakeDamage(damage);
    }

    private void Die()
    {
        if (scoreValue != null)
        {
            int scoreInt = Int32.Parse(scoreValue.text);
            scoreInt += points;
            scoreValue.text = scoreInt.ToString();
        }
        Destroy(this.gameObject);
    }
}
