using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class baloon : MonoBehaviour
{
	private float initPositionX;
	private float initPositionY;
	public float PositionX;
	public float PositonY;

	// Start is called before the first frame update
	void Start()
	{
		initPositionX = this.transform.position.x;
		initPositionY = this.transform.position.y;
	}

	// Update is called once per frame
	void Update()
	{
		this.transform.position = new Vector3(
			initPositionX + PositionX,
			initPositionY + PositonY,
			this.transform.position.z
		);
	}
}
