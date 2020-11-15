using System;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class StringI18n : MonoBehaviour
{
    public string Key;
    public int Count;

    [DllImport("__Internal")]
    private static extern string t(string key, int count);

    // Start is called before the first frame update
    void Start()
    {
        var textComponent = GetComponent<Text>();
        textComponent.text = t(Key, Count);
    }
}
