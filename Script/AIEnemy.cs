using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIEnemy : MonoBehaviour
{
    public float speed;
    public float stoppingDistance;
    public float retreatDistance;

    private float timeBtwShoot;
    public float startTimeBtwShoot;

    public GameObject projectTile;
    private Transform player;

    public AudioSource EnemyDieAudio;
    public GameObject hitEffect;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBtwShoot = startTimeBtwShoot;
    }

    
    void Update()
    {
        if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        else if (Vector2.Distance(transform.position, player.position) < stoppingDistance && Vector2.Distance(transform.position, player.position) > retreatDistance)
        {
            transform.position = this.transform.position;
        }
        else if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -speed * Time.deltaTime);
        }


        if (timeBtwShoot <= 0)
        {
           Instantiate(projectTile, transform.position, Quaternion.identity); 
           timeBtwShoot = startTimeBtwShoot;
        } else {
            timeBtwShoot -= Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Bullet"))
        {
            //CalaulateGameManagerScore.Score += 1;
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            EnemyDieAudio.Play();
            Destroy(effect, 0.5f);
            Destroy(gameObject);   
        }
    }
}
