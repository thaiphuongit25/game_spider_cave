using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy : MonoBehaviour
{
    public float force = 500f;
    private Animator anim;
    // Start is called before the first frame update
    void Awake() {
        anim = GetComponent<Animator>();
    }

    void Start()
    {
        
    }

    IEnumerator AnimateBounce(){
		anim.Play ("Up");
		yield return new WaitForSeconds (.7f);
		anim.Play("Down");
	}

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Player") {
            target.gameObject.GetComponent<PlayerScript>().BouncePlayerWithBouncy(force);
            StartCoroutine(AnimateBounce());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
