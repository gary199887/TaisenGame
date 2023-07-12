using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    float speed;
    Animator animator;
    SpriteRenderer spriteRenderer;
    public static bool canMove;
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
            if (Input.GetKeyDown(KeyCode.Z))
            {
                int id = Int32.Parse(other.gameObject.name.Split("_")[1]);
                itemDetailUIManager.showItemDetail(id);            }
        }

        if (other.gameObject.CompareTag("Button"))
        {
            animator.SetTrigger("FoundItem");
            spriteRenderer.color = Color.red;
            if (Input.GetKeyDown(KeyCode.Z))
            {
                other.gameObject.GetComponent<Button>().onClicked();
            }
        }
    }


    private void OnTriggerStay2D(Collider2D other)
    {
        if (!canMove) return;
        if (other.gameObject.CompareTag("Item")) {
            if (Input.GetKeyDown(KeyCode.Z)) {
                int id = Int32.Parse(other.gameObject.name.Split("_")[1]);
                other.gameObject.GetComponent<SpriteRenderer>().color = Color.grey;
                itemDetailUIManager.showItemDetail(id);
            }
        }

        if (other.gameObject.CompareTag("Button"))
        {
            if (Input.GetKeyDown(KeyCode.Z))
            {
                Debug.Log("clicked");
                other.gameObject.GetComponent<Button>().onClicked();
            }
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        //if (other.gameObject.CompareTag("Item"))
        {
            animator.SetTrigger("ExitItem");
            spriteRenderer.color = Color.white;
        }
    }
}