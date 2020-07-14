using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageArea : MonoBehaviour
{
	public GameObject WrongObject;

	// Start is called before the first frame update
	void Start()
	{

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
				var collider = this.GetComponent<BoxCollider2D>();
				if (hit.collider == collider)
				{
					WrongObject.transform.position = new Vector3(mousePos.x, mousePos.y, 0);
					var animator = WrongObject.GetComponent<Animator>();
					animator.SetTrigger("Missed");
				}
			}
		}
	}
}

