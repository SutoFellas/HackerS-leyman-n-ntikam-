using UnityEngine;

public class UIFollowCamera : MonoBehaviour
{
    private Canvas canvas;
    private RectTransform rectTransform;

    [Header("UI Pozisyonlar�")]
    [Tooltip("Sol �st k��ede yer alan timer UI ��esi")]
    public RectTransform timerUI;

    [Tooltip("Sa� �st k��ede yer alan coin UI ��esi")]
    public RectTransform coinUI;

    [Header("Kenar Bo�luklar�")]
    public float topMargin = 20f;
    public float sideMargin = 20f;

    private void Awake()
    {
        // Canvas bile�enini al
        canvas = GetComponent<Canvas>();

        if (canvas == null)
        {
            Debug.LogError("UIFollowCamera bir Canvas nesnesine eklenmelidir!");
            return;
        }

        // Canvas'�n RectTransform'unu al
        rectTransform = canvas.GetComponent<RectTransform>();

        // Canvas'�n render modunu Camera olarak ayarla
        if (canvas.renderMode != RenderMode.ScreenSpaceCamera)
        {
            canvas.renderMode = RenderMode.ScreenSpaceCamera;
            Debug.Log("Canvas render modu ScreenSpaceCamera olarak ayarland�.");
        }

        // Kamera atamas� yap�n
        Camera mainCamera = Camera.main;
        if (mainCamera != null)
        {
            canvas.worldCamera = mainCamera;
            Debug.Log("Canvas'a ana kamera atand�.");
        }
        else
        {
            Debug.LogWarning("Ana kamera bulunamad�!");
        }
    }

    private void Start()
    {
        PositionUIElements();
    }

    private void PositionUIElements()
    {
        // Timer UI'� sol �st k��eye yerle�tir
        if (timerUI != null)
        {
            timerUI.anchorMin = new Vector2(0, 1);
            timerUI.anchorMax = new Vector2(0, 1);
            timerUI.pivot = new Vector2(0, 1);
            timerUI.anchoredPosition = new Vector2(sideMargin, -topMargin);
        }

        // Coin UI'� sa� �st k��eye yerle�tir
        if (coinUI != null)
        {
            coinUI.anchorMin = new Vector2(1, 1);
            coinUI.anchorMax = new Vector2(1, 1);
            coinUI.pivot = new Vector2(1, 1);
            coinUI.anchoredPosition = new Vector2(-sideMargin, -topMargin);
        }
    }

    // Canvas boyutu de�i�irse UI ��elerini yeniden konumland�r
    private void OnRectTransformDimensionsChange()
    {
        PositionUIElements();
    }
}