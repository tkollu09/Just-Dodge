using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;

public class cherryColliderScript : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public GameObject cherry;
    public TextMeshProUGUI scoreText; 
    public TextMeshProUGUI endText;
    public TextMeshProUGUI highScoreText;
    public AudioSource eatSound;
    public GameObject crown;
    private bool touch = false;
    private float smallGravity = 0.3f;
    private float bigGravity = 0.5f;
    public int score = 0;



    // Start is called before the first frame update
    // bababoey
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && rigidBody.velocity.y < 0f)
        {
            float number = Random.Range(-2.5f, 2.5f);
            float veloOne = Random.Range(-3f, 3f);
            float veloTwo = Random.Range(3f, 3f);
            rigidBody.velocity = new Vector2(veloOne, veloTwo);
            if (!touch)
            {
                //Debug.Log("PLZ I NEEEEEEEEEEED UUUUUUUUUUUUUUUUUUUUUU");
                touch = true;
            }
            score++;
            if (!PlayerPrefs.HasKey("lifetimeScore"))
            {
                PlayerPrefs.SetInt("lifetimeScore", score);
            }
            else
            {
                int totalScore = PlayerPrefs.GetInt("lifetimeScore");
                totalScore++;
                PlayerPrefs.SetInt("lifetimeScore", totalScore);
            }
            cherry.transform.position = new Vector2(number, 6);
            scoreText.text = score.ToString();
            eatSound.Play();
        }


        if (collision.gameObject.name == "Square")
        {
            float number = Random.Range(-3f, 4f);
            float rotation = Random.Range(-1000, 1000);
            rigidBody.velocity = new Vector3(0, 0, 0);
            rigidBody.angularVelocity = rotation;
            cherry.transform.Rotate(0f, 0f, 0f);
            cherry.transform.position = new Vector2(number, 6);
            touch = false;
            rigidBody.gravityScale = Random.Range(smallGravity, bigGravity);
            smallGravity += 0.03f;
            bigGravity += 0.03f;
        }
    }

    private void Update()
    {
        if (!PlayerPrefs.HasKey("highScore"))
        {
            PlayerPrefs.SetInt("highScore", score);
        }
        else
        {
            if (score > PlayerPrefs.GetInt("highScore"))
            {   
                crown.SetActive(true);
                PlayerPrefs.SetInt("highScore", score);
            }
        }
        
        endText.text = "Score: " + score.ToString();
        highScoreText.text = "Highscore: " + PlayerPrefs.GetInt("highScore").ToString();
        if (acornColliderScript.lives == 0)
        {
            PlayerPrefs.SetInt("Score", score);
        }
    }

}
