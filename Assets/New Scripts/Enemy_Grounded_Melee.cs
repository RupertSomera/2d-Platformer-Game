using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Grounded_Melee : MonoBehaviour
{
    public float moveSpeed;
    public float detectionRange;

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, player.transform.position) < detectionRange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, moveSpeed * Time.deltaTime);
        }
    }
}
