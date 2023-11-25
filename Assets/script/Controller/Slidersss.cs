using System;
using UnityEngine;
using UnityEngine.UI;

    public class Slidersss : MonoBehaviour
    {
        public float maxHealth;
        public float countdownTimer;
        public float currentHealth; //dont set anything
        
        [SerializeField] private Slider healthbar;
        [SerializeField] private Slider CountDown;

        private void Update()
        {
            healthbar.value = currentHealth / maxHealth;
            // CountDown.value = countdownTimer;
        }
    }
