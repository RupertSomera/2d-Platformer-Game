using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPoint;
    PlayerMovement playerMovement;
    public Animator animation;

    public float shootTime;
    public float shootCount;
    public bool IsFacingRight = true;
    // Start is called before the first frame update
    void Start()
    {
        shootCount = shootTime;
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Input.GetKeyDown(KeyCode.E) && shootCount <= 0)
        {
            Instantiate(projectilePrefab, launchPoint.position, transform.rotation);
            shootCount = shootTime;
            animation.SetBool("IsSpecialAttking", true);
        }        
        else
        {
            animation.SetBool("IsSpecialAttking", false);
        }
        shootCount -= Time.deltaTime;
    }
    




}
