using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger : MonoBehaviour
{
    public GameObject undead, undead2;
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

        if (collision.transform.tag == "Player")
        {
            StartCoroutine(Wait());     
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2f);
        undead.SetActive(true);
        undead2.SetActive(true);
        yield break;
    }
}
