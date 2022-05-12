using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnVisible : MonoBehaviour
{
    public Camera cam;
    public void Visibility()
    {
        if (GetComponent<Renderer>().isVisible == false && FieldOfView(cam, this.gameObject) && GetComponent<BoxCollider>().enabled == false)
        {
            Debug.Log("now u can!");
            GetComponent<MeshRenderer>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;
        }

        if (GetComponent<Renderer>().isVisible == true && FieldOfView(cam, this.gameObject) && GetComponent<BoxCollider>().enabled == true)
        {
            Debug.Log("now u dont!");
            GetComponent<MeshRenderer>().enabled = false;
            GetComponent<BoxCollider>().enabled = false;
        }
    }
    //Funcion para checkear si el objeto está dentro del FOV de la camara
    private bool FieldOfView(Camera c, GameObject target)
    {
        var planes = GeometryUtility.CalculateFrustumPlanes(c);
        var point = target.transform.position;
        foreach (var plane in planes)
        {
            if (plane.GetDistanceToPoint(point) < 0)
            {
                return false;
            }
        }
        return true;
    }
}
