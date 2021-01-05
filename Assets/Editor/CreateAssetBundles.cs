using UnityEditor;

public class NewBehaviourScript
{
    [MenuItem("Assets/Build AssetBundles")]
    public static void BuildAllAssetBundles()
    {
        BuildPipeline.BuildAssetBundles(
            "Assets/AssetBundles",
            BuildAssetBundleOptions.None,
            BuildTarget.WebGL);
    }
}
