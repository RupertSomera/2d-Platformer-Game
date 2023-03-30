using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileAttack : MonoBehaviour
{
    public MainEnemyScript MainEnemyScript;
    public Rigidbody2D projectileRb;
    public float speed;

    PlayerMovement playerMovement;
    public float projectileLife;
    public float projectileCount;
    public bool FacingRight;
    
    // Start is called before the first frame update
    void Start()
    {
        projectileCount = projectileLife;
        
    }

    // Update is called once per frame
    void Update()
    {
        

        projectileCount -= Time.deltaTime;
        if(projectileCount <= 0)
        {
            Destroy(gameObject);
        }

        
    }

    private void FixedUpdate()
    {
        projectileRb.velocity = new Vector2(speed, projectileRb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {      
            Destroy(gameObject);
        }
        

    }


}
