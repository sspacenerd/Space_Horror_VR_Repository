using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Printer : MonoBehaviour
{
    public static bool didIShot;
    int index = 5;
    bool takingPhoto;
    [Header("PhotoTaker")]
    [SerializeField] private GameObject myPhoto;
    [SerializeField] private AudioSource photoAudio, noShotsLeft;
    private Texture2D screenCapture;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (!takingPhoto && index > 0)
            {
                StartCoroutine(TakePhoto(1f));
                photoAudio.Play();
            }
            else if(index <= 0)
            {
                noShotsLeft.Play();
            }
        }
    }
    public IEnumerator TakePhoto(float coolDown)
    {
        takingPhoto = true;
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Interactable");
        foreach(var x in objects)
        {
            x.GetComponent<OnVisible>().Visibility();
        }
        yield return new WaitForEndOfFrame();
        index--;
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        yield return new WaitForEndOfFrame();
        Rect regionToRoad = new Rect(0, 0, Screen.width, Screen.height);
        screenCapture.ReadPixels(regionToRoad, 0, 0, false);
        screenCapture.Apply();
        GameObject myPhotoInstance = Instantiate(myPhoto, transform.position = new Vector3(0, 0, -94f), transform.rotation * Quaternion.Euler(-145f, 0, 0));
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 100.0f);
        Renderer[] childs = myPhotoInstance.GetComponentsInChildren<Renderer>();
        foreach(Renderer child in childs)
        {
            if(child.transform.name == "Marco")
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
