using UnityEngine;
using UnityEngine.SceneManagement;
public class ButtonEvent:MonoBehaviour
{
    [SerializeField]
    GameObject TitleUIs;
    [SerializeField]
    GameObject MenuUIs;
    public void GoMenu()
    {
        TitleUIs.SetActive(false);
        MenuUIs.SetActive(true);
    }

    public static void GameEnd()
    {
        //�Q�[���I��
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void BackTitle()
    {
        MenuUIs.SetActive(false);
        TitleUIs.SetActive(true);
    }
    public void NoMethod()
    {

    }
}
