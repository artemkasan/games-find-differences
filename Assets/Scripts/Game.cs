using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Game : MonoBehaviour
{
    public Text FoundItemsText;

    private static HashSet<int> foundItems = new HashSet<int>();

    // Start is called before the first frame update
    void Start()
    {
        foundItems.Clear();
    }

    // Update is called once per frame
    void Update()
    {
        FoundItemsText.text = foundItems.Count.ToString();
    }

    public static void AddFoundItems(int itemIndex)
    {
        foundItems.Add(itemIndex);
    }
}
