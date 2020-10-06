using UnityEngine;

[ExecuteInEditMode]
public class AlphaAnimation : MonoBehaviour
{
	public float Alpha = 1;
	private Material alphaMaterial;

	private void Start()
	{
		var spriteRenderer = this.GetComponent<SpriteRenderer>();
		if (spriteRenderer.sharedMaterial != null)
		{
			alphaMaterial = new Material(spriteRenderer.sharedMaterial);
			spriteRenderer.sharedMaterial = alphaMaterial;
		}
	}

	void Update()
	{
		if (alphaMaterial != null)
		{
			alphaMaterial.SetFloat("_Alpha", Alpha);
		}
		// var spriteRenderer = this.GetComponent<SpriteRenderer>();
		// if (spriteRenderer.sharedMaterial != null)
		// {
		// 	var material = new Material(spriteRenderer.sharedMaterial);
		// 	material.SetFloat("_Alpha", Alpha);
		// 	spriteRenderer.sharedMaterial = material;
		// }
	}
}

