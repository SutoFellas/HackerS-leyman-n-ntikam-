using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AdminMenu : MonoBehaviour
{
    public GameObject adminPanel;
    public Slider speedSlider;
    public Slider timeSlider;
    public TMP_InputField teleportX;
    public TMP_InputField teleportY;
    public Button teleportButton;
    public Button closeButton;

    private PlayerMovement playerMovement;
    private bool isMenuOpen = false;

    void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
        adminPanel.SetActive(false);

        speedSlider.onValueChanged.AddListener(OnSpeedChanged);
        timeSlider.onValueChanged.AddListener(OnTimeChanged);
        teleportButton.onClick.AddListener(OnTeleportClicked);
        closeButton.onClick.AddListener(OnCloseClicked);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F12))
        {
            ToggleMenu();
        }
    }

    void ToggleMenu()
    {
        isMenuOpen = !isMenuOpen;
        adminPanel.SetActive(isMenuOpen);

        if (isMenuOpen && playerMovement != null)
        {
            speedSlider.value = playerMovement.normalSpeed;
            timeSlider.value = Time.timeScale;
        }
    }

    void OnSpeedChanged(float value)
    {
        if (playerMovement != null)
        {
            playerMovement.SetSpeed(value);
        }
    }

    void OnTimeChanged(float value)
    {
        Time.timeScale = value;
    }

    void OnTeleportClicked()
    {
        if (playerMovement != null &&
            float.TryParse(teleportX.text, out float x) &&
            float.TryParse(teleportY.text, out float y))
        {
            playerMovement.transform.position = new Vector3(x, y, playerMovement.transform.position.z);
        }
    }

    void OnCloseClicked()
    {
        ToggleMenu();
    }
}
