using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpForce = 1000;
    [SerializeField] private float deathLaunch = 500;
    [SerializeField] private Animator anim;
    [SerializeField] private GameObject powPrefab;
    private Rigidbody2D rb;
    private BoxCollider2D collider;
    private bool isDead;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        collider = GetComponent<BoxCollider2D>();
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (isDead == false)
        {
            if (Input.GetMouseButton(0))
            {
                print("Jump pressed");
                Jump();
            }
        }
    }

    private void Jump()
    {
        rb.AddForce(transform.up * jumpForce * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Obstacle" || collision.gameObject.tag == "Ground")
        {
            Die();
            GameManager.instance.GameOver();
        }
    }

    private void Die()
    {
        Instantiate(powPrefab, transform.position, Quaternion.identity);
        rb.AddForce(transform.up * deathLaunch);
        collider.enabled = false;
        anim.SetTrigger("Die");
        isDead = true;
    }
}
