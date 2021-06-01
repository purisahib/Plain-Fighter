using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;
    public float moveSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start() {
        rb = this.GetComponent<Rigidbody2D>();
        //player = GameObject.FindGameObjectWithTag("Player").transform;

    }
    private void Update() {
        Vector3 direction = player.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        rb.rotation = angle;
        direction.Normalize();
        movement = direction;
    }
    private void FixedUpdate() {
        moveCharacter(movement);
    }
    private void moveCharacter(Vector2 direction){
        rb.MovePosition((Vector2)transform.position + (direction * moveSpeed * Time.deltaTime));
    }

    public GameObject hitEffect;
    /*private void OnCollisionEnter2D(Collision2D other) {
        Debug.Log(other.name);
        if (other.name == "Bullet")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 2f);
            Destroy(gameObject);
        }
        
    }*/
    private void OnTriggerEnter2D(Collider2D col) {
        Debug.Log(col.gameObject.name);
        if (col.gameObject.tag == "Bullet")
        {
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 2f);
            Destroy(gameObject);
        }
    }
}
