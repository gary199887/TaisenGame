using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonEvent:MonoBehaviour
{
    public static void Start()
    {

    }

    public static void GameEnd()
    {
        //ÉQÅ[ÉÄèIóπ
#if UNITY_EDiTOR
        UnityEditor.EditorApplication.isPlaying=false;
#else
        Application.Quit();
#endif
    }

    public static void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public static void BackTitle()
    {

    }

}
