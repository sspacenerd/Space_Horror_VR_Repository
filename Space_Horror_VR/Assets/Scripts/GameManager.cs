using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameObject fade;
    private void Start()
    {
        Fade(fade, 0, 1f);
    }

    public static void Fade(GameObject gameObjectToFade, float fadeAmount, float time)
    {
        gameObjectToFade.GetComponent<Image>().DOFade(fadeAmount, time);
    }
    public static IEnumerator ChangeScene(int scene)
    {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(scene);
        yield break;
    }
}
