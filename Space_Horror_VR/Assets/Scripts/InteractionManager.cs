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
    public bool triggerBool;
    bool viewingPhoto;
    [SerializeField] private GameObject flashlight;
    public static bool isTurned = false;
    [Header("PhotoTaker")]
    [SerializeField] private Image photoDisplayArea;
    [SerializeField] private GameObject photoFrame;
    private Texture2D screenCapture;

    private void Start()
    {
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    }
    public IEnumerator CapturePhoto()
    {
        viewingPhoto = true;
        yield return new WaitForEndOfFrame();
        Rect regionToRoad = new Rect(0, 0, Screen.width, Screen.height);
        screenCapture.ReadPixels(regionToRoad, 0, 0, false);
        screenCapture.Apply();
        ShowPhoto();
    }
    void ShowPhoto()
    {
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        photoDisplayArea.sprite = photoSprite;
        photoFrame.SetActive(true);
    }
    void Update()
    {
        GetDevice();
        if(inputDeviceLeft.TryGetFeatureValue(CommonUsages.triggerButton, out triggerBool) && triggerBool)
        {
            if(!viewingPhoto || triggerBool)
            {
                StartCoroutine(CapturePhoto());
            }
            else
            {
               // RemovePhoto();
            }
            
        }     
    }
    void RemovePhoto()
    {
        viewingPhoto = false;
        photoFrame.SetActive(false);
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
}
