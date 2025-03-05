using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    GameObject target;
    private float closest = Mathf.Infinity;
    public float speed = 5f;
    private void Start()
    {
        foreach (GameObject i in GameObject.FindGameObjectsWithTag("Enemy"))
        {
            if (Vector3.Distance(transform.position, i.transform.position) < closest)
            {
                target = i;
                closest = Vector3.Distance(transform.position, i.transform.position);
            }
        }
    }

    private void Update()
    {
        if (target == null)
        {
            foreach (GameObject i in GameObject.FindGameObjectsWithTag("Enemy"))
            {
                if (Vector3.Distance(transform.position, i.transform.position) < closest)
                {
                    target = i;
                    closest = Vector3.Distance(transform.position, i.transform.position);
                }
            }
        }
        transform.LookAt(target.transform.position);
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.GetComponent<Enemy>() != null)
        {
            other.GetComponent<Enemy>().TakeDamage(5);
            Destroy(gameObject);
        }
    }

    
}
