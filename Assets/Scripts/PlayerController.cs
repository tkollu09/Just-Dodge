using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;
using System;
using Unity.VisualScripting;
using UnityEngine.UIElements;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public FloatingJoystick joystick;
    public Animator animator;
    public CharacterController2D controller;
    public GameObject player;
    public GameObject respawnBar;
    public AudioSource deathSound;
    public AudioSource jumpSound;


    public float moveSpeed;
    float horizontalMove = 0;
    bool jump = true;


    public void isJumping()
    {
        jump = true;
        jumpSound.Play();
        //Debug.Log("porop");
    }

    private void FixedUpdate()
    {
        //rigidBody.velocity = new Vector2(joystick.Horizontal * moveSpeed, rigidBody.velocity.y);
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
        //Debug.Log(jump);
    }

    private void Update()
    {   
        horizontalMove = joystick.Horizontal * moveSpeed;
        animator.SetFloat("Speed", Mathf.Abs(joystick.Horizontal));

        animator.SetFloat("Jump", rigidBody.velocity.y);
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == respawnBar)
        {
            player.transform.position = new Vector2(0, 5);
            rigidBody.gravityScale = 0.2f;
            StartCoroutine(resetGravity());
            deathSound.Play();

        }
    }


    private IEnumerator resetGravity()
    {
        yield return new WaitForSeconds(2);
        rigidBody.gravityScale = 2;
    }


}
