using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class LocationSnap : MonoBehaviour
{
    private bool insideSnapZone;
    public bool snapped;
    public GameObject part, snapRotationReference;
    public static bool liftSender;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == part.name)
        {
            insideSnapZone = true;
            liftSender = true;
            SnapObject();
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == part.name)
        {
            insideSnapZone = false;
            liftSender = false;
            snapped = false;
        }
    }
    void SnapObject()
    {
        if (insideSnapZone)
        {
            part.gameObject.transform.position = transform.position;
            part.gameObject.transform.rotation = snapRotationReference.transform.rotation;
            snapped = true;
        } 
    }
}
