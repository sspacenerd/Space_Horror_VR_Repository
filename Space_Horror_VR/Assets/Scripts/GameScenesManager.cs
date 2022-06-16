using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class GameScenesManager : MonoBehaviour
{
    [SerializeField] private GameObject fade;
    [SerializeField] private int scene;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.tag == "Player" && this.transform.tag == "Portal")
        {
            GameManager.Fade(fade, 1, 1);
            StartCoroutine(GameManager.ChangeScene(scene));
        }
        if(collision.transform.tag == "Player" && LocationSnap.liftSender == true)
        {
            Debug.Log("1");
            //aqui va el cambio de escena
        }
    }
}
