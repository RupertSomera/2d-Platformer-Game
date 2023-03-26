using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{
    public GameObject[] hearts;
    private int life;
    private bool death;


    private void Start()
    {
        life = hearts.Length;
    }
    void Update()
    {
        if(death == true)
        {
            //Death
            Debug.Log("Death has Come");
            Destroy(gameObject);
        }
    }

    public void TakeDamage(int dmg)
    {
        if (life >= 1)
        {
            life -= dmg;
            Destroy(hearts[life].gameObject);
            if (life < 1)
            {
                death = true;
            }
        }
    }

}
