using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projecttile : MonoBehaviour
{
    public float speed;

    public GameObject ply;
    private Vector2 target;

    void Start()
    {
        //player = GameObject.FindGameObjectWithTag("Player").transform;

        target = new Vector2(ply.transform.position.x, ply.transform.position.y);
    }

    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        //if (transform.position.x == target.x && transform.position.y == target.y)
        //{
            DestroyProjectile();
        //}   
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            DestroyProjectile();
            GameOver();
            
        }
        else{
            DestroyProjectile();
        }
    }
    public AudioSource BulletAudio;
    public GameObject hitEffect;
    void DestroyProjectile()
    {
        BulletAudio.Play();
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        Destroy(gameObject);
    }
    void GameOver(){}
}
