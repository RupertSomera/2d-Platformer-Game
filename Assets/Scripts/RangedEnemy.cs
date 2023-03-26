using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    public GameObject Player;
    private float timer;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {      
        float distance = Vector2.Distance(transform.position, Player.transform.position);
        

        if(distance < 8)
        {
            timer += Time.deltaTime;
             if (timer > 2)
                 {
                     timer = 0;
                     shoot();
                 }


        }
    

    }

    void shoot()
    {
        Instantiate(bullet, bulletPos.position, Quaternion.identity);


    }



}
