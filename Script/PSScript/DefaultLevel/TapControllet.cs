using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class TapControllet : MonoBehaviour
{
    public delegate void PlayerDelegate();
    public static event PlayerDelegate OnPlayerDied;
    public static event PlayerDelegate OnPlayerScored;

    public float tapForce = 10;
    public float tiltSmooth = 5;
    public Vector3 startPos;

    public AudioSource tapAudio;
    public AudioSource scoreAudio;
    public AudioSource dieAudio;

    public Rigidbody2D rigidbody2D;
    Quaternion downRotation;
    Quaternion forwardRotation; 

    GameManager game;

    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        downRotation = Quaternion.Euler(0, 0, -90);
        forwardRotation = Quaternion.Euler(0, 0, 35);
        game = GameManager.Instance;
        rigidbody2D.simulated = false;

    }

    void OnEnable() {
        GameManager.OnGameStarted += OnGameStarted;
        GameManager.OnGameOverConfirmed += OnGameOverConfirmed;
    }
    void OnDisable() {
        GameManager.OnGameStarted -= OnGameStarted;
        GameManager.OnGameOverConfirmed -= OnGameOverConfirmed;        
    }

    void OnGameStarted(){
        rigidbody2D.velocity = Vector3.zero;
        rigidbody2D.simulated = true;
    }
    void OnGameOverConfirmed(){
        transform.localPosition = startPos;
        transform.rotation = Quaternion.identity;
    }

    void Update()
    {
        if (game.GameOver) return;
        if (Input.GetMouseButton(0))
        {
            tapAudio.Play();
            //Time.timeScale += 1; // use for increase TimeScale
            transform.rotation = forwardRotation;
            rigidbody2D.velocity = Vector3.zero;
            rigidbody2D.AddForce(Vector2.up * tapForce, ForceMode2D.Force);
        }
        transform.rotation = Quaternion.Lerp(transform.rotation, downRotation, tiltSmooth * Time.deltaTime);
    }
    public bool Dead_or_not = false;

    private void OnTriggerEnter2D(Collider2D col) {
        if (col.gameObject.tag == "ScoreZone"){
            Dead_or_not = false;
            //register a score event
            OnPlayerScored();//event sent to gamemanager
            //play a sound
            scoreAudio.Play();
        }
        if (col.gameObject.tag == "DeadZone"){
            rigidbody2D.simulated = false;
            Dead_or_not = true;
            //register a dead event
            OnPlayerDied();//event sent to gamemanager
            //play a sound
            dieAudio.Play();
        }
    }
}
