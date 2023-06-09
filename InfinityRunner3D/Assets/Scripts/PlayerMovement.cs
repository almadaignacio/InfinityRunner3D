using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public GameManager gameManager;

    public float speed = 5;
    public Rigidbody rb;

    float horizontalInput;
    float horizontalMultiplier = 1.7f;
    bool Is_Grounded;
    /*
    [Range(-1, 1)]
    [SerializeField] int position;

    Vector3 Destiny;
    bool ToRight;
    bool ToLeft;

    [SerializeField] float moveSpeed = 1;
    */
    private void FixedUpdate()
    {
        /*
        if(transform.position == Destiny)
        {
            if((Input.GetButtonDown ("Right") && (position < 1)))
            {
                Destiny = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
                position++;
            }
            if ((Input.GetButtonDown("Left") && (position > -1)))
            {
                Destiny = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
                position--;
            }
        }
        */
        //transform.position = Vector3.MoveTowards(transform.position, Destiny, moveSpeed * Time.deltaTime);

        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        rb.MovePosition(rb.position + forwardMove  + horizontalMove);


    }

    private void Start()
    {
        Is_Grounded = true;
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space) && Is_Grounded == true)
        {
            Jump();
        }
    }

    public void Jump()
    {
        Is_Grounded = false;
        rb.AddForce(0, 6, 0, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Obstacle"))
        {
            gameManager.GameOver();
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            Console.WriteLine("Coin");
        }

        if(collision.gameObject.CompareTag("Ground"))
        {
            Is_Grounded = true;
        }
    }

  

}
