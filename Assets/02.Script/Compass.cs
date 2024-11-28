using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public RectTransform compassUI; // 나침반 UI (Image)

    void Update()
    {
        // 드론의 현재 방향 벡터
        Vector3 forward = transform.forward;

        // 헤딩 각도 계산 (X, Z 평면 기준)
        float headingAngle = Mathf.Atan2(forward.x, forward.z) * Mathf.Rad2Deg;

        // 각도를 0~360도로 변환
        if (headingAngle < 0) headingAngle += 360;

        // 나침반 UI 회전 (headingAngle을 반대로 적용)
        compassUI.localEulerAngles = new Vector3(0, 0, headingAngle);

        //Debug.Log($"Drone Heading Angle: {headingAngle}°");
    }
}
