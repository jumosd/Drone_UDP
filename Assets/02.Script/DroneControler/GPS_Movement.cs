using UnityEngine;
using Utilities;


public class DroneMovement : MonoBehaviour
{
    public UDPReceiver udpReceiver; // UDPReceiver ��ũ��Ʈ ����
    public float moveSpeed = 1.0f;  // ��� �̵� �ӵ�
    void Start()
    {
        // GPS ��ǥ (����)
        float gpsLatitude = 37.7745f;
        float gpsLongitude = -122.4190f;
        float gpsAltitude = 100f;

        // GPS �� Unity ���� ��ǥ ��ȯ
        Vector3 worldPosition = GPSConverter.GPSToWorldPosition(gpsLatitude, gpsLongitude, gpsAltitude);
        Debug.Log($"GPS: ({gpsLatitude}, {gpsLongitude}, {gpsAltitude}) -> World: {worldPosition}");

        // Unity ���� ��ǥ �� GPS ��ȯ
        Vector3 gpsPosition = GPSConverter.WorldPositionToGPS(worldPosition.x, worldPosition.z, worldPosition.y);
        Debug.Log($"World: {worldPosition} -> GPS: ({gpsPosition.x}, {gpsPosition.y}, {gpsPosition.z})");
    }
    void Update()
    {
        // ��ǥ ��ġ�� �ε巴�� �̵�
        if (udpReceiver != null)
        {
            transform.position = Vector3.Lerp(transform.position, udpReceiver.targetPosition, moveSpeed * Time.deltaTime);
        }
    }
}
