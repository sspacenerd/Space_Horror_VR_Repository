using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class GameScenesManager : MonoBehaviour
{
    [SerializeField] private GameObject fade;
    [SerializeField] private int scene;
    public static bool hasTraveled;
    public GameObject lift;
    public SaveSystem mySave;
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
        if(collision.transform.tag == "Player" && this.transform.tag == "Portal" && !hasTraveled)
        {
            GameManager.Fade(fade, 1, 1);
            hasTraveled = true;
            mySave.SaveData();
            StartCoroutine(GameManager.ChangeScene(scene));
        }
        if(collision.transform.tag == "Player" && LocationSnap.liftSender == true)
        {
            lift.transform.Translate(new Vector3(lift.transform.position.x, -98.42f, lift.transform.position.z));
        }
    }
}
