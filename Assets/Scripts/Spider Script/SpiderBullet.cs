using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderBullet : MonoBehaviour
{
    // Start is called before the first frame update
   void OnTriggerEnter2D(Collider2D target) {
       if (target.tag == "Player") {
           Destroy(target.gameObject);
           Destroy(gameObject);
       }
       if (target.tag == "Ground") {
           Destroy(gameObject);
       }
   }
}
