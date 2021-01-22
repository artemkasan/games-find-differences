using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LoadBundle : MonoBehaviour
{
    public SpriteRenderer OriginalRenderer;
    public SpriteRenderer ChangedRendrer;

    public string BundleName;

    public uint Version;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadBundleAsync());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator LoadBundleAsync()
    {
        while(!Caching.ready)
        {
            yield return null;
        }
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
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(uwr);
                var originalAssetRequest = bundle.LoadAssetAsync<Sprite>("Original");
                yield return originalAssetRequest;
                var changedAssetRequest = bundle.LoadAssetAsync<Sprite>("Changed");
                yield return changedAssetRequest;
                OriginalRenderer.sprite = originalAssetRequest.asset as Sprite;
                ChangedRendrer.sprite = changedAssetRequest.asset as Sprite;
                bundle.Unload(false);
            }
        }        
    }
}
