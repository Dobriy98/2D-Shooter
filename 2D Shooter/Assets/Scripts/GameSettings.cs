using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    static GameSettings instance;
    public float playerHealth;
    public float playerDamage;
    public float enemyHealth;
    public float enemySpeed;
    public float enemyDamage;
    public float spawnFrequency;

    public static GameSettings GetInstance()
    {
        return instance;
    }
    void Start()
    {
        SetDelaultValues();
        #region Singleton
        if (instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        instance = this;
        #endregion

        DontDestroyOnLoad(this.gameObject);
    }

    public void SetPlayerHealth(string valueString)
    {
        int defaultValue = 10;
        int parseInt;
        if (int.TryParse(valueString, out parseInt))
        {
            playerHealth = parseInt;
        }
        else
        {
            playerHealth = defaultValue;
        }
    }

    public void SetPlayerDamage(string valueString)
    {
        int defaultValue = 10;
        int parseInt;
        if (int.TryParse(valueString, out parseInt))
        {
            playerDamage = parseInt;
        }
        else
        {
            playerDamage = defaultValue;
        }
    }

    public void SetEnemyHealth(string valueString)
    {
        int defaultValue = 10;
        int parseInt;
        if (int.TryParse(valueString, out parseInt))
        {
            enemyHealth = parseInt;
        }
        else
        {
            enemyHealth = defaultValue;
        }
    }

    public void SetEnemyDamage(string valueString)
    {
        int defaultValue = 10;
        int parseInt;
        if (int.TryParse(valueString, out parseInt))
        {
            enemyDamage = parseInt;
        }
        else
        {
            enemyDamage = defaultValue;
        }
    }

    public void SetEnemySpeed(string valueString)
    {
        int defaultValue = 10;
        int parseInt;
        if (int.TryParse(valueString, out parseInt))
        {
            enemySpeed = parseInt;
        }
        else
        {
            enemySpeed = defaultValue;
        }
    }

    public void SetSpawnFrequency(string valueString)
    {
        int defaultValue = 10;
        int parseInt;
        if (int.TryParse(valueString, out parseInt))
        {
            spawnFrequency = parseInt;
        }
        else
        {
            spawnFrequency = defaultValue;
        }
    }

    private void SetDelaultValues(){
        playerHealth = 10;
        playerDamage = 2;
        enemyDamage = 2;
        enemyHealth = 6;
        enemySpeed = 10;
        spawnFrequency = 7;
    }
}
