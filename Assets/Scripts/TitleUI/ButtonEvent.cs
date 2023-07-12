using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class ButtonEvent:MonoBehaviour
{
    [SerializeField]
    GameObject TitleUIs;
    [SerializeField]
    GameObject MenuUIs;
    public void GoMenu()
    {
        //TitleUIs.transform.DOScale(new Vector3(0, 0, 0), 0.3f);
        //MenuUIs.transform.DOScale(new Vector3(1, 1, 1), 0.3f);
        TitleUIs.SetActive(false);
        MenuUIs.SetActive(true);
    }

    public void GameEnd()
    {
        //ƒQ[ƒ€I—¹
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public static void ChangeScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }

    public void BackTitle()
    {

        MenuUIs.transform.DOScale(new Vector3(0, 0, 0), 0.3f)
            .OnComplete(() =>
            {
                TitleUIs.transform.DOScale(new Vector3(1, 1, 1), 0.3f);
            }
        );
    }
    public void NoMethod()
    {

    }

    
}
