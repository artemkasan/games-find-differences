using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	public Animator transition;

	public float transitionTime;

	public void SelectScene(string sceneName)
	{
		StartCoroutine(LoadScene(sceneName));
	}

	public IEnumerator LoadScene(string sceneName)
	{
		transition.SetTrigger("Start");
		yield return new WaitForSeconds(transitionTime);

		SceneManager.LoadScene(sceneName);
	}
}
