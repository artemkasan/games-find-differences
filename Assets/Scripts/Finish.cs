using System.Collections;
using UnityEngine;

public class Finish : MonoBehaviour
{
	public GameObject Baloon;
	public Material[] Materials;
	public Vector2 StartPosition;

	public int BaloonsCount;

	private void Start()
	{
		//		ShowBaloons();
	}

	public void ShowBaloons()
	{
		for (int i = 0; i < BaloonsCount; i++)
		{
			var newBaloon = CreateBaloon();
		}
	}

	public void FlyBaloons()
	{
		StartCoroutine(StartFlyBaloons());
	}

	public void HideBaloons()
	{
		var animators = GetComponentsInChildren<Animator>();
		foreach (Animator animator in animators)
		{
			animator.SetTrigger("Hide");
		}
	}

	private IEnumerator StartFlyBaloons()
	{
		ShowBaloons();

		var animators = GetComponentsInChildren<Animator>();
		foreach (Animator animator in animators)
		{
			yield return new WaitForSeconds(Random.Range(0.1f, 0.01f));
			animator.speed = Random.Range(1.0f, 1.3f);
			animator.SetTrigger("Fly");
		}
	}

	private GameObject CreateBaloon()
	{
		float posX = Random.Range(StartPosition.x, StartPosition.y);
		var position = new Vector3(posX, -349.0f, 0.0f);
		var newBaloon = Instantiate(Baloon);
		newBaloon.transform.SetParent(transform);
		newBaloon.transform.localPosition = position;
		newBaloon.transform.localScale = new Vector3(90, 90, 1);
		int materialIndex = Random.Range(0, Materials.Length);
		var spriteRenderer = newBaloon.GetComponentInChildren<SpriteRenderer>();
		spriteRenderer.material = Materials[materialIndex];
		return newBaloon;
	}
}
