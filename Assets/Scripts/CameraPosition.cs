using UnityEngine;

public class CameraPosition : MonoBehaviour
{
	public float DefaultOrthographicSize;
	public float DefaultAspect;
	public bool MaintainWidth = true;
	[Range(-1, 1)]
	public int AdaptPosition;

	private float defaultWidth;
	private float defaultHeight;
	private Vector3 cameraPos;



	// Start is called before the first frame update
	void Start()
	{
		cameraPos = Camera.main.transform.position;

		defaultHeight = Camera.main.orthographicSize;
		defaultWidth = Camera.main.orthographicSize * Camera.main.aspect;
	}

	// Update is called once per frame
	void Update()
	{
		if (Camera.main.aspect < DefaultAspect)
		{
			Camera.main.orthographicSize = DefaultOrthographicSize * DefaultAspect / Camera.main.aspect;

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
