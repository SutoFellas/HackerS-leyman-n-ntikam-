using UnityEngine;

public class PowerUpPickup : MonoBehaviour
{
    public string powerUpType = "SpeedBoost"; // SpeedBoost, JumpBoost, LowGravity

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PowerUpManager powerUpManager = PowerUpManager.Instance;
            
            if (powerUpManager != null)
            {
                powerUpManager.ActivatePowerUp(powerUpType);
                Destroy(gameObject);
            }
        }
    }
} 