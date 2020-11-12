using System;
using UnityEngine;

public class CameraPosition : MonoBehaviour
{
	public float DefaultWidth;

	public float DefaultHeight;

	private float initialOrthographicSize;
	// Start is called before the first frame update
	void Start()
	{
		initialOrthographicSize = Camera.main.orthographicSize;
		Debug.Log($"Default height: {Screen.height}, Width: {Screen.width}");
	}

	// Update is called once per frame
	void Update()
	{
		if (Camera.main.aspect < DefaultWidth / DefaultHeight)
		{
			Camera.main.orthographicSize = initialOrthographicSize * (DefaultWidth / DefaultHeight) / Camera.main.aspect;
		}
		else
		{
			Camera.main.orthographicSize = initialOrthographicSize;
		}
	}
}
