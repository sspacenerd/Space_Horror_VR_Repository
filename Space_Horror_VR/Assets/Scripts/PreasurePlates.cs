using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PreasurePlates : MonoBehaviour
{
    public GameObject door;

    private void Update()
    {
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.name)
        {
            case "Flashlight":
                if (collision.gameObject.GetComponent<ObjectManager>().isTurned)
                {
                    StartCoroutine(OutOfEnergy());
                    collision.gameObject.GetComponent<ObjectManager>().Emission(collision.gameObject, 1, Color.black);
                    collision.gameObject.GetComponentInChildren<Light>().DOIntensity(0f, 1f);
                    collision.gameObject.GetComponent<ObjectManager>().isTurned = false;
                }
                break;
        }
    }
    IEnumerator OutOfEnergy()
    {
        door.transform.DOMove(new Vector3(door.transform.position.x, door.transform.position.y + 4, door.transform.position.z), 1f);
       // yield return new WaitForSeconds(10f);
        //door.transform.DOMove(new Vector3(door.transform.position.x, door.transform.position.y - 8, door.transform.position.z), 1f);
        yield break;
    }
    
}
