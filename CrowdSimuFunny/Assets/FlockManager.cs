using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class FlockManager : MonoBehaviour
{
    public GameObject fishPrefab;
    public int numFish = 20;
    public GameObject[] allFIsh;
    public Vector3 swimLimits = new Vector3(5, 5, 5);
    public Vector3 goalPos;
    public float goalswapTime = 5f;
    private float goalswapstart;
    private bool swapcd;
    public GameObject goalguy;

    [Range(0.0f, 5.0f)]
    public float minSpeed;
    [Range(0.0f, 5.0f)]
    public float maxSpeed;
    [Range(1.0f, 10.0f)]
    public float neighbourDistance;
    [Range(0.0f, 5.0f)]
    public float rotationSpeed;
    // Start is called before the first frame update
    void Start()
    {
        allFIsh = new GameObject[numFish];
        for(int i = 0; i <numFish; i++)
        {
            Vector3 pos = transform.position + new Vector3 (Random.Range(-swimLimits.x, swimLimits.x), Random.Range(-swimLimits.y, swimLimits.y), Random.Range(-swimLimits.z, swimLimits.z));
            allFIsh[i] = Instantiate(fishPrefab, pos, Quaternion.identity);
            allFIsh[i].GetComponent<Flockyay>().manager = this;
        }
        goalPos = transform.position;
        goalguy.transform.position = goalPos;
    }

    // Update is called once per frame
    void Update()
    {
        if (!swapcd)
        {
            goalPos = transform.position + new Vector3(Random.Range(-swimLimits.x, swimLimits.x), Random.Range(-swimLimits.y, swimLimits.y), Random.Range(-swimLimits.z, swimLimits.z)); ;
            goalswapstart = Time.time;
            swapcd = true;
            goalguy.transform.position = goalPos;


        }
        else if (Time.time - goalswapstart > goalswapTime)
        {
            swapcd = false;
        }

    }
}
