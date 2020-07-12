using System;
using UnityEngine;
using UnityEngine.Events;

public class SpriteHover : MonoBehaviour
{
	private Material _normalMaterial;
	private bool _mouseDown = false;

	public Material HighlightMaterial;
	public Material ClickMaterial;

	public UnityEvent OnItemClick;

	private void Start()
	{
		var spriteRenderer = GetComponent<SpriteRenderer>();
		_normalMaterial = spriteRenderer.material;
	}

	private void OnMouseOver()
	{
		if (!_mouseDown)
		{
			var spriteRenderer = GetComponent<SpriteRenderer>();
			spriteRenderer.material = HighlightMaterial;
		}
		else
		{
			var spriteRenderer = GetComponent<SpriteRenderer>();
			spriteRenderer.material = ClickMaterial;
		}
	}

	void OnMouseExit()
	{
		var spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.material = _normalMaterial;
		_mouseDown = false;
	}

	private void OnMouseDown()
	{
		_mouseDown = true;
		var spriteRenderer = GetComponent<SpriteRenderer>();
		spriteRenderer.material = ClickMaterial;
	}

	private void OnMouseUp()
	{
		if (_mouseDown)
		{
			var spriteRenderer = GetComponent<SpriteRenderer>();
			spriteRenderer.material = HighlightMaterial;
			_mouseDown = false;
			OnItemClick.Invoke();
		}
	}
}
