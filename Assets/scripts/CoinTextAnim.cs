using UnityEngine;
using TMPro;

public class CoinTextAnim : MonoBehaviour
{
    public float moveUpAmount = 1f;
    public float duration = 0.7f;

    private Vector3 startPos;
    private TextMeshProUGUI text;
    private float timer = 0f;

    void Start()
    {
        startPos = transform.position;
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        timer += Time.deltaTime;
        // Yukarı doğru hareket
        transform.position = startPos + Vector3.up * (moveUpAmount * (timer / duration));
        // Şeffaflık animasyonu
        if (text != null)
        {
            Color c = text.color;
            c.a = Mathf.Lerp(1f, 0f, timer / duration);
            text.color = c;
        }
        // Süre bitince objeyi yok et
        if (timer >= duration)
        {
            Destroy(gameObject);
        }
    }
}
