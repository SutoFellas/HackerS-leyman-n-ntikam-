using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButtonManager : MonoBehaviour
{
    [SerializeField] private Button restartButton;

    void Awake()
    {
        // Restart düðmesinin Click olayýný dinleme
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }
        else
        {
            Debug.LogError("Restart düðmesi atanmamýþ!");
        }
    }

    // Oyunu yeniden baþlatma fonksiyonu
    public void RestartGame()
    {
        // Aktif sahneyi yeniden yükleme
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);

        // Ýsterseniz bir sesli efekt ekleyebilirsiniz
        // AudioManager.Instance.PlaySound("button_click");

        Debug.Log("Oyun yeniden baþlatýldý!");
    }
}