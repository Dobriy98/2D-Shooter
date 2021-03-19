using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    private float speed = 10f;
    private Rigidbody2D bulletRB;
    
    private Player playerScript;
    private float playerDamage;
    private void Start() {
        bulletRB = GetComponent<Rigidbody2D>();

        Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mouseWorldPosition.x, mouseWorldPosition.y);
        bulletRB.velocity = direction.normalized * speed;

        playerScript = GameObject.Find("Player").GetComponent<Player>();
        playerDamage = playerScript.damage;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "enemy"){
            other.gameObject.GetComponent<Enemy>().TakeDamage(playerDamage);
            Destroy(this.gameObject);
        }
    }
}
