using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;
    public Transform coinBar; // CoinBar paneli
    public GameObject coinIconPrefab; // CoinIcon prefabı

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddCoin(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            AddCoinIcon();
        }
    }

    void AddCoinIcon()
    {
        Instantiate(coinIconPrefab, coinBar);
    }

    public void ResetCoins()
    {
        foreach (Transform child in coinBar)
        {
            Destroy(child.gameObject);
        }
    }
}