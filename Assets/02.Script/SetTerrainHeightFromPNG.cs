using UnityEngine;

public class SetTerrainHeightFromPNG : MonoBehaviour
{
    public Texture2D HeightMap;

    [ContextMenu("SetHeight")]
    public void SetHeight()
    {
        TerrainData terrainData = GetComponent<Terrain>().terrainData;

        int terrainWidth = terrainData.heightmapResolution;
        int terrainHeight = terrainData.heightmapResolution;
        float[,] heightValues = new float[terrainWidth, terrainHeight];

        for (int y = 0; y < terrainHeight; y++)
        {
            for (int x = 0; x < terrainWidth; x++)
            {
                // Normalized coordinates (0 to 1)
                float normalizedX = (float)x / (terrainWidth - 1);
                float normalizedY = (float)y / (terrainHeight - 1);

                // Convert normalized coordinates to HeightMap coordinates
                int heightMapX = Mathf.RoundToInt(normalizedX * (HeightMap.width - 1));
                int heightMapY = Mathf.RoundToInt(normalizedY * (HeightMap.height - 1));

                // Get the pixel color from the height map
                Color heightColor = HeightMap.GetPixel(heightMapX, heightMapY);

                // Use the red channel (or grayscale value) to set the height
                heightValues[y, x] = heightColor.r;
            }
        }

        terrainData.SetHeights(0, 0, heightValues);
    }
}
