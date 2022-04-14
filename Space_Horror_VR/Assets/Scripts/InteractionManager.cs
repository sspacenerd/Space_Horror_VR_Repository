using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.XR;
public class InteractionManager : MonoBehaviour
{
    public InputDevice inputDeviceLeft, inputDeviceRight;
    private XRNode inputDeviceNode_L, inputDeviceNode_R;
    [SerializeField] private GameObject flashlight;
    public static bool isTurned = false;
    // Start is called before the first frame update
    void Start()
    {
    }
    // Update is called once per frame
    void Update()
    {
        GetDevice();
    }
    void GetDevice()
    {
        inputDeviceLeft = InputDevices.GetDeviceAtXRNode(inputDeviceNode_L);
        inputDeviceRight = InputDevices.GetDeviceAtXRNode(inputDeviceNode_R);
    }
    private void OnEnable()
    {
        if (!inputDeviceLeft.isValid)
        {
            GetDevice();
        }
        if (!inputDeviceRight.isValid)
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
    public void Camera()
    {
    }
}
