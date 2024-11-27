using UnityEngine;
using Utilities;

public class DroneMovement : MonoBehaviour
{
    public UDPReceiver udpReceiver; // UDPReceiver ��ũ��Ʈ ����
    public float moveSpeed = 1.0f;  // ��� �̵� �ӵ�

    private Vector3 worldPosition; // GPS �� Unity ��ȯ ����� ����

    void Start()
    {
        // GPS ��ǥ
        float gpsLatitude = 37.257955f;
        float gpsLongitude = 126.292536f;
        float gpsAltitude = 150f;

        // GPS �� Unity ���� ��ǥ ��ȯ
        worldPosition = GPSConverter.GPSToWorldPosition(gpsLatitude, gpsLongitude, gpsAltitude);
        Debug.Log($"GPS: ({gpsLatitude}, {gpsLongitude}, {gpsAltitude}) -> World: {worldPosition}");
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, worldPosition, moveSpeed * Time.deltaTime);
    }
    
}
