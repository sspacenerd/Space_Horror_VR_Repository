using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.XR;
using UnityEngine.UI;
public class InteractionManager : MonoBehaviour
{
    public InputDevice inputDeviceLeft, inputDeviceRight;
    private XRNode inputDeviceNode_L, inputDeviceNode_R;
    public bool triggerBool, test;
    [SerializeField] private GameObject flashlight;
    public static bool isTurned = false;

    private void Start()
    {
     
    }
    void Update()
    {
        GetDevice();
        if(inputDeviceLeft.TryGetFeatureValue(CommonUsages.triggerButton, out triggerBool) && triggerBool)
        {
        }     
    }
    void GetDevice()
    {
        inputDeviceLeft = InputDevices.GetDeviceAtXRNode(inputDeviceNode_L);
        inputDeviceRight = InputDevices.GetDeviceAtXRNode(inputDeviceNode_R);
    }
    private void OnEnable()
    {
        if (!inputDeviceLeft.isValid || !inputDeviceRight.isValid)
        {
            GetDevice();
        }
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
