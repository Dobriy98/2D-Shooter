using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private HealthBar healthBarScript;
    [SerializeField] private GameObject finalPanel;
    [SerializeField] private GameObject healthBar;
    [SerializeField] private Text scoreValue;
    [SerializeField] private Text scoreFinalValue;
    private float health;
    private float startHealth;
    public float damage;

    private void Start()
    {
        damage = GameSettings.GetInstance().playerDamage;
        health = GameSettings.GetInstance().playerHealth;
        startHealth = GameSettings.GetInstance().playerHealth;
    }

    public void TakeDamage(float damageTaken)
    {
        if (healthBarScript != null)
        {
            float damageToReduceHB = damageTaken / startHealth;
            healthBarScript.ReduceHealthBar(damageToReduceHB);

            health -= damageTaken;
            if (health <= 0)
            {
                Die();
            }
        }
    }

    private void Die()
    {
        finalPanel.SetActive(true);
        scoreFinalValue.text = scoreValue.text;
        Time.timeScale = 0;
        Destroy(healthBar);
        Destroy(this.gameObject);
    }
}
