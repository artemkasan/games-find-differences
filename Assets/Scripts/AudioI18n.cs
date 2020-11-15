using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class AudioI18n : MonoBehaviour
{
    public AudioClip EnglishAudio;
    public AudioClip RussianAudio;

    [DllImport("__Internal")]
    private static extern string language();

    // Start is called before the first frame update
    void Start()
    {
        var audio = GetComponent<AudioSource>();
        try
        {
            var lang = language();
            if(lang.ToLowerInvariant().StartsWith("ru"))
            {
                audio.clip = RussianAudio;
            }
            else
            {
                audio.clip = EnglishAudio;
            }
        }
        catch
        {
            audio.clip = EnglishAudio;
        }
    }
}
