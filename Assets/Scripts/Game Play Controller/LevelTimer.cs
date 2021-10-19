using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    // Start is called before the first frame update
  // Start is called before the first frame update
    private Slider slider;
    private GameObject player;
    public float timer = 10f;
    private float timerBurn = 1f;

    void Start()
    {
        
    }

    void Awake() {
        GetPreferences();
    }

    // Update is called once per frame
    void Update()
    {
        if (!player)
            return;
        
        if (timer > 0) {
            timer -= timerBurn * Time.deltaTime;
            slider.value = timer;
        } else {
            Destroy(player);
        }
    }

    void GetPreferences() {
        player= GameObject.Find("Player");
        slider = GameObject.Find ("Timer Slider").GetComponent<Slider>();

        slider.minValue = 0f;
        slider.maxValue = timer;
        slider.value = slider.maxValue;
    }
}
