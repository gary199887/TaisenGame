using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class CursorController : MonoBehaviour
{
    [SerializeField]
    float duration;
    [SerializeField]
    Ease ease;
    [SerializeField]
    Transform[] trfm;
    Image image;
    int index;

    bool isInput;
    CanvasGroup mycanvasGroup;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        mycanvasGroup = gameObject.transform.parent.GetComponent<CanvasGroup>();
        index = 0;
        isInput = true;
        image.transform.position = trfm[0].position;
        image.DOFade(0, duration).SetLoops(-1, LoopType.Yoyo).SetEase(ease).SetLink(gameObject);

        StageChangeButton.OnChangeStage += () => { image.DOKill(true); };
        
    }

    // Update is called once per frame
    void Update()
    {
        move();
        check();
    }



    Button button;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Button"))
        {
            button = collision.gameObject.GetComponent<Button>();
        }
    }


    void move()
    {

        float input= Input.GetAxisRaw("Horizontal");//“ü—Í‚ÌŽæ“¾
        
        if (input > 0&&isInput)
        {
            isInput = false;
            if (trfm.Length > index + 1)
            {
                index++;
                image.transform.position = trfm[index].position;
            }
        }
        if (input < 0&&isInput)
        {
            isInput = false;
            if (0 <= index - 1)
            {
                index--;
                image.transform.position = trfm[index].position;
            }
        }

        if(input==0)
        {
            isInput = true;
        }
    }

    void check()
    {
        if(Input.GetButtonUp("Submit")&&mycanvasGroup.alpha>=1)
        {
            button.onClicked();
        }
    }

}
