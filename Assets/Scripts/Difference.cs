using UnityEngine;
using UnityEngine.EventSystems;

public class Difference : MonoBehaviour
{
	public int FoundItemIndex;

	public GameObject OppositeDifference;

	public AudioClip[] FoundAudioClip;

	public void SelectDifference()
	{
		if (Game.GameCompleted())
		{
			return;
		}

		var ownAnimator = GetComponent<Animator>();
		if (!ownAnimator.GetBool("Selected"))
		{
			ownAnimator.SetBool("Selected", true);
			var oppositeAnimator = OppositeDifference.GetComponent<Animator>();
			oppositeAnimator.SetBool("Selected", true);
			Game.AddFoundItems(FoundItemIndex);
			var audioSource = GetComponent<AudioSource>();
			int index = Random.Range(0, FoundAudioClip.Length);
			audioSource.clip = FoundAudioClip[index];

			if (!Game.GameCompleted())
			{
				audioSource.Play();
			}
		}
	}
}
