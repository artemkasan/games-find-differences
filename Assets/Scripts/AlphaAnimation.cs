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
			spriteRenderer.material = alphaMaterial;
		}
	}

	void Update()
	{
		if (alphaMaterial != null)
		{
			alphaMaterial.SetFloat("_Alpha", Alpha);
		}
	}
}

