using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class MainEnemyScript : MonoBehaviour
{
    public int Health;

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



}
