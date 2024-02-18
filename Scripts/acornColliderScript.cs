using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class acornColliderScript : MonoBehaviour
{
    public Rigidbody2D rigidBody;
    public GameObject acorn;
    private bool touch = false;
    // Start is called before the first frame update
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Player" && rigidBody.velocity.y < 0f )
        {
            float veloOne = Random.Range(-3f, 3f);
            float veloTwo = Random.Range(3f, 5f);
            rigidBody.velocity = new Vector2(veloOne, veloTwo);
            if (!touch)
            {
                Debug.Log("PLZ I NEEEEEEEEEEED UUUUUUUUUUUUUUUUUUUUUU");
                touch = true;
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
            rigidBody.gravityScale += 0.01f;
        }
    }
    // Update is called once per frame
    void Update()
    {
        Debug.Log("Collision with Player detected.");
        Debug.Log("Velocity: " + rigidBody.velocity.y + ", touch: " + touch);
    }
}
