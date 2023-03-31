using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Boss_Projectiles : MonoBehaviour
{
    public GameObject bullet;
    public Transform[] bulletPos;
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

        if (distance < 8)
        {
            timer += Time.deltaTime;
            if (timer > 8)
            {
                timer = 0;
                shoot();
            }


        }


    }

    void shoot()
    {
        Instantiate(bullet, bulletPos[0].position, Quaternion.identity);
        Instantiate(bullet, bulletPos[1].position, Quaternion.identity);
        Instantiate(bullet, bulletPos[2].position, Quaternion.identity);
        Instantiate(bullet, bulletPos[3].position, Quaternion.identity);
    }



}