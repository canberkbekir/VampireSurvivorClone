using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CirclePoints : MonoBehaviour
{
    public int pointCount = 3;  // Kaç nokta yerleştirileceği
    public float radius = 5f;   // Noktaların merkezden uzaklığı (çemberin yarıçapı)
    public GameObject pointPrefab;  // Nokta prefabı (görsel için)

    void Start()
    {
        PlacePointsOnCircle();
    }

    void PlacePointsOnCircle()
    {
        // 360 dereceyi kaç noktaya böleceğimizi bulalım
        float angleStep = 360f / pointCount;

        for (int i = 0; i < pointCount; i++)
        {
            // Her bir noktanın açısını hesapla
            float angle = i * angleStep;
            // Açıyı radiana çevir
            float angleRad = angle * Mathf.Deg2Rad;

            // Çemberin üzerindeki noktanın X ve Y koordinatlarını hesapla
            float x = Mathf.Cos(angleRad) * radius;
            float y = Mathf.Sin(angleRad) * radius;

            // Noktayı yarat ve pozisyonunu ayarla
            Vector3 pointPosition = new Vector3(x, y, 0);
            Instantiate(pointPrefab, pointPosition, Quaternion.identity);
        }
    }
}