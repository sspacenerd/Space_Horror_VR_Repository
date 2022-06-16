using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
public class ObjectManager : MonoBehaviour
{
    [SerializeField] private GameObject fade;
    [SerializeField] private Material standardMat;
    private Camera cam;
    public bool isTurned;
    public static bool hasTraveled;
    [SerializeField] private SaveSystem mySaveSystem;
    private void Start()
    {
        cam = Camera.main;
        /*
        if (mySaveSystem.teleport == 1 && this.gameObject.name == "Teleports")
        {
            this.gameObject.GetComponent<Renderer>().material = standardMat;
            this.gameObject.GetComponent<PreasurePlates>().enabled = true;
        }
        */
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
                    break;
                }
            case "Flashlight":
                {
                    if (!isTurned && FieldOfView(cam, this.gameObject))
                    {
                        Emission(this.gameObject, 3, Color.white);
                        this.gameObject.GetComponentInChildren<Light>().DOIntensity(0.5f, 3f);
                        isTurned = true;
                    }
                    break;
                }
            case "Teleports":
                {
                    if(FieldOfView(cam, this.gameObject) && !hasTraveled)
                    {
                        StartCoroutine(GoTo());
                    }
                    break;
                }
            case "GoToScene":
                {
                    hasTraveled = true;
                    ES3.Save("hasTraveled", hasTraveled);
                    StartCoroutine(GoBack());
                    break;
                }
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
    public void Emission(GameObject myGameobject, float timeAmount, Color myColor)
    {
        Material mymat = myGameobject.GetComponent<Renderer>().material;
        mymat.EnableKeyword("_EMISSION");
        mymat.DOColor(myColor * 3, "_EmissionColor", timeAmount);
        DynamicGI.UpdateEnvironment();
    }
    IEnumerator GoBack()
    {
        GameManager.Fade(fade, 1, 1f);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(0);
        yield break;
    }
    IEnumerator GoTo()
    {
        GameManager.Fade(fade, 1, 1f);
        mySaveSystem.teleport = 1;
        mySaveSystem.SaveData();
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene(1);
    }
}
