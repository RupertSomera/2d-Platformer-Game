using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Melee : MonoBehaviour
{
    public float movespeed;
    public float attackrange;
    public GameObject player;




    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector2.Distance(transform.position, player.transform.position) < attackrange)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, movespeed * Time.deltaTime);
            Flip();
        }
    }

    private void Flip()
    {
        if (transform.position.x > player.transform.position.x)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

}
