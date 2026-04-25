using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class ConveyorBelt : MonoBehaviour
{
    [Header("Ayarlar")]
    [Tooltip("Bandýn hareket hýzý")]
    public float speed = 2f;

    [Tooltip("Görsel kayma yönü (Modelin UV haritasýna göre deðiþebilir)")]
    public Vector2 textureScrollDirection = new Vector2(0, 1);

    private Rigidbody rBody;
    private Material mat;

    void Start()
    {
        rBody = GetComponent<Rigidbody>();
        rBody.isKinematic = true; // Güvenlik için kod üzerinden de aktif ediyoruz

        // Görsel efekt için materyali alýyoruz
        mat = GetComponent<MeshRenderer>().material;
    }

    // Fiziksel iþlemler her zaman FixedUpdate içinde yapýlmalýdýr
    void FixedUpdate()
    {
        // 1. FÝZÝKSEL TAÞIMA (Treadmill Efekti)
        // Mevcut pozisyonu kaydediyoruz
        Vector3 currentPos = rBody.position;

        // Rigidbody'i ileri doðru hareket ettiriyoruz (Objeler sürtünme ile taþýnýyor)
        rBody.position += transform.forward * speed * Time.fixedDeltaTime;

        // Rigidbody'i hissettirmeden orijinal konumuna geri çekiyoruz
        rBody.MovePosition(currentPos);
    }

    void Update()
    {
        // 2. GÖRSEL EFEKT (Kaplamayý Kaydýrma)
        // Eðer bandýn üzerinde yön belirten bir texture (ok iþaretleri vs.) varsa
        // bu kod o texture'ý kaydýrarak bandýn hareket ettiði illüzyonunu yaratýr.
        if (mat != null)
        {
            float offset = Time.time * speed * 0.5f; // 0.5f hýzý görsel olarak dengelemek için
            mat.mainTextureOffset = textureScrollDirection * offset;
        }
    }
}