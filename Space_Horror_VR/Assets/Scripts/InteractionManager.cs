using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.XR;
using UnityEngine.UI;
public class InteractionManager : MonoBehaviour
{
    public InputDevice inputDeviceLeft, inputDeviceRight;
    public XRNode inputDeviceNode_L, inputDeviceNode_R;
    public bool triggerBool;
    void Update()
    {
        GetDevice();
        if(inputDeviceLeft.TryGetFeatureValue(CommonUsages.triggerButton, out triggerBool) && triggerBool)
        {
            Debug.Log("hola");
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


}
