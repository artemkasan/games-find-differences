using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
	public Text FoundItemsText;
	public int TotalDifferences;
	public GameObject FinshContainer;

	public Animator FinishMenu;

	private static HashSet<int> foundItems = new HashSet<int>();
	private static bool animationRun = false;

	// Start is called before the first frame update
	void Start()
	{
		animationRun = false;
		foundItems.Clear();
	}

	// Update is called once per frame
	void Update()
	{
		FoundItemsText.text = foundItems.Count.ToString();
		if (!animationRun && foundItems.Count == TotalDifferences)
		{
			animationRun = true;
			var animators = FinshContainer.GetComponentsInChildren<Animator>();
			StartCoroutine(RunAnimation(animators));
		}
		else if (Input.GetMouseButtonDown(0) && foundItems.Count == TotalDifferences)
		{
			var animators = FinshContainer.GetComponentsInChildren<Animator>();
			foreach (Animator animator in animators)
			{
				animator.SetTrigger("ShowMenu");
			}
			FinishMenu.SetBool("Show", true);
		}
	}

	private IEnumerator RunAnimation(Animator[] animators)
	{
		foreach (Animator animator in animators)
		{
			yield return new WaitForSeconds(Random.Range(0.1f, 1.0f));
			animator.speed = Random.Range(1.0f, 1.3f);
			animator.SetTrigger("WinGame");
		}
	}

	public static void AddFoundItems(int itemIndex)
	{
		foundItems.Add(itemIndex);
	}
}
