using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour
{
	[DllImport("__Internal")]
    private static extern bool allowGoHome();

	public Animator transition;

	public float transitionTime;

	public Button goHomeButton;
	private void Start()
	{
		try
		{
			goHomeButton.gameObject.SetActive(AllowtoGoHome());
		}
		catch {
			// Use default behavior if it is impossible to call plugin.
		}

		StartCoroutine(PlayAudioSource());
	}

	public void ReplayScene()
	{
		Scene currentScene = SceneManager.GetActiveScene();
		SelectScene(currentScene.name);
	}

	public void NextScene()
	{
		if(AllowtoGoHome())
		{
			Scene currentScene = SceneManager.GetActiveScene();
			int nextSceneIndex = currentScene.buildIndex + 1;
			if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
			{
				GoHome();
			}
			else
			{
				SelectScene(nextSceneIndex);
			}
		}
		else
		{
			ReplayScene();
		}
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

	private bool AllowtoGoHome()
	{
		try
		{
			return allowGoHome();
		}
		catch
		{
			return true;
		}
	}
}
