using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    float speed;
    Animator animator;      
    SpriteRenderer spriteRenderer;
    public static bool canMove;             // bool to check whether player can do any action(whether it is in detect part)
    public ItemDetailUIManager itemDetailUIManager;
    public static Item[] itemBox;
    // Start is called before the first frame update
    void Start()
    {
        canMove = true;
        speed = 10.0f;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        if (!canMove) return;
        if (other.gameObject.CompareTag("Item")) {
            animator.SetTrigger("FoundItem");
            spriteRenderer.color = Color.red;
        }

        if (other.gameObject.CompareTag("Button"))
        {
            animator.SetTrigger("FoundButton");
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (!canMove) return;
        if (other.gameObject.CompareTag("Item")) {
            if (Input.GetButtonDown("Submit")) {
                // get item
                int id = Int32.Parse(other.gameObject.name.Split("_")[1]);          // identify items' id with their name after '_' -> "Item_1" get 1
                other.gameObject.GetComponent<SpriteRenderer>().color = Color.grey; // make item become grey after being gotten
                itemDetailUIManager.showItemDetail(id);                             // show item detail
            }
        }

        if (other.gameObject.CompareTag("Button"))
        {
            if (Input.GetButtonDown("Submit"))
            {
                other.gameObject.GetComponent<Button>().onClicked();                // get instanceof "Button" interface and call onClicked() method
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
            animator.SetTrigger("ExitItem");
            spriteRenderer.color = Color.white;   
    }
}
