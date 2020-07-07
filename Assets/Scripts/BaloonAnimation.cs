using UnityEngine;

[ExecuteInEditMode]
public class BaloonAnimation : MonoBehaviour
{
	public float Alpha = 1;

	void Update()
	{
		var animation = this.GetComponent<SpriteRenderer>();
		animation.sharedMaterial.SetFloat("_Alpha", Alpha);
	}
}
