using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;                // Takip edilecek karakter
    public float smoothSpeed = 0.125f;      // Takip yumu�akl���
    public Vector3 offset;                  // Kameran�n karaktere g�re konumu

    [Header("S�n�rlar (Opsiyonel)")]
    public bool useBounds = false;          // Kamera s�n�rlar�n� kullanmak i�in
    public float minX = -10f;               // Minimum X pozisyonu
    public float maxX = 10f;                // Maksimum X pozisyonu
    public float minY = -10f;               // Minimum Y pozisyonu
    public float maxY = 10f;                // Maksimum Y pozisyonu

    private Camera cam;                     // Kamera referans�

    private void Start()
    {
        // Kamera bile�enini al
        cam = GetComponent<Camera>();

        if (target == null)
        {
            Debug.LogWarning("Kamera i�in takip edilecek hedef atanmam��!");

            // Oyuncu tagine sahip bir nesne bulmaya �al��
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                target = player.transform;
                Debug.Log("Oyuncu otomatik olarak hedef olarak atand�.");
            }
        }
    }

    void LateUpdate()
    {
        if (target == null)
            return;

        // Hedefin istenen pozisyonu
        Vector3 desiredPosition = target.position + offset;

        // Yumu�ak ge�i�
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime * 10f);

        // S�n�rlar� kontrol et
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

    // G�rsel olarak s�n�rlar� g�stermek i�in (sadece editor'da �al���r)
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