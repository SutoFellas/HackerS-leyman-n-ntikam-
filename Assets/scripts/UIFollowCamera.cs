using UnityEngine;

public class UIFollowCamera : MonoBehaviour
{
    private Canvas canvas;
    private RectTransform rectTransform;

    [Header("UI Pozisyonlarý")]
    [Tooltip("Sol üst köþede yer alan timer UI öðesi")]
    public RectTransform timerUI;

    [Tooltip("Sað üst köþede yer alan coin UI öðesi")]
    public RectTransform coinUI;

    [Header("Kenar Boþluklarý")]
    public float topMargin = 20f;
    public float sideMargin = 20f;

    private void Awake()
    {
        // Canvas bileþenini al
        canvas = GetComponent<Canvas>();

        if (canvas == null)
        {
            Debug.LogError("UIFollowCamera bir Canvas nesnesine eklenmelidir!");
            return;
        }

        // Canvas'ýn RectTransform'unu al
        rectTransform = canvas.GetComponent<RectTransform>();

        // Canvas'ýn render modunu Camera olarak ayarla
        if (canvas.renderMode != RenderMode.ScreenSpaceCamera)
        {
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            Debug.Log("Canvas render modu ScreenSpaceCamera olarak ayarlandý.");
        }

        // Kamera atamasý yapýn
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            canvas.worldCamera = mainCamera;
            Debug.Log("Canvas'a ana kamera atandý.");
        }
        else
        {
            Debug.LogWarning("Ana kamera bulunamadý!");
        }
    }

    private void Start()
    {
        PositionUIElements();
    }

    private void PositionUIElements()
    {
        // Timer UI'ý sol üst köþeye yerleþtir
        if (timerUI != null)
        {
            timerUI.anchorMin = new Vector2(0, 1);
            timerUI.anchorMax = new Vector2(0, 1);
            timerUI.pivot = new Vector2(0, 1);
            timerUI.anchoredPosition = new Vector2(sideMargin, -topMargin);
        }

        // Coin UI'ý sað üst köþeye yerleþtir
        if (coinUI != null)
        {
            coinUI.anchorMin = new Vector2(1, 1);
            coinUI.anchorMax = new Vector2(1, 1);
            coinUI.pivot = new Vector2(1, 1);
            coinUI.anchoredPosition = new Vector2(-sideMargin, -topMargin);
        }
    }

    // Canvas boyutu deðiþirse UI öðelerini yeniden konumlandýr
    private void OnRectTransformDimensionsChange()
    {
        PositionUIElements();
    }
}