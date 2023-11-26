using System;
using UnityEngine;
using UnityEngine.UI;

    public class Slidersss : MonoBehaviour
    {
        public float maxHealth { get; set; }

        public float CurrentHealth
        {
            get => currentHealth;
            set => currentHealth = value;
        }

        private float currentHealth; //dont set anything
        
        [SerializeField] private Slider healthbar;
        public Slider CountDown;

        private void Update()
        {
            healthbar.value = currentHealth / maxHealth;
            // CountDown.value = countdownTimer;
        }
    }
