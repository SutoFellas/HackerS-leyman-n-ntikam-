using UnityEngine;

public class Coin : MonoBehaviour
{
    public GameObject coinTextPrefab; // CoinTextAnim içeren prefab

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Eğer oyuncu coin'e dokunursa
        if (collision.CompareTag("Player"))
        {
            // Coin sayacını artır
            CoinManager.Instance.AddCoin(1);

            // +1 yazısını oluştur
            if (coinTextPrefab != null)
            {
                Instantiate(coinTextPrefab, transform.position, Quaternion.identity);
            }

            // Coin'i yok et
            Destroy(gameObject);
        }
    }
}
