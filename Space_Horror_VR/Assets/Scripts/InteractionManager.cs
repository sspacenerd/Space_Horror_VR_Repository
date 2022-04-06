using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private GameObject flashlight;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void TurnOnOffLintern()
    {
        if (flashlight.gameObject.GetComponentInChildren<Light>().intensity == 6)
        {
            flashlight.gameObject.GetComponentInChildren<Light>().intensity = 0;
        }
        else
        {
            flashlight.gameObject.GetComponentInChildren<Light>().intensity = 6;
        }
    }
}
