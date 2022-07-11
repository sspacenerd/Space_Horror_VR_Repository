using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject fade;
    [SerializeField] GameObject lift;
    public SaveSystem mySave;
    public static bool hasTraveled;
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
        switch (collision.transform.name)
        {
            case "Portal":
                {
                    if (!hasTraveled)
                    {
                        GameManager.Fade(fade, 1, 1);
                        hasTraveled = true;
                        mySave.SaveData();
                        StartCoroutine(GameManager.ChangeScene(1));
                    }
                    break;
                }
            case "Lift":
                {
                    if(LocationSnap.liftSender == true && LocationSnap.liftSender2)
                    {
                        lift.GetComponent<Animator>().SetBool("Second", true);
                    }
                    break;
                }
        }
    }
}
