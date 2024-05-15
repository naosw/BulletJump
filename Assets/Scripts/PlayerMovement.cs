using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 6f;
    public float walkSpeed = 6f;
    public TextMeshProUGUI bullets;
    private int bulletCount = 6;
    public GameObject bullet;
    public GameObject self;
    TouchingDirections touchingDirections;

    Rigidbody2D rb;
    public Animator animator;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        touchingDirections = GetComponent<TouchingDirections>();
        refreshBullets();
    }

    void refreshBullets()
    {
        bullets.text = "Bullets: " + bulletCount;
        animator.SetInteger("Bullets", bulletCount);
    }

    void fireBullet()
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y - 1.25f, transform.position.z), Quaternion.Euler(0, 0, 180));
    }

    // Update is called once per frame
    void Update()
    {
        self.transform.eulerAngles = new Vector3(0, 0, 0);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (touchingDirections.IsGrounded) {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
            else if (bulletCount > 0) {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                bulletCount--;
                refreshBullets();
                fireBullet();
            }
        }
        if (Input.GetKey(KeyCode.A))
        {
            rb.velocity = new Vector2(-walkSpeed, rb.velocity.y);
        }
        if (Input.GetKey(KeyCode.D))
        {
            rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            bulletCount = 6;
            refreshBullets();
        }
    }
}
