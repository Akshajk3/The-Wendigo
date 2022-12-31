using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5;
    public Rigidbody2D rb;
    public Animator anim;

    public float scale = 7;

    private int attack;

    public float attack1Length = 30f;
    public float attack2Length = 36f;

    public bool canMove = true;

    public bool InConverstion = false;


    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        // Input
        if (InConverstion == false)
        {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
        }

        if (movement.x < 0)
        {
            transform.localScale = new Vector2(-scale, transform.localScale.y);
        }
        else if (movement.x > 0)
        {
            transform.localScale = new Vector2(scale, transform.localScale.y);
        }

        if (movement != new Vector2(0, 0))
        {
            anim.SetBool("IsRunning", true);
        }
        else
        {
            anim.SetBool("IsRunning", false);
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && InConverstion == false)
        {
            rb.constraints = RigidbodyConstraints2D.FreezePosition;
            attack = Random.Range(1, 3);
            Debug.Log(attack);
            Invoke("AttackAnimation", 0.2f);
            Invoke("FreezeMovement", 0.4f);
            anim.SetInteger("Attack", attack);
        }
        
    }
    
    void AttackAnimation()
    {
        anim.SetInteger("Attack", 0);
    }

    void FreezeMovement()
    {
        rb.constraints = ~RigidbodyConstraints2D.FreezePosition;
    }

    void FixedUpdate()
    {
        if (canMove && InConverstion == false)
        {
            movement = movement.normalized;
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
        }
    }
}
