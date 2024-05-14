using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 6f;
    public float walkSpeed = 6f;
    public TextMeshProUGUI bullets;

    private int bulletCount = 6;

    Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        bullets.text = "Bullets: " + bulletCount;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bulletCount > 0) {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                bulletCount--;
                bullets.text = "Bullets: " + bulletCount;
            }
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = new Vector2(-walkSpeed, rb.velocity.y);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity = new Vector2(walkSpeed, rb.velocity.y);
        }
    }
}
