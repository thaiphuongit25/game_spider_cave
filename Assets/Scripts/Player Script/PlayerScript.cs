using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveForce = 20f;
    public float jumpForce = 400f;
    public float maxVeclocity = 4f;

    private bool grounded = false;
    private Rigidbody2D myBody;
    private Animator anim;

    void Awake() {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator> ();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerWalkKeyBoard();
    }

    void PlayerWalkKeyBoard() {
        float forceX = 0f;
        float forceY = 0f;
        float vel = Mathf.Abs (myBody.velocity.x);
        float h = Input.GetAxisRaw("Horizontal"); //-1 0 1
        if (h > 0) {
            if (vel < maxVeclocity) {
                if (grounded) {
                    forceX = moveForce;
                } else {
                    forceX = moveForce*1.1f;
                }
                
            }
            Vector3 scale = transform.localScale;
            scale.x = 1f;
            transform.localScale = scale;
            anim.SetBool("walk", true);
        } else if (h < 0) {
             if (vel < maxVeclocity) {
                forceX = -moveForce;
            }
            Vector3 scale = transform.localScale;
            scale.x = -1f;
            transform.localScale = scale;
            anim.SetBool("walk", true);
        } else if (h == 0) {
            anim.SetBool("walk", false);
        }

        if(Input.GetKey(KeyCode.Space)) {
            // grounded = true;
            Debug.Log("Space");
            Debug.Log(grounded);
            if (grounded) {
                grounded = false;
                forceY = jumpForce;
            }
        }
        myBody.AddForce(new Vector2(forceX, forceY));
    }

    void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Ground") {
            grounded = true;
            Debug.Log("enter");
            Debug.Log(grounded);
        }
    }

    public void BouncePlayerWithBouncy(float force) {
        if (grounded) {
            grounded = false;
            myBody.AddForce(new Vector2(0, force));
        }
    }
}
