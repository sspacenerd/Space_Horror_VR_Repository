using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
public class LocationSnap : MonoBehaviour
{
    private bool insideSnapZone;
    public bool snapped;
    public GameObject part, snapRotationReference;
    public static bool liftSender, liftSender2;
    public AudioSource placa;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == part.name && this.gameObject.name == "SnapZone")
        {
            insideSnapZone = true;
            liftSender = true;
            SnapObject();
        }
        if (other.gameObject.name == part.name && this.gameObject.name == "SnapZone2")
        {
            insideSnapZone = true;
            liftSender2 = true;
            SnapObject();
        }

    }
    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.name == part.name && this.gameObject.name == "SnapZone")
        {
            insideSnapZone = false;
            liftSender = false;
            snapped = false;
        }
        if (other.gameObject.name == part.name && this.gameObject.name == "SnapZone2")
        {
            insideSnapZone = false;
            liftSender2 = false;
            snapped = false;
        }
    }
    void SnapObject()
    {
        if (insideSnapZone)
        {
            part.gameObject.transform.position = transform.position;
            part.gameObject.transform.rotation = snapRotationReference.transform.rotation;
            placa.Play();
            snapped = true;
        } 
    }
}
