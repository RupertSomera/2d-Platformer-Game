using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;


public class MainEnemyScript : MonoBehaviour
{
    public int Health;
    public HealthSystem PlayerHealth;
    public int Damage;
    private int DmgCooldown;
    private void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Debug.Log("TakenDamage");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.tag == "Player")
        {
            PlayerHealth.TakeDamage(Damage);

        }
        if(collision.gameObject.tag == "Bullet")
        {
            TakeDamage(1);
        }
        
    }


}
