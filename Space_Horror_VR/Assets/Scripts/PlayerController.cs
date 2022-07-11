using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject fade;
    [SerializeField] GameObject lift, liftCol;
    public SaveSystem mySave;
    public static bool hasTraveled;
    public AudioSource[] sounds;
    public CanvasGroup mission;
    public TextMeshProUGUI thanks;
    public static bool Triggered;
    public TyperEffect typerEffect;
    public AudioSource liftAudio, scary_1, scary_2;
    bool scary1 = true, scary2 = true;
    // Start is called before the first frame update
    private void Awake()
    {
        if (hasTraveled)
        {
            mySave.LoadData();
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        switch (collision.transform.name)
        {
            case "Mission":
                {
                    Triggered = true;
                    break;
                }
        }
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
                        StartCoroutine(Lift());
                    }
                    break;
                }
            case "Mission":
                {
                    if (!Triggered)
                    {
                        StartCoroutine(Sounds());
                    }
                    break;
                }
            case "Scary_1":
                {
                    if (scary1)
                    {
                        scary_1.PlayDelayed(Random.Range(1, 3f));
                        scary1 = false;
                    }
                    break;
                }
            case "Scary_2":
                {
                    if (scary2)
                    {
                        scary_2.PlayDelayed(Random.Range(1, 5f));
                        scary2 = false;
                    }
                    break;
                }
        }
    }
    IEnumerator Sounds()
    {
        yield return new WaitForSeconds(2f);
        typerEffect.StartText();
        sounds[0].Play();
        yield return new WaitForSeconds(3.5f);
        sounds[1].Play();
        yield return new WaitForSeconds(2.5f);
        sounds[2].Play();
        yield return new WaitForSeconds(5f);
        sounds[3].Play();
        yield return new WaitForSeconds(13f);
        sounds[4].Play();
        yield return new WaitForSeconds(3f);
        mission.DOFade(1, 1f);
        yield break;
    }
    IEnumerator Lift()
    {
        liftAudio.PlayDelayed(0.7f);
        yield return new WaitForSeconds(1.2f);
        lift.GetComponent<Animator>().SetBool("Second", true);
        liftCol.GetComponent<BoxCollider>().enabled = true;
        yield return new WaitForSeconds(5);
        GameManager.Fade(fade, 1, 4f);
        yield return new WaitForSeconds(4f);
        thanks.DOFade(1, 2f);
        yield break;
    }
}
