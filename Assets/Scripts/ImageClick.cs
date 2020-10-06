using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageClick : MonoBehaviour
{
	public void OnClick()
	{
		var audioSource = GetComponent<AudioSource>();
		if (audioSource != null)
		{
			audioSource.Play();
		}
	}
}
