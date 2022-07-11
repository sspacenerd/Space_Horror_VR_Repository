using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Intro : MonoBehaviour
{
    public CanvasGroup Inputs, madeBy;
    public TextMeshProUGUI Awake;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(IntroCoroutine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator IntroCoroutine()
    {
        yield return new WaitForSeconds(3);
        Inputs.DOFade(1, 3f);
        yield return new WaitForSeconds(7);
        Inputs.DOFade(0, 2);
        yield return new WaitForSeconds(2);
        madeBy.DOFade(1, 2);
        yield return new WaitForSeconds(3);
        madeBy.DOFade(0, 2);
        yield return new WaitForSeconds(3);
        Awake.DOFade(1, 1f);
        yield return new WaitForSeconds(4f);
        Awake.DOFade(0, 1f);
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
        yield break;
    }
}
