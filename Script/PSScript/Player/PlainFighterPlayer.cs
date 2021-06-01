using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
// Puri Sahib
public class PlainFighterPlayer : MonoBehaviour
{
    public AudioHandeler audioHandeler;

    // player
    Rigidbody2D rb;
    public GameObject[] render;
    //public SpriteRenderer[] render;
    public int RenderFile = 0;
    public float dirx, diry;
    float moveSpeed = 5f;

    // Player Damage Effect
    public GameObject[] DamageEffect;

    //Player Health
    private int PlayerHealth;
    public Slider HealthSlider;

    // Score 
    //public static int Score;
    public DataBaseManager dataBaseManager;
    public static bool Accumalator = true;

    public void Awake()
    {
        Score = 0;
        PlayerHealth = 100;
        HealthSlider.value = PlayerHealth;
    }
    public void UpDateValue()
    {
        
        for (int i = 0; i < 2; i++)
        {
            render[i].SetActive(false);
        }
        render[RenderFile].SetActive(true);
        FunUpdateAll();
    }
    private void FunUpdateAll()
    {
        dataBaseManager.Score = 0;
        PlayerHealth = 100;
        HealthSlider.value = PlayerHealth;
        transform.position = new Vector2(Mathf.Clamp ( 0f, -7.5f, 7.5f), -3.56f);// Change Player Default Place
    }

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        //render = gameObject.GetComponent<SpriteRenderer>();
    }
    private void Update() {
        if (Accumalator == true)
        {
            dirx = Input.acceleration.x * 10;
        }
        else if (Accumalator == false)
        {
            dirx = ShiftingPlairForInsertData.inputSpeed * moveSpeed;
        }
        transform.position = new Vector2(Mathf.Clamp ( transform.position.x, -7.5f, 7.5f), transform.position.y);
        rb.velocity = new Vector2(dirx, 0f);
    }
  
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Left"))
        {
            // left --value
            if (dirx < 0)
            {
                Debug.Log("Left");
                dirx = 0;
            }
        }
        else if (other.CompareTag("Right"))
        {
            // right ++value
            if (dirx > 0)
            {
                Debug.Log("Right");
                dirx = 0;
            }
        }
        if (other.CompareTag("Coin"))
        {
            //Score
            dataBaseManager.Coin += 1;
            Destroy(gameObject);
        }
        if (other.CompareTag("Distance"))
        {
            //Score
            dataBaseManager.Distance += 1;
            Destroy(gameObject);
        }
        else if (other.CompareTag("Bullet") || other.CompareTag("Enemy"))
        {
            PlayerHealth -= 10;
            HealthSlider.value = PlayerHealth;
            if (PlayerHealth <= 100 && PlayerHealth > 0)
            {
                GameObject effect = Instantiate(DamageEffect[0], transform.position, Quaternion.identity);
                Destroy(effect, 0.5f);
                AudioManager.Instance.PlaySFX(audioHandeler.musicHitEffect);
                StartCoroutine("ColorChange");
            }
            else if (PlayerHealth == 0)
            {
                GameObject effect = Instantiate(DamageEffect[1], transform.position, Quaternion.identity);
                Destroy(effect, 1f);
                AudioManager.Instance.PlaySFX(audioHandeler.musicExplosition);
                SaveGame();
            }
            Destroy(other.gameObject);
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
            AudioManager.Instance.PlaySFX(audioHandeler.musicExplosition);
        }
    }
    IEnumerator ColorChange()
    {
        for (int i = 0; i < 4; i++)
        {
            render[RenderFile].GetComponent<SpriteRenderer>().color = Color.red;
            yield return new WaitForSeconds(0.2f);
            render[RenderFile].GetComponent<SpriteRenderer>().color = Color.white;
        }
        
    }
    private void SaveGame()
    {
        CalaulateGameManagerScore.GameOver = true;
        if (PlayerPrefs.GetInt("ScoreLevel3") < Score)
        {
            PlayerPrefs.SetInt("ScoreLevel3", Score);
        }
    }
}
