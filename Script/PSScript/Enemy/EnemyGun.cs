using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    private float timeBtwShoot;
    public float startTimeBtwShoot;
    public float bulletForce = 20f;

    /*private void Start()
    {
        StartCoroutine("Countdown");
    }
    IEnumerator Countdown()
    {
        for (int i = 1; i >= 5; i++)
        {
            UpdateShoot();
        }
            yield return new WaitForSeconds(1f);
            //for (int i = 1; i >= 5; i++)
            //{
                //UpdateShoot();
            //}
        //}        
    }*/
    private void Update() {
        if (timeBtwShoot <= 0)
        {
            //Shoot();
            StartFire();
            timeBtwShoot = startTimeBtwShoot;
        } else {
            timeBtwShoot -= Time.deltaTime;
        }
    }
    public int increaseNu = 1;
    private void StartFire()
    {
        
        if (increaseNu > 0 && increaseNu <= 5)
        {
            Shoot();
            increaseNu++;
        }  
        if (increaseNu > 5 && increaseNu < 10)
        {
            increaseNu++;
        }     
        else if (increaseNu == 10)
        {
            increaseNu = 1;
        }   
    }
    private void Shoot()
    {
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); 
    }
    
}
