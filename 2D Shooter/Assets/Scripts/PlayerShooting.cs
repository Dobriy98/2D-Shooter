using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    private float interval = 1f;
    private float intervalTimer = 0f;
    [SerializeField] private GameObject bullet;
    void Update()
    {
        if(Input.GetMouseButton(0)){
            intervalTimer -= Time.deltaTime;
            if(intervalTimer <= 0){
                Vector2 bulletPosition = new Vector2(transform.position.x,transform.position.y);
                GameObject bulletClone = Instantiate(bullet, bulletPosition, transform.rotation);
                Destroy(bulletClone, 2f);
                intervalTimer = interval;
            }
        }
    }
}
