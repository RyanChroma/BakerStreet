using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour
{
	public static bool TravelMenu = false;
	public GameObject travelMenuUI;

	public void ChangeScene(string sceneName)
	{
		if(Time.timeScale == 0)
		{
			Time.timeScale = 1;
		}
		SceneManager.LoadScene (sceneName);
	}

	public static void ForceChangeScene(string sceneName)
	{
		if(Time.timeScale == 0)
		{
			Time.timeScale = 1;
		}
		SceneManager.LoadScene (sceneName);
	}

	public void Resume()
    {
        travelMenuUI.SetActive(false);
        Time.timeScale = 1f;
        TravelMenu = false;
    }

	public void Exit()
	{
		Application.Quit ();
	}
}