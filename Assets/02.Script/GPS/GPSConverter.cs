using UnityEngine;


namespace Utilities
{ 
    public class GPSConverter
    {
        // GPS ��谪 (����, �浵)
        public static Vector2 topLeftGPS = new Vector2(37.277144f, 126.271944f);  // �ϼ���
        public static Vector2 bottomRightGPS = new Vector2(37.241341f, 126.348519f);  // ������

        // Terrain ũ��
        public static Vector2 terrainSize = new Vector2(7200f, 4000f);  // Terrain�� ũ�� (X, Z)

        // GPS �� Unity ���� ��ǥ ��ȯ �Լ�
        public static Vector3 GPSToWorldPosition(float latitude, float longitude, float altitude)
        {
            // X��: �浵 �� Unity X��
            float x = Mathf.InverseLerp(bottomRightGPS.y, topLeftGPS.y, longitude) * terrainSize.x;
            // Z��: ���� �� Unity Z��
            float z = Mathf.InverseLerp(bottomRightGPS.x, topLeftGPS.x, latitude) * terrainSize.y;
            // Y��: �� �� Unity Y��
            return new Vector3(x, altitude, z);
        }

        // Unity ���� ��ǥ �� GPS ��ȯ �Լ�
        public static Vector3 WorldPositionToGPS(float x, float z, float altitude)
        {
            float longitude = Mathf.Lerp(bottomRightGPS.y, topLeftGPS.y, x / terrainSize.x);
            float latitude = Mathf.Lerp(bottomRightGPS.x, topLeftGPS.x, z / terrainSize.y);
            return new Vector3(latitude, longitude, altitude);
        }
    }
}