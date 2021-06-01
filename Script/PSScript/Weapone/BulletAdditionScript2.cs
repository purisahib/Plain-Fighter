using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletAdditionScript2 : MonoBehaviour
{
    public float PlaySpeed;
  
    void Update()
    {
        //transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        gameObject.transform.localPosition += -Vector3.right * PlaySpeed * Time.deltaTime;
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("End"))
        {
            Destroy(gameObject);
        }
    }
}
