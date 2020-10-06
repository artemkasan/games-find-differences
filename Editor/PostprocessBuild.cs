using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;

public class PostprocessBuild
{
	// Start is called before the first frame update
	[PostProcessBuildAttribute(1)]
	public static void OnPostprocessBuild(BuildTarget target, string targetPath)
	{
		var path = Path.Combine(targetPath, "Build/UnityLoader.js");
		var text = File.ReadAllText(path);
		text = text.Replace("UnityLoader.SystemInfo.mobile", "false");
		File.WriteAllText(path, text);
	}
}
