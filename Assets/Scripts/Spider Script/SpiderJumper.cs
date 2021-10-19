﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderJumper : MonoBehaviour
{
    public float forceY = 300f;
    private Rigidbody2D myBody;
    private Animator anim;

    void Awake() {
        myBody = GetComponent<Rigidbody2D> ();
        anim = GetComponent<Animator>();
    } 

    void Start() {
        StartCoroutine(Attract());  
    }
  
    IEnumerator Attract() {
        yield return new WaitForSeconds(Random.Range(2, 7));

        forceY = Random.Range (250f, 500f);
        myBody.AddForce(new Vector2(0, forceY));
        anim.SetBool("Attack", true);

        yield return new WaitForSeconds(.7f);

        StartCoroutine(Attract());     
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Player") {
           Destroy(target.gameObject);
        } 
        if (target.tag == "Ground") {
            anim.SetBool("Attack", false);
        }
    }
}
