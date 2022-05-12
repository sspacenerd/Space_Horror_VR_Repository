using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class OnVisible : MonoBehaviour
{
    private Camera cam;
    public bool isTurned;

    private void Start()
    {
        cam = Camera.main;
    }
    public void OnShot()
    {
        switch (this.gameObject.GetComponent<Transform>().name)
        {
            case "Interactable":
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
                break;
            case "Flashlight":
                {
                    if (!isTurned && FieldOfView(cam, this.gameObject))
                    {
                        TurnOnLight();
                    }
                }

                break;
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
    public void TurnOnLight()
    {
        Emission(this.gameObject, 3, Color.white);
        isTurned = true;

    }
    public static void Emission(GameObject myGameobject, float timeAmount, Color myColor)
    {
        Material mymat = myGameobject.GetComponent<Renderer>().material;
        mymat.EnableKeyword("_EMISSION");
        mymat.DOColor(myColor, "_EmissionColor", timeAmount);
        DynamicGI.UpdateEnvironment();
    }
}
