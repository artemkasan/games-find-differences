using UnityEngine;

[ExecuteInEditMode]
public class AlphaAnimation : MonoBehaviour
{
	public float Alpha = 1;

	void Update()
	{
		var spriteRenderer = this.GetComponent<SpriteRenderer>();
		if (spriteRenderer.sharedMaterial != null)
		{
			var material = new Material(spriteRenderer.sharedMaterial);
			material.SetFloat("_Alpha", Alpha);
			spriteRenderer.sharedMaterial = material;
		}
	}
}

