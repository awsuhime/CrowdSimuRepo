using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigGuy : MonoBehaviour
{
    public GameObject[] enemies;
    public float shootingRange = 5f;
    public GameObject projectile;
    public float cooldown = 1f;
    private float cdstart;
    private bool reloading = false;

    private void Start()
    {
    }

    private void Update()
    {
        if (!reloading)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (GameObject i in enemies)
            {
                if (Vector3.Distance(transform.position, i.transform.position) < shootingRange)
                {
                    Instantiate(projectile, transform.position, Quaternion.identity);
                    reloading = true;
                    cdstart = Time.time;
                }
            }
        }
        else
        {
            if (Time.time - cdstart > cooldown)
            {
                reloading = false; 
            }
        }
        
    }
}
