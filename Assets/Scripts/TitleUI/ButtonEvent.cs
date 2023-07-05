using UnityEngine;

[System.Serializable]
public class ButtonEvent:MonoBehaviour
{
    public static void GameEnd()
    {
        //ÉQÅ[ÉÄèIóπ
#if UNITY_EDiTOR
        UnityEditor.EditorApplication.isPlaying=false;
#else
        Application.Quit();
#endif
    }

    public static void ChangeScene()
    {

    }

}
