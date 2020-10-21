using UnityEngine;
using UnityEngine.EventSystems;

public class ImageArea : MonoBehaviour, IPointerClickHandler
{
	public GameObject WrongObject;

	public void OnPointerClick(PointerEventData eventData)
	{
		if (Game.GameCompleted())
		{
			return;
		}

		Vector3 clickPosition = eventData.position;
		Vector3 mousePos = Camera.main.ScreenToWorldPoint(clickPosition);
		Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

		RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
		if (hit.collider != null)
		{
			var collider = this.GetComponent<BoxCollider2D>();
			if (hit.collider == collider)
			{
				WrongObject.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
				var animator = WrongObject.GetComponent<Animator>();
				animator.SetTrigger("Missed");
				var audioSource = WrongObject.GetComponent<AudioSource>();
				audioSource.Play();
			}
		}
	}
}

