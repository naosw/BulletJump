using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float jumpForce = 6f;
    public float walkSpeed = 6f;
    public TextMeshProUGUI bullets;
    public GameObject chamberOne;
    public GameObject chamberTwo;
    public GameObject chamberThree;
    public GameObject chamberFour;
    public GameObject chamberFive;
    public GameObject chamberSix;
    public GameObject chamberEmpty;
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

        // bullet chambers
        if (bulletCount == 6) {
            chamberSix.SetActive(true);
            chamberEmpty.SetActive(false);
        }
        if (bulletCount == 5)
        {
            chamberFive.SetActive(true);
            chamberSix.SetActive(false);
        }
        if (bulletCount == 4)
        {
            chamberFour.SetActive(true);
            chamberFive.SetActive(false);
        }
        if (bulletCount == 3)
        {
            chamberThree.SetActive(true);
            chamberFour.SetActive(false);
        }
        if (bulletCount == 2)
        {
            chamberTwo.SetActive(true);
            chamberThree.SetActive(false);
        }
        if (bulletCount == 1)
        {
            chamberOne.SetActive(true);
            chamberTwo.SetActive(false);
        }
        if (bulletCount == 0)
        {
            chamberEmpty.SetActive(true);
            chamberOne.SetActive(false);
        }
    }
}
