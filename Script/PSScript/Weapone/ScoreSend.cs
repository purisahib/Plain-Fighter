using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreSend : MonoBehaviour
{
    public float Speed;
    void Update()
    {
        gameObject.transform.localPosition += -Vector3.up * Speed * Time.deltaTime;
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("End"))
        {
            Destroy(gameObject);
        }
    }
}
