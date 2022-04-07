using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class InteractionManager : MonoBehaviour
{
    [SerializeField] private GameObject flashlight;
    public static bool isTurned = false;
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
        if (isTurned)
        {
            Emission(flashlight, 3, Color.black);
            isTurned = false;
        }
        else
        {
            Emission(flashlight, 3, Color.white);
            isTurned = true;
        }
    }
    public static void Emission(GameObject myGameobject, float timeAmount, Color myColor)
    {
        Material mymat = myGameobject.GetComponent<Renderer>().material;
        mymat.EnableKeyword("_EMISSION");
        mymat.DOColor(myColor, "_EmissionColor", timeAmount);
        DynamicGI.UpdateEnvironment();
    }
}
