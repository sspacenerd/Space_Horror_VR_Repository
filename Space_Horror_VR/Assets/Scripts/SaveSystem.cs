using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] private GameObject playerPos, cameraPos;
    [SerializeField] public int teleport;
    // Start is called before the first frame update

    private void Awake()
    {
        if (GameScenesManager.hasTraveled)
        {
            LoadData();
        }
    }
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

   public void SaveData()
    {
        ES3.Save("playerPos", playerPos.transform.position);
        //ES3.Save("cameraPos", cameraPos.transform.position);
        ES3.Save("hasTraveled", GameScenesManager.hasTraveled);
        ES3.Save("Triggered", SoundManager.Triggered);
        //ES3.Save("material", teleport);
    }

    public void LoadData()
    {
        playerPos.transform.position = ES3.Load<Vector3>("playerPos");
        //cameraPos.transform.position = ES3.Load<Vector3>("cameraPos");
        GameScenesManager.hasTraveled = ES3.Load<bool>("hasTraveled");
        SoundManager.Triggered = ES3.Load<bool>("Triggered");
        //teleport = ES3.Load<int>("material");

    }
}
