using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    float horizontalMove = 0f;
    public float runspeed = 40f;
    bool jump = false;
    bool cuttree = false;
    public BoxCollider2D jumpcolider;
    bool fakeHidden = true;
    bool movedonce = false;

    
    public GameObject brokentree;
    public GameObject goodtree;
    public GameObject fakeblue;

    // Start is called before the first frame update
    void Start()
    {
        brokentree.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = (Input.GetAxisRaw("Horizontal")) * runspeed ;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
        }

        if (Input.GetButtonDown("Action"))
        {
            if (cuttree)
            {
                goodtree.SetActive(false);
                brokentree.SetActive(true);
            }

            if (!fakeHidden)
            {
                if (!movedonce)
                {
                    fakeblue.transform.position = new Vector2(transform.position.x + 0.03f * Time.deltaTime, transform.position.y);
                    //fakeblue.transform.rotation = new Vector2(transform.rotation.x + 1 * Time.deltaTime, transform.rotation.y);
                }
                fakeHidden = true;
                movedonce = true;
            }
        }
    }


    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("tree") || collision.CompareTag("fake")){
            cuttree = true;
            Debug.Log("Press e - cut the tree");
            gameObject.GetComponent<gameState>().ChangeHudText("cut the treE");
        }
  
        if (collision.CompareTag("jumpsign"))
        {
            Debug.Log("Press space to jump");
            gameObject.GetComponent<gameState>().ChangeHudText("jump");
        }

        if (collision.CompareTag("killswitch"))
        {
            Debug.Log("killreset");
            gameObject.GetComponent<gameState>().ResetCurrentSceen();
        }

        if (collision.CompareTag("goal"))
        {
            Debug.Log("killreset");
            gameObject.GetComponent<gameState>().ResetCurrentSceen();
        }

        if (collision.CompareTag("fake"))
        {
            Debug.Log("fake found");
            gameObject.GetComponent<gameState>().ChangeHudText("fake");
            fakeHidden = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        gameObject.GetComponent<gameState>().ChangeHudText("");
    }
}
