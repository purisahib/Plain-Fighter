using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player2 : MonoBehaviour
{
    public DynamicJoystick dynamicJoystick;
    public float Speed = 2f;
    float moveSpeedH;
    float moveSpeedV;
    public int PlayerHealth = 100;
    public Slider HealthSlider;
    public bool GameOver = false;

    // Efffect 
    public GameObject DamageEffect;
    public AudioHandeler audioHandeler;
    public SpriteRenderer render;    
    Rigidbody2D rb;
    public Vector3 transformPosition;
    //public Transform Target;
    //private Vector2 target;

    private void Start() {
        //dynamicJoystick = GetComponent<DynamicJoystick>();
        rb = gameObject.GetComponent<Rigidbody2D>();
        //render = GetComponent<SpriteRenderer>();
        
        
    }
    private void FixedUpdate() {
        
    }
    public void UpDateValue()
    {
        PlayerHealth = 100;
        HealthSlider.value = PlayerHealth;
        transform.position = transformPosition;
        moveSpeedH = 0f;
        moveSpeedV = 0f;
        //target = new Vector2(Target.position.x, Target.position.y);
        //transform.position = Vector2.MoveTowards(transform.position, target, 10f * Time.deltaTime);
        //transform.position = new Vector2(-6.3f, 0.7f);
    }
    private void Update() {
        movingFun();
    }
    private void movingFun()
    {
        moveSpeedH = dynamicJoystick.Horizontal * Speed;
        moveSpeedV = dynamicJoystick.Vertical * Speed;
        transform.position = new Vector2(Mathf.Clamp ( transform.position.x, -7.5f, 7.5f), transform.position.y);
        rb.velocity = new Vector2(moveSpeedH, moveSpeedV);
    }
    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Enemy") || other.CompareTag("End"))
        {
            PlayerHealth -= 5;
            HealthSlider.value = PlayerHealth;
            
            GameObject effect = Instantiate(DamageEffect, transform.position, Quaternion.identity);
            Destroy(effect, 0.5f);
            if (PlayerHealth <= 100 && PlayerHealth > 0)
            {
                AudioManager.Instance.PlaySFX(audioHandeler.musicHitEffect);
                StartCoroutine("ColorChange");
            }
            else if (PlayerHealth == 0)
            {
                AudioManager.Instance.PlaySFX(audioHandeler.musicExplosition);
                GameOver = true;
            }
            if (other.CompareTag("Enemy"))
            {
                Destroy(other.gameObject);
            }
            
        }
        else if (other.CompareTag("Health"))
        {
            if (PlayerHealth <= 100 && PlayerHealth >=80)
            {
                PlayerHealth = 100;
            }
            else if (PlayerHealth < 80 && PlayerHealth >= 0)
            {
                PlayerHealth += 20;
            }
            HealthSlider.value = PlayerHealth;
            Destroy(other.gameObject);
        }
    }
    IEnumerator ColorChange()
    {
        for (int i = 0; i < 4; i++)
        {
            render.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            render.color = Color.white;
        }
        
    }
    
}
