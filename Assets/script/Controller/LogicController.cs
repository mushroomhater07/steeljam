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

    [SerializeField] private Image background;
    [SerializeField] private Slider healthbar;
    [SerializeField] private Slider CountDown;
    public TMP_Text CoolDownDoneText;

    private PlayerMovement pmovent;
    
    public void Start()
    {
        pmovent = FindObjectOfType<PlayerMovement>();
        currenthealth = maxHealth;
        CountDown.maxValue = CoolDownTime;
        CountDown.value = currentCoolDown;
        nether = false;
        ChangeDimension();
        
    }

    private void Update()
    {
        if (nether)
        {
            currentCoolDown -= Time.deltaTime;
            currenthealth -= Time.deltaTime * DMGinNetherRate;
            if (currentCoolDown < 0)pmovent.EnableSwitch(true);else pmovent.EnableSwitch(false);
        }else
            pmovent.EnableSwitch(true);
        CountDown.value = currentCoolDown;
        healthbar.value = currenthealth / maxHealth;
        
        if(currenthealth<0) GameOver();
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
    public void RestartGame() { SceneManager.LoadScene(SceneManager.GetActiveScene().name);FindObjectOfType<PlayerMovement>().actionmaps.Enable(); }
    public void GameOver() { gameOverScore.text = scoreText.text; GameOverScreen.SetActive(true); FindObjectOfType<PlayerMovement>().actionmaps.Disable();}

    public void ChangeDimension()
    {
        currentCoolDown = CoolDownTime;
        if (nether) { nether = false;
            background.sprite = Resources.Load<Sprite>("clou");
            FindObjectOfType<Camera>().cullingMask = LayerMask.GetMask("Default", "Ground", "Player", "Strawberries",
                "Water", "Ignore Raycast", "UI", "TransparentFX"); }
        else { nether = true;
            background.sprite = Resources.Load<Sprite>("cav");
            FindObjectOfType<Camera>().cullingMask = FindObjectOfType<Camera>().cullingMask = LayerMask.GetMask("Default", "Ground", "Player", "Bullets",
                "Water", "Ignore Raycast", "UI", "TransparentFX"); }
        foreach (var VARIABLE in FindObjectsOfType<TerrainScript>()) VARIABLE.ChangeColour(nether);
        
        
        
        
        
    }
}
