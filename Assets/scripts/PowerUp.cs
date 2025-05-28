using UnityEngine;
using System.Collections;

public class PowerUp : MonoBehaviour
{
    public string powerUpType = "SpeedBoost"; // SpeedBoost, JumpBoost, LowGravity
    public Color starColor;        // Yıldızın rengi

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Eğer oyuncu güce dokunursa
        if (collision.CompareTag("Player"))
        {
            // PowerUpManager'ı bul ve gücü aktifleştir
            PowerUpManager powerUpManager = PowerUpManager.Instance;
            if (powerUpManager != null)
            {
                powerUpManager.ActivatePowerUp(powerUpType.ToLower());
                Destroy(gameObject);
            }
        }
    }
}