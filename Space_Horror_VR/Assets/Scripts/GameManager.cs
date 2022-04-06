using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject fadeGameObject;
    // Start is called before the first frame update
    void Start()
    {
        Fade(0, 1f);
    }
    // Update is called once per frame
    void Update()
    {
        
    }
    public void Fade(float fadeAmount, float time)
    {
        fadeGameObject.GetComponent<Image>().DOFade(fadeAmount, time);
    }
}
