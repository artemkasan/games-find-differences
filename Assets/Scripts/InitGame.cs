using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InitGame : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern string getInitScene();

    public string defaultInitScene;
   // Start is called before the first frame update
    void Start()
    {
        string initScene = defaultInitScene;
        try 
        {
            initScene = getInitScene();
            if(initScene == null)
            {
                initScene = defaultInitScene;
            }
        }
        catch
        {
            initScene = defaultInitScene;
        }

        SceneManager.LoadScene(initScene);
    }
}
