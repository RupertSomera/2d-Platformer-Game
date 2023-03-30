using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;
    public Animator animator;

    private void Update()
    {
        if(timeBtwAttack <= 0)
        {
            if(Input.GetKey(KeyCode.Mouse0))
            {
                IsAttacking(true);
                Collider2D[] EnemiestoDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange,whatIsEnemies);
                for (int i = 0; i < EnemiestoDamage.Length; i++)
                {
                    EnemiestoDamage[i].GetComponent<MainEnemyScript>().TakeDamage(damage);                   

                }
            }

            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {
            timeBtwAttack -= Time.deltaTime;
            IsAttacking(false);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }

    private void IsAttacking(bool dec)
    {
        animator.SetBool("isAttacking",dec);
    }

}
