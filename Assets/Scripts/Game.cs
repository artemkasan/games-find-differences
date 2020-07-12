using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
	public Text FoundItemsText;
	public int TotalDifferences;

	public UnityEvent OnMoveNext;

	public UnityEvent OnFinish;

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
			OnFinish?.Invoke();
		}
		else if (Input.GetMouseButtonDown(0) && foundItems.Count == TotalDifferences)
		{
			OnMoveNext?.Invoke();
		}
	}

	public static void AddFoundItems(int itemIndex)
	{
		foundItems.Add(itemIndex);
	}
}
