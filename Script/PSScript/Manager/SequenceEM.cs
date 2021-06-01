using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceEM : MonoBehaviour
{
    private float timeBtwShoot;
    public float startTimeBtwShoot = 5;
    public GameObject[] Objects;

    void Update()
    {
        if (timeBtwShoot <= 0)
        {
            Instantiate(PickRandomFromList(), transform.position, Quaternion.identity); 
            timeBtwShoot = startTimeBtwShoot;
           
        } else {
            timeBtwShoot -= Time.deltaTime;
        }
        
    }
   private GameObject PickRandomFromList()
   {
       GameObject Object = Objects[Random.Range(0, Objects.Length)];      
       return Object;
   }
}
