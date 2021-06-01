using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayEnemy : MonoBehaviour
{

    // Enemy Asset
    public float PlayEnemySpeed;
    public GameObject hitEffect;

    //public int Damage Score
    public int DamageScore = 1;
    public int EnemyPower = 1;
    
  
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        gameObject.transform.localPosition += -Vector3.up * PlayEnemySpeed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("PlayerBullet"))
        {
            if (EnemyPower == 1)
            {
                
            }
            AudioManager.Instance.PlaySFX();
            PlainFighterPlayer.Score += DamageScore;
            GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.1f);
            Destroy(gameObject);   
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("End"))
        {
            Destroy(gameObject);
        }
    }
}
