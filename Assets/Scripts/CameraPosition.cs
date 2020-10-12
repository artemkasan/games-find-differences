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
		// var currentHeight = Camera.main.orthographicSize;
		// var currentWidth = Camera.main.orthographicSize * Camera.main.aspect;
		// var heightDiff = Mathf.Abs(defaultHeight - currentHeight);
		// var widthDiff = Mathf.Abs(defaultWidth - currentWidth);
		// if (heightDiff > widthDiff)
		// {
		// 	Camera.main.orthographicSize = defaultWidth / Camera.main.aspect;
		// }
		// else
		// {
		// 	Camera.main.orthographicSize = defaultHeight;
		// }
		// if (MaintainWidth)
		// {
		// 	Camera.main.orthographicSize = defaultWidth / Camera.main.aspect;
		// 	Camera.main.transform.position = new Vector3(
		// 		cameraPos.x,
		// 		AdaptPosition * (defaultWidth - Camera.main.orthographicSize),
		// 		cameraPos.z);
		// 	Debug.Log("Maintain width");
		// }
		// else
		// {
		// 	Camera.main.transform.position = new Vector3(
		// 		AdaptPosition * (defaultWidth - Camera.main.orthographicSize),
		// 		cameraPos.y,
		// 		cameraPos.z);
		// 	Debug.Log("Maintain height");
		// }
	}
}
