using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class HealthManager : MonoBehaviour
{
    [Header("Health Settings")]
    public float maxHealth = 100f;
    public float currentHealth;
    public float baseHealthDecreaseRate = 2f; // Saniyede azalan can miktarı
    public float healthDecreaseMultiplier = 1.2f; // Her 30 saniyede bir artış çarpanı

    [Header("Time Settings")]
    public float gameTime = 0f;
    public float difficultyIncreaseInterval = 30f; // Her 30 saniyede bir zorlaşma
    private float nextDifficultyIncrease;

    [Header("UI Elements")]
    public Slider healthBar;
    public TextMeshProUGUI timeText;
    
    private bool isGameOver = false;

    void Start()
    {
        currentHealth = maxHealth;
        nextDifficultyIncrease = difficultyIncreaseInterval;
        
        if (healthBar != null)
        {
            healthBar.maxValue = maxHealth;
            healthBar.value = currentHealth;
        }

        UpdateTimeText();
    }

    void Update()
    {
        if (isGameOver) return;

        // Zamanı güncelle
        gameTime += Time.deltaTime;
        UpdateTimeText();

        // Zorluğu artır
        if (gameTime >= nextDifficultyIncrease)
        {
            baseHealthDecreaseRate *= healthDecreaseMultiplier;
            nextDifficultyIncrease += difficultyIncreaseInterval;
        }

        // Canı azalt
        DecreaseHealth(baseHealthDecreaseRate * Time.deltaTime);
    }

    public void CollectStar()
    {
        // Yıldız toplandığında canı artır
        AddHealth(20f);
    }

    public void AddHealth(float amount)
    {
        currentHealth = Mathf.Min(currentHealth + amount, maxHealth);
        UpdateHealthBar();
    }

    public void DecreaseHealth(float amount)
    {
        currentHealth -= amount;
        UpdateHealthBar();

        if (currentHealth <= 0 && !isGameOver)
        {
            GameOver();
        }
    }

    void UpdateHealthBar()
    {
        if (healthBar != null)
        {
            healthBar.value = currentHealth;
        }
    }

    void UpdateTimeText()
    {
        if (timeText != null)
        {
            int minutes = Mathf.FloorToInt(gameTime / 60);
            int seconds = Mathf.FloorToInt(gameTime % 60);
            timeText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    void GameOver()
    {
        isGameOver = true;
        // Oyunu yeniden başlat
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
} 