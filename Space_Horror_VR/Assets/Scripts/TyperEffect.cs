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

	IEnumerator StartText()
    {
		PlayTextToType("Despierta ya! Llevo media hora intentando encontrarte", false, 1f);
		yield return new WaitForSeconds(5f);
		PlayTextToType("No encuentro a nadie en la nave, un asteroide rompió el ala Este y se llevó a unos cuantos...", false, 2f);
		yield return new WaitForSeconds(7f);
		PlayTextToType("Necesito que reactives el reactor restante... a ver si ponemos en marcha la nave de nuevo", false, 2f);
		yield return new WaitForSeconds(7f);
		PlayTextToType("Recuerda que tu camara interactua con los objetos, utilizala para prender la lampara y salir de la sala", false, 2f);

	}
}
