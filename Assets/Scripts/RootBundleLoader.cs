using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class RootBundleLoader : MonoBehaviour
{

    [DllImport("__Internal")]
    private static extern string getBaseUrl();

    public string BundleName;

    public uint Version;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadBundleAsync());        
    }

    public static string GetBundlesUrl()
    {
        try
        {
            return getBaseUrl();
        }
        catch
        {
            return "http://localhost:3000/games/find-differences";
        }
    }

    private IEnumerator LoadBundleAsync()
    {
        var baseUrl = RootBundleLoader.GetBundlesUrl();
        using (UnityWebRequest uwr = UnityWebRequestAssetBundle.GetAssetBundle(
            $"{baseUrl}/{BundleName}.unity3d", Version, 0))
        {
            yield return uwr.SendWebRequest();

            if (uwr.isNetworkError || uwr.isHttpError)
            {
                Debug.Log(uwr.error);
            }
            else
            { 
                // Get downloaded asset bundle
                var bundle = DownloadHandlerAssetBundle.GetContent(uwr);
                var bundleImages = GetComponentsInChildren<BundleImage>();
                foreach(var bundleImage in bundleImages)
                {
                    var originalAssetRequest = bundle.LoadAssetAsync<Sprite>(bundleImage.BundleName);
                    yield return originalAssetRequest;
                    var image = bundleImage.GetComponent<Image>();
                    image.sprite = originalAssetRequest.asset as Sprite;
                }
                bundle.Unload(false);
            }
        }        
    }
}
