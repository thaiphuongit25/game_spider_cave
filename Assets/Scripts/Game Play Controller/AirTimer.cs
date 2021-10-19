using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirTimer : MonoBehaviour
{
    // Start is called before the first frame update
    private Slider slider;
    private GameObject player;
    public float air = 10f;
    private float airBurn = 1f;

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
        
        if (air > 0) {
            air -= airBurn * Time.deltaTime;
            slider.value = air;
        } else {
            Destroy(player);
        }
    }

    void GetPreferences() {
        player= GameObject.Find("Player");
        slider = GameObject.Find ("Air Slider").GetComponent<Slider>();

        slider.minValue = 0f;
        slider.maxValue = air;
        slider.value = slider.maxValue;
    }
}
