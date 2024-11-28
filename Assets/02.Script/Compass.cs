using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Compass : MonoBehaviour
{
    public RectTransform compassUI; // ��ħ�� UI (Image)
 

    void Update()
    {
        // ����� ���� ���� ����
        Vector3 forward = transform.forward;

        // ��� ���� ��� (X, Z ��� ����)
        float headingAngle = Mathf.Atan2(forward.x, forward.z) * Mathf.Rad2Deg;

        // ������ 0~360���� ��ȯ
        if (headingAngle < 0) headingAngle += 360;

        Debug.Log($"Drone Heading Angle: {headingAngle}��");
    }
}
