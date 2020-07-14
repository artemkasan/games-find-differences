using UnityEngine;

[ExecuteInEditMode]
public class AlphaAnimation : MonoBehaviour
{
	public float Alpha = 1;

	void Update()
	{
		var spriteRenderer = this.GetComponent<SpriteRenderer>();
		var material = new Material(spriteRenderer.sharedMaterial);
		material.SetFloat("_Alpha", Alpha);
		spriteRenderer.sharedMaterial = material;
	}
}
