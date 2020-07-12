using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ImageHover : MonoBehaviour
{
	private Material _normalMaterial;
	private bool _mouseDown = false;

	public Material HighlightMaterial;
	public Material ClickMaterial;

	public UnityEvent OnItemClick;

	private void Start()
	{
		var spriteRenderer = GetComponent<Image>();
		_normalMaterial = spriteRenderer.material;
	}

	private void OnMouseOver()
	{
		if (!_mouseDown)
		{
			var spriteRenderer = GetComponent<Image>();
			spriteRenderer.material = HighlightMaterial;
		}
		else
		{
			var spriteRenderer = GetComponent<Image>();
			spriteRenderer.material = ClickMaterial;
		}
	}

	void OnMouseExit()
	{
		var spriteRenderer = GetComponent<Image>();
		spriteRenderer.material = _normalMaterial;
		_mouseDown = false;
	}

	private void OnMouseDown()
	{
		_mouseDown = true;
		var spriteRenderer = GetComponent<Image>();
		spriteRenderer.material = ClickMaterial;
	}

	private void OnMouseUp()
	{
		if (_mouseDown)
		{
			var spriteRenderer = GetComponent<Image>();
			spriteRenderer.material = HighlightMaterial;
			_mouseDown = false;
			OnItemClick.Invoke();
		}
	}
}
