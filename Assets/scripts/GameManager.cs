using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("UI References")]
    public TextMeshProUGUI timerText;      // Sol üstteki süre sayacı
    public TextMeshProUGUI coinText;       // Sağ üstteki coin sayacı

    [Header("Settings")]
    public float gameTime = 0f;           // Oyun süresi
    public bool gameRunning = false;      // Oyun durumu

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        // Oyun başladığında süreyi ve coin'i sıfırla
        ResetGame();
        // Oyunu başlat
        StartGame();
    }

    private void Update()
    {
        if (gameRunning)
        {
            // Süreyi güncelle
            gameTime += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    public void StartGame()
    {
        gameRunning = true;
    }

    public void StopGame()
    {
        gameRunning = false;
    }

    public void ResetGame()
    {
        gameTime = 0f;
        UpdateTimerDisplay();
        CoinManager.Instance.ResetCoins();
    }

    private void UpdateTimerDisplay()
    {
        // Süreyi dakika:saniye formatında göster
        int minutes = Mathf.FloorToInt(gameTime / 60);
        int seconds = Mathf.FloorToInt(gameTime % 60);
        timerText.text = string.Format("Süre: {0:00}:{1:00}", minutes, seconds);
    }
}