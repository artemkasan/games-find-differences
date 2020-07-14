using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Difference : MonoBehaviour
{
	public int FoundItemIndex;

	public GameObject OppositeDifference;

	public AudioClip[] FoundAudioClip;
	private int[] _playOrder = new int[0];
	private int _currentIndex = 0;

	// Start is called before the first frame update
	void Start()
	{
		var currentClips = new List<int>(Enumerable.Range(0, FoundAudioClip.Length));
		_playOrder = new int[FoundAudioClip.Length];
		for (int i = 0; i < FoundAudioClip.Length; i++)
		{
			int index = Random.Range(0, currentClips.Count);
			_playOrder[i] = currentClips[index];
			currentClips.RemoveAt(index);
		}
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
		{
			Vector3 clickPosition = Input.mousePosition;
			if (Input.touchCount > 0)
			{
				clickPosition = Input.touches[0].position;
			}

			Vector3 mousePos = Camera.main.ScreenToWorldPoint(clickPosition);
			Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

			RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
			if (hit.collider != null)
			{
				var collider = this.GetComponent<CircleCollider2D>();
				if (hit.collider == collider)
				{
					SelectDifference();
				}
			}
		}
	}

	public void SelectDifference()
	{
		var ownAnimator = GetComponent<Animator>();
		ownAnimator.SetBool("Selected", true);
		var oppositeAnimator = OppositeDifference.GetComponent<Animator>();
		oppositeAnimator.SetBool("Selected", true);
		Game.AddFoundItems(FoundItemIndex);
		var audioSource = GetComponent<AudioSource>();
		audioSource.clip = FoundAudioClip[_playOrder[_currentIndex]];
		_currentIndex++;
		if (_currentIndex == _playOrder.Length)
		{
			_currentIndex = 0;
		}
		audioSource.Play();
	}
}
