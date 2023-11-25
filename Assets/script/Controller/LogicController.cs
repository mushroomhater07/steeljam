using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicController : MonoBehaviour
{
    private float score = 0;
    private float currenthealth = 0;
    [SerializeField] float maxHealth;
    
    [SerializeField] private bool nether;
    [SerializeField] private float DMGinNetherRate;
    
    public TextMeshProUGUI scoreText;
    public GameObject GameOverScreen;

    private Slidersss slidersss_instance;

    public void Start()
    {
        slidersss_instance = GetComponent<Slidersss>();
        slidersss_instance.maxHealth = this.maxHealth;
    }

    private void Update()
    {
        if (nether) currenthealth -= Time.deltaTime * DMGinNetherRate;
        slidersss_instance.currentHealth = currenthealth;
        UnityEngine.Tilemaps.Tilemap.
            
    }

    public void AddScore() { score++; scoreText.text = score.ToString();}  
    public void RestartGame() { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
    public void GameOver() { GameOverScreen.SetActive(true); }
}
