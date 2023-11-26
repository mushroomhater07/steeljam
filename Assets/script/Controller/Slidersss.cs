using System;
using UnityEngine;
using UnityEngine.UI;

    public class Slidersss : MonoBehaviour
    {
        public float maxHealth { get; set; }
        private float countdownTimer{ get; set; }

        public float CurrentHealth
        {
            get => currentHealth;
            set => currentHealth = value;
        }

        private float currentHealth; //dont set anything
        
        [SerializeField] private Slider healthbar;
        [SerializeField] private Slider CountDown;

        private void Update()
        {
            
            healthbar.value = currentHealth / maxHealth;
            // CountDown.value = countdownTimer;
        }
    }
