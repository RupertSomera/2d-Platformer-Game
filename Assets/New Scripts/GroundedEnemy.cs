using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundedEnemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float detectionRange = 5f;
    public float raycastLength = 0.1f;

    private Rigidbody2D rb2d;
    private Transform player;
    private bool isChasing = false;
    private Vector3 originalPosition;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        originalPosition = transform.position;
    }

    private void FixedUpdate()
    {
        if (!isChasing)
        {
            // Check if the player is within detection range
            RaycastHit2D hit = Physics2D.Raycast(transform.position, player.position - transform.position, detectionRange);
            if (hit && hit.transform.CompareTag("Player"))
            {
                isChasing = true;
            }
        }
        else
        {
            // Move towards the player
            Vector2 direction = (player.position - transform.position).normalized;
            rb2d.velocity = new Vector2(direction.x * moveSpeed, rb2d.velocity.y);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // If the enemy collides with an object that is not the player, stop chasing and return to original position
        if (!collision.transform.CompareTag("Player"))
        {
            isChasing = false;
            rb2d.velocity = Vector2.zero;
            transform.position = originalPosition;
        }
    }
}