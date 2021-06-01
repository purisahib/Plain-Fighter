using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnteryManager : MonoBehaviour
{
    private float timeBtwShoot;
    public float startTimeBtwShoot;
    public GameObject[] Enemy;

    

    void Update()
    {
        if (timeBtwShoot <= 0)
        {
            Instantiate(PickRandomFromList(), transform.position, Quaternion.identity); 
            timeBtwShoot = PickRandom();
           
        } else {
            timeBtwShoot -= Time.deltaTime;
        }
        
    }
    private float PickRandom()
    {
        //float startTimeBtwShoot = 40f;
        float randomNum = Random.Range(20f, startTimeBtwShoot + 5f);
        return randomNum;
    }
   private GameObject PickRandomFromList()
   {
       GameObject EnemyObject = Enemy[Random.Range(0, Enemy.Length)];
       //string[] students = new string[] {"Harry", "Rhan", "Ram"};
       //string randomName = students[Random.Range(0, students.Length)]; 
       //largeText.text = randomName;
       return EnemyObject;
   }
}
