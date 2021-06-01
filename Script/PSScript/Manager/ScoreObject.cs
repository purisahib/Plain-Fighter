using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreObject : MonoBehaviour
{
    //Speed
    public float Speed;

    void Update()
    {
        gameObject.transform.localPosition += -Vector3.right * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player"))
        {
            //Score
            GameManager2.Score += 1;
            Destroy(gameObject);
        }
        else if (other.CompareTag("End"))
        {
            Destroy(gameObject);
        }
    }
}
