using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderShooter : MonoBehaviour
{
  
    [SerializeField]
    private GameObject bullet;

    void Start() {
        StartCoroutine(Attract());  
    }
  
    IEnumerator Attract() {
        yield return new WaitForSeconds(Random.Range(2, 7));

        Vector3 temp = transform.position;
        Instantiate (bullet, temp, Quaternion.identity);   

        StartCoroutine(Attract());     
    }

    void OnTriggerEnter2D(Collider2D target) {
        if (target.tag == "Player") {
           Destroy(target.gameObject);
        } 
    }
}
