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
    public static bool didIShot; 
    int index = 30;
    bool takingPhoto;
    [Header("PhotoTaker")]
    [SerializeField] private GameObject myPhoto;
    [SerializeField] private AudioSource photoAudio, noShotsLeft;
    [SerializeField] private GameObject PhotoPosition;
    [SerializeField] private Transform grabbedObjectTrans;
    private Texture2D screenCapture;
    public Camera mainCam;
    private GameObject grabbedObject;
    void Update()
    {
        GetDevice();
        if(inputDeviceLeft.TryGetFeatureValue(CommonUsages.triggerButton, out triggerBool) && triggerBool)
        {

            Debug.Log("Hey");
            TakePhoto();
        }
        /*
        RaycastHit grab;
        if (inputDeviceLeft.TryGetFeatureValue(CommonUsages.triggerButton, out triggerBool) && triggerBool && Physics.Raycast(mainCam.transform.position, mainCam.transform.forward, out grab, 5) && grab.transform.GetComponent<Rigidbody>())
        {
            if (grab.transform.tag == "Default" || grab.transform.tag == "Bomb" || grab.transform.name == "BigBomb" || grab.transform.tag == "Assets" || grab.transform.tag == "Alcohol" || grab.transform.name == "Test" || grab.transform.tag == "Enemy")
            {
                grabbedObject = grab.transform.gameObject;
            }
        }
        else if (!triggerBool)
        {
            grabbedObject = null;
        }
        if (grabbedObject)
        {
            grabbedObject.GetComponent<Rigidbody>().velocity = 5 * (grabbedObjectTrans.position - grabbedObject.transform.position);
        }
        Debug.DrawRay(mainCam.transform.position, mainCam.transform.forward, Color.white);
        */
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
    public void TakePhoto()
    {
        if (!takingPhoto && index > 0)
        {
            StartCoroutine(TakePhoto(1f));
            photoAudio.Play();
        }
        else if (index <= 0)
        {
            noShotsLeft.Play();
        }
    }
    public IEnumerator TakePhoto(float coolDown)
    {
        takingPhoto = true;
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Interactable");
        foreach (var x in objects)
        {
            x.GetComponent<ObjectManager>().OnShot();
        }
        yield return new WaitForEndOfFrame();
        index--;
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        yield return new WaitForEndOfFrame();
        Rect regionToRoad = new Rect(0, 0, Screen.width, Screen.height);
        screenCapture.ReadPixels(regionToRoad, 0, 0, false);
        screenCapture.Apply();
        GameObject myPhotoInstance = Instantiate(myPhoto, PhotoPosition.transform.position, transform.rotation * Quaternion.Euler(-70, 0, -180));
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        Renderer[] childs = myPhotoInstance.GetComponentsInChildren<Renderer>();
        foreach (Renderer child in childs)
        {
            if (child.transform.name == "Marco")
            {
                child.material.SetTexture("_BaseMap", photoSprite.texture);
                child.material.color = Color.white;
                child.material.SetFloat("_Smoothness", 1f);
            }
        }
        yield return new WaitForSeconds(coolDown);
        takingPhoto = false;
        yield break;
    }
}
