using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class GenerateMenu : MonoBehaviour
{
    public List<string> Items;

    public LevelLoader LevelLoader;

    public GameObject ItemPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        
        for (int i = 0; i < Items.Count; i++)
        {
            var item = Items[i];
            var xPos = i % 2 == 0 ? -190 : 190;
            var yPos = -143 - (i / 2)* 251;
            var newObject = Instantiate(ItemPrefab, this.transform);
            var rectTransform = newObject.GetComponent<RectTransform>();
            rectTransform.anchorMin = new Vector2(0.5f, 1);
            rectTransform.anchorMax = new Vector2(0.5f, 1);
            rectTransform.anchoredPosition3D = new Vector3( xPos, yPos, 0);

            var button = newObject.GetComponentInChildren<Button>();
            UnityAction prefabClick = () => LevelLoader.SelectScene(item);
            button.onClick.AddListener(prefabClick);
            var bundleImage = newObject.GetComponentInChildren<BundleImage>();
            bundleImage.BundleName = item;
        }
    }

}
