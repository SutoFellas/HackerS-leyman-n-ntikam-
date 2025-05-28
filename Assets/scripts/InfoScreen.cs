using UnityEngine;
using UnityEngine.UI;

public class InfoScreen : MonoBehaviour
{
    public GameObject infoPanel;
    public Button closeButton;

    void Start()
    {
        Time.timeScale = 0f; // Oyunu duraklat
        infoPanel.SetActive(true);
        closeButton.onClick.AddListener(CloseInfo);
    }

    void CloseInfo()
    {
        infoPanel.SetActive(false);
        Time.timeScale = 1f; // Oyunu başlat
    }
}
