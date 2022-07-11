using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SaveSystem : MonoBehaviour
{
    [SerializeField] private GameObject playerPos, cameraPos, cube1, cube2;
    [SerializeField] public int teleport;
    // Start is called before the first frame update

    private void Awake()
    {
        if (GameScenesManager.hasTraveled)
        {
            LoadData();
        }
    }
   public void SaveData()
   {
        ES3.Save("playerPos", playerPos.transform.position);
        ES3.Save("cube1Pos", cube1.transform.position);
        ES3.Save("cube2Pos", cube2.transform.position);
        //ES3.Save("cameraPos", cameraPos.transform.position);
        ES3.Save("hasTraveled", GameScenesManager.hasTraveled);
        ES3.Save("Triggered", PlayerController.Triggered);
        //ES3.Save("material", teleport);
   }

    public void LoadData()
    {
        playerPos.transform.position = ES3.Load<Vector3>("playerPos");
        cube1.transform.position = ES3.Load<Vector3>("cube1Pos");
        cube2.transform.position = ES3.Load<Vector3>("cube2Pos");
        //cameraPos.transform.position = ES3.Load<Vector3>("cameraPos");
        GameScenesManager.hasTraveled = ES3.Load<bool>("hasTraveled");
        PlayerController.Triggered = ES3.Load<bool>("Triggered");
        //teleport = ES3.Load<int>("material");

    }
}
