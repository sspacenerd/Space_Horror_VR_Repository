using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PhotoCapture : MonoBehaviour
{
    [Header("PhotoTaker")]
    [SerializeField] private Image photoDisplayArea;
    private Texture2D screenCapture;
   
    private void Start()
    {
        screenCapture = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
    }
    private void Update()
    {
        
    }

    public IEnumerator CapturePhoto()
    {
        yield return new WaitForEndOfFrame();

        Rect regionToRoad = new Rect(0, 0, Screen.width, Screen.height);

        screenCapture.ReadPixels(regionToRoad, 0, 0, false);
        screenCapture.Apply();
        ShowPhoto();
          
    }
    void ShowPhoto()
    {
        Sprite photoSprite = Sprite.Create(screenCapture, new Rect(0.0f, 0.0f, screenCapture.width, screenCapture.height), new Vector2(0.5f, 0.5f), 1000.0f);
        photoDisplayArea.sprite = photoSprite;
    }
}
