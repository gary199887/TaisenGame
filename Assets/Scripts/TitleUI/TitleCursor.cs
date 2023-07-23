using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TitleCursor : MonoBehaviour
{
    [SerializeField]
    float speed;
    Animator animator;
   
    public static bool canMove;             // bool to check whether player can do any action(whether it is in detect part)
    

    
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!canMove) return;
        Vector3 inputDirection = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.Translate(inputDirection * speed * Time.deltaTime);

    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Button"))
        {
            animator.SetTrigger("OnButtonStay");
        }
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (!canMove) return;

        if (other.gameObject.CompareTag("Button"))
        {
            if (Input.GetButton("Submit"))
            {
                other.gameObject.GetComponent<Button>().onClicked();    // get instanceof "Button" interface and call onClicked() method
            }
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        animator.SetTrigger("OnButtonExit");
    }
}
