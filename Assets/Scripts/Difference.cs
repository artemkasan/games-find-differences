using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Difference : MonoBehaviour
{
    public int FoundItemIndex;

    public GameObject OppositeDifference;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                var collider = this.GetComponent<CircleCollider2D>();
                if (hit.collider == collider)
                {
                    SelectDifference();
                }
            }
        }
    }

    public void SelectDifference()
    {
        Debug.Log("Something was clicked!");
        var ownAnimator = GetComponent<Animator>();
        ownAnimator.SetBool("Selected", true);
        var oppositeAnimator = OppositeDifference.GetComponent<Animator>();
        oppositeAnimator.SetBool("Selected", true);
        Game.AddFoundItems(FoundItemIndex);
    }
}
