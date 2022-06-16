using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SoundManager : MonoBehaviour
{
    public AudioSource[] sounds;
    public CanvasGroup mission;
    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {

    }
    IEnumerator Sounds()
    {
        yield return new WaitForSeconds(2f);
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
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            StartCoroutine(Sounds());
        }
    }
}
