using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
	public Animator transition;

	public float transitionTime;

	private void Start()
	{
		StartCoroutine(PlayAudioSource());
	}

	public void ReplayScene()
	{
		Scene currentScene = SceneManager.GetActiveScene();
		SelectScene(currentScene.name);
	}

	public void NextScene()
	{
		Scene currentScene = SceneManager.GetActiveScene();
		int nextSceneIndex = currentScene.buildIndex + 1;
		if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
		{
			nextSceneIndex = 1;
		}
		SelectScene(nextSceneIndex);
	}

	public void GoHome()
	{
		SelectScene("Start");
	}

	public void SelectScene(string sceneName)
	{
		StartCoroutine(LoadScene(sceneName));
	}

	public void SelectScene(int buildIndex)
	{
		StartCoroutine(LoadScene(buildIndex));
	}

	public IEnumerator LoadScene(string sceneName)
	{
		transition.SetTrigger("Start");
		yield return new WaitForSeconds(transitionTime);

		SceneManager.LoadScene(sceneName);
	}

	public IEnumerator LoadScene(int buildIndex)
	{
		transition.SetTrigger("Start");
		yield return new WaitForSeconds(transitionTime);

		SceneManager.LoadScene(buildIndex);
	}

	public IEnumerator PlayAudioSource()
	{
		yield return new WaitForSeconds(transitionTime);

		var audioSource = GetComponent<AudioSource>();
		audioSource.Play();
	}
}
