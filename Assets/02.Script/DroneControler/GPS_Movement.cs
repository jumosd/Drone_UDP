using UnityEngine;
using Utilities;

public class DroneMovement : MonoBehaviour
{
    public UDPReceiver udpReceiver; // UDPReceiver 스크립트 참조
    public float moveSpeed = 1.0f;  // 드론 이동 속도

    private Vector3 worldPosition; // GPS → Unity 변환 결과를 저장

    void Start()
    {
        // GPS 좌표
        float gpsLatitude = 37.257955f;
        float gpsLongitude = 126.292536f;
        float gpsAltitude = 150f;

        // GPS → Unity 월드 좌표 변환
        worldPosition = GPSConverter.GPSToWorldPosition(gpsLatitude, gpsLongitude, gpsAltitude);
        Debug.Log($"GPS: ({gpsLatitude}, {gpsLongitude}, {gpsAltitude}) -> World: {worldPosition}");
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, worldPosition, moveSpeed * Time.deltaTime);
    }
    
}
