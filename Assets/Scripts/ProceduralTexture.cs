using UnityEngine;

public class ProceduralTexture : MonoBehaviour
{
    public int textureSize = 256;
    public float scale = 20f;
    private Texture2D texture;

    void Start()
    {
        texture = new Texture2D(textureSize, textureSize);
        GenerateTexture();
        GetComponent<Renderer>().material.mainTexture = texture;
    }

    void GenerateTexture()
    {
        for (int y = 0; y < textureSize; y++)
        {
            for (int x = 0; x < textureSize; x++)
            {
                float xCoord = (float)x / textureSize * scale;
                float yCoord = (float)y / textureSize * scale;
                float sample = Mathf.PerlinNoise(xCoord, yCoord);
                Color color = new Color(sample, sample, sample);
                texture.SetPixel(x, y, color);
            }
        }
        texture.Apply();
    }
}
