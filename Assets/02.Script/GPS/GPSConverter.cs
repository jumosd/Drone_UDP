using UnityEngine;

namespace Utilities
{
    public class GPSConverter
    {
        // GPS 경계값 (위도, 경도)
        public static Vector2 topLeftGPS = new Vector2(37.278003f, 126.270668f);  // 북서단
        public static Vector2 bottomRightGPS = new Vector2(37.240665f, 126.352886f);  // 남동단

        // Terrain 크기
        public static Vector2 terrainSize = new Vector2(7200f, 4000f);  // Terrain의 크기 (X, Z)

        // GPS → Unity 월드 좌표 변환 함수
        public static Vector3 GPSToWorldPosition(float latitude, float longitude, float altitude)
        {
            // Z축: 위도 → Unity Z축
            float z = Mathf.InverseLerp(bottomRightGPS.x, topLeftGPS.x, latitude) * terrainSize.y;
            // X축: 경도 → Unity X축
            float x = Mathf.InverseLerp(topLeftGPS.y, bottomRightGPS.y, longitude) * terrainSize.x;
            // Y축: 고도 → Unity Y축
            return new Vector3(x, altitude, z);
        }


        // Unity 월드 좌표 → GPS 변환 함수
        public static Vector3 WorldPositionToGPS(float x, float z, float altitude)
        {
            float longitude = Mathf.Lerp(bottomRightGPS.y, topLeftGPS.y, x / terrainSize.x);
            float latitude = Mathf.Lerp(bottomRightGPS.x, topLeftGPS.x, z / terrainSize.y);
            return new Vector3(latitude, longitude, altitude);
        }
    }
}
