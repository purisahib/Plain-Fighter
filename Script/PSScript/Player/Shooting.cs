using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{
    public AudioHandeler audioHandeler;
    
    // Tipical Script
    public Transform firePoint;
    public Transform firePoint1;
    public Transform firePoint11;
    public GameObject bulletPrefab;
    public GameObject bulletPrefab1;
    public float bulletForce = 20f;
    
    // bullet power
    //public int AddBullet = 5;
    private int TotalBullet;
    public Slider TotalBulletSlider;

    // Constractor
    public void Awake()
    {
        TotalBullet = 100;
        TotalBulletSlider.value = TotalBullet;
    }

    public void UpDateValue()
    {
        TotalBullet = 100;
        TotalBulletSlider.value = TotalBullet;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("AddBullet") && TotalBullet <= 90)
        {
            AudioManager.Instance.PlaySFX(audioHandeler.musicCollect);
            TotalBullet += 10;
            TotalBulletSlider.value = TotalBullet;
            Destroy(other.gameObject);
        }
        else if (other.CompareTag("AddBullet") && TotalBullet >= 91)
        {
            AudioManager.Instance.PlaySFX(audioHandeler.musicCollect);
            TotalBullet = 100;
            TotalBulletSlider.value = TotalBullet;
            //Debug.Log("Bulled is full");
            Destroy(other.gameObject);
        }
    }

    public void Shoot()
    {
        if (TotalBullet <= 100 && TotalBullet >=1)
        {
            AudioManager.Instance.PlaySFX(audioHandeler.musicFire);
            TotalBullet -= 5;
            TotalBulletSlider.value = TotalBullet;
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse); 
        }
        
    }
    public void ShootFire()
    {
        if (TotalBullet <= 100 && TotalBullet >=1)
        {
            AudioManager.Instance.PlaySFX(audioHandeler.musicFire);
            TotalBullet -= 10;
            TotalBulletSlider.value = TotalBullet;
            GameObject bullet1 = Instantiate(bulletPrefab1, firePoint1.position, firePoint1.rotation);
            GameObject bullet11 = Instantiate(bulletPrefab1, firePoint11.position, firePoint11.rotation);
            Rigidbody2D rb1 = bullet1.GetComponent<Rigidbody2D>();
            Rigidbody2D rb11 = bullet11.GetComponent<Rigidbody2D>();
            rb1.AddForce(firePoint1.up * (bulletForce / 2f), ForceMode2D.Impulse); 
            rb11.AddForce(firePoint11.up * bulletForce, ForceMode2D.Impulse); 
        }
    }
}
