using UnityEngine;
using Utilities;


public class DroneMovement : MonoBehaviour
{
    public UDPReceiver udpReceiver; // UDPReceiver 스크립트 참조
    public float moveSpeed = 1.0f;  // 드론 이동 속도
    void Start()
    {
        // GPS 좌표 (예제)
        float gpsLatitude = 37.7745f;
        float gpsLongitude = -122.4190f;
        float gpsAltitude = 100f;

        // GPS → Unity 월드 좌표 변환
        Vector3 worldPosition = GPSConverter.GPSToWorldPosition(gpsLatitude, gpsLongitude, gpsAltitude);
        Debug.Log($"GPS: ({gpsLatitude}, {gpsLongitude}, {gpsAltitude}) -> World: {worldPosition}");

        // Unity 월드 좌표 → GPS 변환
        Vector3 gpsPosition = GPSConverter.WorldPositionToGPS(worldPosition.x, worldPosition.z, worldPosition.y);
        Debug.Log($"World: {worldPosition} -> GPS: ({gpsPosition.x}, {gpsPosition.y}, {gpsPosition.z})");
    }
    void Update()
    {
        // 목표 위치로 부드럽게 이동
        if (udpReceiver != null)
        {
            transform.position = Vector3.Lerp(transform.position, udpReceiver.targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
