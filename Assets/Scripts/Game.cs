using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
	public Text FoundItemsText;
	public int TotalDifferences;
	public GameObject FinshContainer;

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
			foreach (Animator animator in animators)
			{
				StartCoroutine(RunAnimation(animator));
			}
		}
	}

	private IEnumerator RunAnimation(Animator animator)
	{
		yield return new WaitForSeconds(Random.Range(0, 2));
		animator.speed = Random.Range(0.5f, 2.3f);
		animator.SetBool("Win", true);
	}

	public static void AddFoundItems(int itemIndex)
	{
		foundItems.Add(itemIndex);
	}
}
