using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sPEEDuP : MonoBehaviour
{
    public float speedup = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            Time.timeScale = speedup;
        }
        if (Input.GetKeyUp(KeyCode.F))
        {
            Time.timeScale = 1f;
        }
    }
}
