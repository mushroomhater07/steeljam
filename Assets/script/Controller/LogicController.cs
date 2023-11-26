using System;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LogicController : MonoBehaviour
{
    private float score = 0;
    private float currenthealth = 0;
    [SerializeField] private float maxHealth;

    public bool nether;
    [SerializeField] private float DMGinNetherRate;
    [SerializeField]private float CoolDownTime;
    private float currentCoolDown;
    
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private GameObject GameOverScreen;
    [SerializeField] private TMP_Text gameOverScore;

    private Slidersss slidersss_instance;

    public void Start()
    {
        slidersss_instance = GetComponent<Slidersss>();
        slidersss_instance.maxHealth = this.maxHealth;
        currenthealth = maxHealth;
        slidersss_instance.CountDown.maxValue = CoolDownTime;
        slidersss_instance.CountDown.value = currentCoolDown;
        nether = true;
        ChangeDimension();
    }

    private void Update()
    {
        if (nether)
        {
            currentCoolDown -= Time.deltaTime;
            currenthealth -= Time.deltaTime * DMGinNetherRate;
        }
        else currentCoolDown = CoolDownTime;
        slidersss_instance.CountDown.value = currentCoolDown;
        slidersss_instance.CurrentHealth = currenthealth;
        if(currenthealth<0)GameOver();
            
    }

    public void AdjustHealth(float value)
    {
        currenthealth += value;
        if (currenthealth > maxHealth)
        {
            currenthealth = maxHealth;
        }
    }

    public void AddScore() { score++; scoreText.text = score.ToString();}  
    public void RestartGame() { SceneManager.LoadScene(SceneManager.GetActiveScene().name); }
    private void GameOver()
    {
        gameOverScore.text = scoreText.text; GameOverScreen.SetActive(true); }

    public void ChangeDimension()
    {
        if (nether) nether = false;
        else nether = true;
        
        foreach (var VARIABLE in FindObjectsOfType<TerrainScript>())
        {
            VARIABLE.ChangeColour(nether);
        }
        foreach (var VARIABLE2 in FindObjectsOfType<CoinScript>())
        {
            VARIABLE2.gameObject.GetComponent<SpriteRenderer>().enabled = !nether;
        }

        foreach (var VARIABLE3 in FindObjectsOfType<Bullet>())
        {
            VARIABLE3.gameObject.GetComponent<SpriteRenderer>().enabled = nether;
        }

        ;
    }
}
