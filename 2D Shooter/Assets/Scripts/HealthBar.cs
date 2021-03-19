using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Transform healthBar;

    public void ReduceHealthBar(float size){
        healthBar.localScale -= new Vector3(size, 0);
    }
}
