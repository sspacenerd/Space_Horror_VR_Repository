using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PreasurePlates : MonoBehaviour
{
    public GameObject door_1, door_2, test;
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
        switch (collision.gameObject.name)
        {
            case "Flashlight":
                if (InteractionManager.isTurned)
                {
                    door_1.transform.DORotate(new Vector3(-90, 0, -198.295f), 1f);
                }
                break;
            case "Box":
                {
                    InteractionManager.Emission(test, 3f, Color.green);
                    door_2.transform.DORotate(new Vector3(-90, 0, -4), 1f);
                    break;
                }
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        switch (collision.gameObject.name)
        {
            case "Flashlight":
                if (InteractionManager.isTurned == false)
                {
                    door_1.transform.DORotate(new Vector3(-90, 0, -270f), 1f);
                }
                break;
            case "Box":
                {
                    InteractionManager.Emission(test, 3f, Color.red);
                    door_2.transform.DORotate(new Vector3(-90, 0, -90), 1f);
                    break;
                }
        }
    }
}
