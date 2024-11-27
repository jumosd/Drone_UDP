using UnityEngine;
using Utilities;

public class DroneMovement : MonoBehaviour
{
    public UDPReceiver udpReceiver; // UDPReceiver 스크립트 참조
    public float moveSpeed = 1.0f;  // 드론 이동 속도
    public float rotationSpeed = 2.0f; // 드론 회전 속도

    private Vector3 targetPosition; // GPS → Unity 변환 결과를 저장

    void Start()
    {
        // GPS 좌표
        float gpsLatitude = 37.269615f;
        float gpsLongitude = 126.286030f;
        float gpsAltitude = 150f;

        // GPS → Unity 월드 좌표 변환
        targetPosition = GPSConverter.GPSToWorldPosition(gpsLatitude, gpsLongitude, gpsAltitude);
        Debug.Log($"GPS: ({gpsLatitude}, {gpsLongitude}, {gpsAltitude}) -> World: {targetPosition}");
    }

    void Update()
    {
        // 이동 방향 계산 현재위치- 목표위치
        Vector3 direction = targetPosition - transform.position;

        // 드론이 이동할 때 목표를 향해 회전
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction); // 목표 방향 회전값 계산
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime); // 부드러운 회전
        }

        // 드론 이동
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }
}
