using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreasurePlates : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.name)
        {
            case "Box":
                Debug.Log("Entered");
                break;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        switch (collision.gameObject.name)
        {
            case "Box":
                Debug.Log("Exited");
                break;
        }
    }
}
