using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using TMPro;
using UnityEngine.UIElements;
using Unity.VisualScripting;

public class acornColliderScript : MonoBehaviour
{   
    public GameObject endMenu;
    public Rigidbody2D[] acornsBody;
    public Rigidbody2D rigidBody;
    public GameObject acorn;
    public TextMeshProUGUI scoreText;
    public Animator[] heart_anims;
    public GameObject[] hearts;
    public AudioSource deathSound;
    public TextMeshProUGUI highScoreText;
    public GameObject player;
    public GameObject enterButton;
    public static Animator animator;
    private bool touch = false;
    private float smallGravity = 0.3f;
    private float bigGravity = 0.5f;
    public static int lives = 4;


    // bababoey
    private void Start()
    {   
        if (PlayerPrefs.GetInt("adsPlaying") == 1)
        {
            enterButton.SetActive(true);
            Time.timeScale = 0.0f;
        }
        else
        {
            Time.timeScale = 1.0f;
        }
        lives = 4;
        StartCoroutine(firstAcorn());
        StartCoroutine(secondAcorn());
    }


    private IEnumerator firstAcorn()
    {
        yield return new WaitForSeconds(15);
        acornsBody[1].bodyType = RigidbodyType2D.Dynamic;
    }
    private IEnumerator secondAcorn()
    {
        yield return new WaitForSeconds(30);
        acornsBody[2].bodyType = RigidbodyType2D.Dynamic;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && rigidBody.velocity.y < -0.0001)
        {   
            float veloOne = Random.Range(-3f, 3f);
            float veloTwo = Random.Range(3f, 5f);
            rigidBody.velocity = new Vector2(veloOne, veloTwo);
            if (!touch)
            {
                int temp_index = lives - 1;
                deathSound.Play();
                heart_anims[temp_index].SetBool("Dead", true);
                Destroy(hearts[temp_index], 1);
                Debug.Log("PLZ I NEEEEEEEEEEED UUUUUUUUUUUUUUUUUUUUUU");
                touch = true;
                lives--;
            }
        }

        
        if(collision.gameObject.name == "Square")
        {
            float number = Random.Range(-3f, 4f);
            float rotation = Random.Range(-1000, 1000);
            rigidBody.velocity = new Vector3(0, 0, 0);
            rigidBody.angularVelocity = rotation;
            acorn.transform.Rotate(0f, 0f, 0f);
            acorn.transform.position = new Vector2(number, 6);
            touch = false;
            rigidBody.gravityScale = Random.Range(smallGravity, bigGravity);
            smallGravity += 0.03f;
            bigGravity += 0.03f;

        }
    }
    private void Update()
    {
        //Debug.Log(PlayerPrefs.GetInt("adsPlaying"));
        if (lives <= 0)
        {
            endGame();
        }
        
    }
    private void endGame()
    {   
        player.transform.parent = null;
        Destroy(hearts[0], 1);
        Time.timeScale = 0f;
        endMenu.SetActive(true);
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("highScore").ToString();
    }
}
