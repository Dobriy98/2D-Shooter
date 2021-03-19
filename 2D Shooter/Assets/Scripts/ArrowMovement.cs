using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowMovement : MonoBehaviour
{
    [SerializeField] private ArcherEnemy archerEnemyScript;
    public float archerDamage;

    private Rigidbody2D arrowRB;

    private GameObject player;
    private Player playerScript;

    private float speed = 1f;
    void Start()
    {
        player = GameObject.Find("Player");
        if (player !=null)
        {
            playerScript = player.GetComponent<Player>();
        }

        arrowRB = GetComponent<Rigidbody2D>();
        Vector2 direction = player.transform.position - transform.position;
        arrowRB.AddForce(direction * speed, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.collider.tag == "Player")
        {
            playerScript.TakeDamage(archerDamage);
            Destroy(this.gameObject);
        }
    }
}
