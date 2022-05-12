using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PreasurePlates : MonoBehaviour
{
    public GameObject door_1, door_2, test;
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Flashlight":
                if (collision.gameObject.GetComponent<OnVisible>().isTurned)
                {
                    door_1.transform.DORotate(new Vector3(-90, 0, -198.295f), 1f);
                }
                break;
        }
    }
}
