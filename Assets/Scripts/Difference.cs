using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.EventSystems;

public class Difference : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern string language();

	private AudioClip[] _currentAudioClips = new AudioClip[0];
	public int FoundItemIndex;

	public GameObject OppositeDifference;

	public AudioClip[] RussianFoundAudioClip;
	public AudioClip[] EnglishFoundAudioClip;


    void Start()
    {
        var audio = GetComponent<AudioSource>();
        try
        {
            var lang = language();
            if(lang.ToLowerInvariant().StartsWith("ru"))
            {
                _currentAudioClips = RussianFoundAudioClip;
            }
            else
            {
                _currentAudioClips = EnglishFoundAudioClip;
            }
        }
        catch
        {
            _currentAudioClips = EnglishFoundAudioClip;
        }
	}

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
			int index = Random.Range(0, _currentAudioClips.Length);
			audioSource.clip = _currentAudioClips[index];

			if (!Game.GameCompleted())
			{
				audioSource.Play();
			}
		}
	}
}
