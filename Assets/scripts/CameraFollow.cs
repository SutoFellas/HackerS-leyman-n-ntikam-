using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;                // Takip edilecek karakter
    public float smoothSpeed = 0.125f;      // Takip yumuþaklýðý
    public Vector3 offset;                  // Kameranýn karaktere göre konumu

    [Header("Sýnýrlar (Opsiyonel)")]
    public bool useBounds = false;          // Kamera sýnýrlarýný kullanmak için
    public float minX = -10f;               // Minimum X pozisyonu
    public float maxX = 10f;                // Maksimum X pozisyonu
    public float minY = -10f;               // Minimum Y pozisyonu
    public float maxY = 10f;                // Maksimum Y pozisyonu

    private Camera cam;                     // Kamera referansý

    private void Start()
    {
        // Kamera bileþenini al
        cam = GetComponent<Camera>();

        if (target == null)
        {
            Debug.LogWarning("Kamera için takip edilecek hedef atanmamýþ!");

            // Oyuncu tagine sahip bir nesne bulmaya çalýþ
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                target = player.transform;
                Debug.Log("Oyuncu otomatik olarak hedef olarak atandý.");
            }
        }
    }

    void LateUpdate()
    {
        if (target == null)
            return;

        // Hedefin istenen pozisyonu
        Vector3 desiredPosition = target.position + offset;

        // Yumuþak geçiþ
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime * 10f);

        // Sýnýrlarý kontrol et
        if (useBounds)
        {
            smoothedPosition.x = Mathf.Clamp(smoothedPosition.x, minX, maxX);
            smoothedPosition.y = Mathf.Clamp(smoothedPosition.y, minY, maxY);
        }

        // Z pozisyonunu koru
        smoothedPosition.z = transform.position.z;

        // Pozisyonu uygula
        transform.position = smoothedPosition;
    }

    // Görsel olarak sýnýrlarý göstermek için (sadece editor'da çalýþýr)
    private void OnDrawGizmosSelected()
    {
        if (useBounds)
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawLine(new Vector3(minX, minY, 0), new Vector3(maxX, minY, 0));
            Gizmos.DrawLine(new Vector3(maxX, minY, 0), new Vector3(maxX, maxY, 0));
            Gizmos.DrawLine(new Vector3(maxX, maxY, 0), new Vector3(minX, maxY, 0));
            Gizmos.DrawLine(new Vector3(minX, maxY, 0), new Vector3(minX, minY, 0));
        }
    }
}