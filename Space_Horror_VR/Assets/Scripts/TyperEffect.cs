using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TyperEffect : MonoBehaviour
{
	public GameObject textBox;
	private TextMeshProUGUI txt;
	private bool condition = true;
    public void PlayTextToType(string textToType, bool conditionToWait, float timeToWait)
    {
		StartCoroutine(PlayText(textToType, conditionToWait, timeToWait));
    }
	IEnumerator PlayText(string st, bool conditionToWait, float timeToWait)
	{
		if (conditionToWait)
		{
			yield return new WaitForSeconds(timeToWait);
		}
		if (condition)
		{
			textBox.SetActive(true);
			condition = false;
			txt = GetComponent<TextMeshProUGUI>();
			foreach (char c in st)
			{ 
				txt.text += c;
				yield return new WaitForSeconds(0.05f);
			}
			yield return new WaitForSeconds(1f);
			condition = true;
			txt.text = "";
			textBox.SetActive(false);
		}
		yield break;
	}

	public IEnumerator StartTextCoroutine()
    {
		Debug.Log("s");
		PlayTextToType("¿Hola? Hay alguien ahí?", false, 1f);
		yield return new WaitForSeconds(3.5f);
		PlayTextToType("Hey! Te veo!!", false, 2f);
		yield return new WaitForSeconds(2.5f);
		PlayTextToType("Finalmente.. He estado buscando a alguien por tanto tiempo", false, 2f);
		yield return new WaitForSeconds(5f);
		PlayTextToType("Algo paso... no sabemos nada sobre el area de navegacion y el ascensor esta atascado en tu area... No se como arreglarlo, soy el de seguridad, viendote por las camaras", false, 2f);
		yield return new WaitForSeconds(13f);
		PlayTextToType("Necesitamos arreglar el elevador para llegar a la sala de navegacion", false, 2f);
	}

	public void StartText()
    {
		StartCoroutine(StartTextCoroutine());
    }
}
