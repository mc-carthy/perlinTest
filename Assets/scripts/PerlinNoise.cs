using UnityEngine;

public class PerlinNoise : MonoBehaviour {

    [SerializeField]
    private float scale;
    [SerializeField]
    private float xOffset, yOffset;

	private int width = 256;
	private int height = 256;
    private Renderer ren;

    private void Awake()
    {
        ren = GetComponent<Renderer>();
    }

    private void Update()
    {
        ren.material.mainTexture = GenereateTexture();
    }

    private Texture2D GenereateTexture()
    {
        Texture2D tex = new Texture2D(width, height);

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                Color texColour = CalculateColor(x, y);
                tex.SetPixel(x, y, texColour);
            }
        }

        tex.Apply();

        return tex;
    }

    private Color CalculateColor(int x, int y)
    {
        float xCoord = (float)x / width * scale + xOffset;
        float yCoord = (float)y / height * scale + yOffset;
        
        float sample = Mathf.PerlinNoise(xCoord, yCoord);

        return new Color(sample, sample, sample);
    }

}
