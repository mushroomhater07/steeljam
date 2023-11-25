using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    // Start is called before the first frame update
    public Slider mainSlider;
    void Start()
    {
        mainSlider = GetComponent<Slider>();
        mainSlider.value = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
