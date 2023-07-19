using UnityEngine;
using UnityEngine.SceneManagement;
using DG.Tweening;
public class ButtonEvent:MonoBehaviour
{
    [SerializeField]
    GameObject TitleUIs;
    [SerializeField]
    GameObject MenuUIs;

    public static int stageNum { get; private set; }



    public void ChangeScene(int number)
    {
        stageNum = number;
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene("GameScene");
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
