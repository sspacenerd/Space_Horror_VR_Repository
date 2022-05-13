using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PreasurePlates : MonoBehaviour
{
    public GameObject door;
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.name)
        {
            case "Flashlight":
                if (collision.gameObject.GetComponent<OnVisible>().isTurned)
                {
                    StartCoroutine(OutOfEnergy());
                    collision.gameObject.GetComponent<OnVisible>().Emission(collision.gameObject, 3, Color.black);
                    collision.gameObject.GetComponent<OnVisible>().isTurned = false;
                }
                break;
        }
    }
    IEnumerator OutOfEnergy()
    {
        //door.transform.DORotate(new Vector3(-90, 0, -198.295f), 1f);
        yield return new WaitForSeconds(2f);
        Debug.Log("Close Door");
        yield break;
    }
    
}
