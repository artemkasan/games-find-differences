using UnityEngine;

public class Difference : MonoBehaviour
{
	public int FoundItemIndex;

	public GameObject OppositeDifference;

	public AudioClip[] FoundAudioClip;

	private void OnMouseDown()
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

	// Update is called once per frame
	void Update()
	{
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
			int index = Random.Range(0, FoundAudioClip.Length);
			audioSource.clip = FoundAudioClip[index];

			if (!Game.GameCompleted())
			{
				audioSource.Play();
			}
		}
	}
}
