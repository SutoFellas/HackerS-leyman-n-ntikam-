using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartButtonManager : MonoBehaviour
{
    [SerializeField] private Button restartButton;

    void Awake()
    {
        // Restart d��mesinin Click olay�n� dinleme
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }
        else
        {
            Debug.LogError("Restart d��mesi atanmam��!");
        }
    }

    // Oyunu yeniden ba�latma fonksiyonu
    public void RestartGame()
    {
        // Aktif sahneyi yeniden y�kleme
        Scene currentScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(currentScene.name);

        // �sterseniz bir sesli efekt ekleyebilirsiniz
        // AudioManager.Instance.PlaySound("button_click");

        Debug.Log("Oyun yeniden ba�lat�ld�!");
    }
}