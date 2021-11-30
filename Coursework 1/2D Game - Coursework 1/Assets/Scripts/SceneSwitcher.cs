using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour {

	[SerializeField] private string newLevel;
	[SerializeField] private GameObject uiElement;
	private bool isStoodOverDoor = false;


	void Start()
	{
		uiElement.SetActive(false);

	}

	void Update()
    {
		SwitchScenes();
    }

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
        {
			//Make it aware that the user is stood over the door
			isStoodOverDoor = true;

			//Make a UI appear
			uiElement.SetActive(true);
		}
	}

	private void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			uiElement.SetActive(false);
			isStoodOverDoor = false;
		}
    }

	private void SwitchScenes()
    {
		//Button Press
		if (Input.GetKeyDown(KeyCode.Return) && isStoodOverDoor)
		{
			SceneManager.LoadScene(newLevel);
		}
	}
}
