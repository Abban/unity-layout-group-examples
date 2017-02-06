using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class Samples : MonoBehaviour
{
	[Header("Dynamic List")]
	public Transform listParent; 
	public GameObject listItemPrefab;

	[Header("Modal")]
	public CanvasGroup modal;
	public float speed = 1f;



	/**
	 * Add a new list item to the dynamic list
	 * 
	 */
	public void AddListItem()
	{
		Instantiate(listItemPrefab, listParent, false);
	}



	/**
	 * Show the modal
	 * 
	 */
	public void ShowModal()
	{
		StartCoroutine("FadeModalIn");
	}



	/**
	 * Hide the modal
	 * 
	 */
	public void HideModal()
	{
		StartCoroutine("FadeModalOut");
	}



	/**
	 * Preforms the modal fade in
	 * 
	 */
	private IEnumerator FadeModalIn()
	{
		modal.blocksRaycasts = true;
		modal.interactable   = true;
		
		while(modal.alpha < 1) {
			modal.alpha += Time.deltaTime * speed;
			yield return null;
		}
	}



	/**
	 * Performs the modal fade out
	 * 
	 */
	private IEnumerator FadeModalOut()
	{
		while(modal.alpha > 0){
			modal.alpha -= Time.deltaTime * speed;
			yield return null;
		}

		modal.blocksRaycasts = false;
		modal.interactable   = false;
	}
}