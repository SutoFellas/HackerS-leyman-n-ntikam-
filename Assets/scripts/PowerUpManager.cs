using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class PowerUpManager : MonoBehaviour
{
    public static PowerUpManager Instance;

    [System.Serializable]
    public class PowerUpInfo
    {
        public string powerUpName;
        public float duration = 10f;
        public float currentTime;
        public bool isActive;
        public Slider durationBar;
    }

    public List<PowerUpInfo> powerUps = new List<PowerUpInfo>();
    private PlayerMovement playerMovement;

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

        playerMovement = FindFirstObjectByType<PlayerMovement>();
    }

    void Update()
    {
        foreach (PowerUpInfo powerUp in powerUps)
        {
            if (powerUp.isActive)
            {
                // Süreyi azalt
                powerUp.currentTime -= Time.deltaTime;
                
                // UI barını güncelle
                if (powerUp.durationBar != null)
                {
                    powerUp.durationBar.value = powerUp.currentTime / powerUp.duration;
                }

                // Süre bittiyse powerup'ı deaktif et
                if (powerUp.currentTime <= 0)
                {
                    DeactivatePowerUp(powerUp);
                }
            }
        }
    }

    public void ActivatePowerUp(string powerUpName)
    {
        Debug.Log("PowerUpManager: " + powerUpName);
        Debug.Log("PlayerMovement var mı? " + (playerMovement != null));
        PowerUpInfo powerUp = powerUps.Find(p => p.powerUpName.ToLower() == powerUpName.ToLower());
        if (powerUp != null)
        {
            powerUp.isActive = true;
            powerUp.currentTime = powerUp.duration;
            if (powerUp.durationBar != null)
            {
                powerUp.durationBar.gameObject.SetActive(true);
                powerUp.durationBar.value = 1f;
            }
            if (playerMovement != null)
            {
                switch (powerUpName.ToLower())
                {
                    case "speedboost":
                        playerMovement.ActivateSpeedBoost();
                        break;
                    case "jumpboost":
                        playerMovement.ActivateJumpBoost();
                        break;
                    case "lowgravity":
                        playerMovement.ActivateLowGravity();
                        break;
                }
            }
        }
    }

    void DeactivatePowerUp(PowerUpInfo powerUp)
    {
        powerUp.isActive = false;
        if (powerUp.durationBar != null)
        {
            powerUp.durationBar.gameObject.SetActive(false);
        }
        if (playerMovement != null)
        {
            switch (powerUp.powerUpName.ToLower())
            {
                case "speedboost":
                    playerMovement.DeactivateSpeedBoost();
                    break;
                case "jumpboost":
                    playerMovement.DeactivateJumpBoost();
                    break;
                case "lowgravity":
                    playerMovement.DeactivateLowGravity();
                    break;
            }
        }
    }
} 