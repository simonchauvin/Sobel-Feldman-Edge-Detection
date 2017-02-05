using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class EdgeDetection : MonoBehaviour
{
    public Texture2D sourceTexture;

    private Texture2D targetTexture;


    void Start ()
    {
        targetTexture = new Texture2D(sourceTexture.width, sourceTexture.height, TextureFormat.ARGB32, false);

        detect();

        byte[] bytes = targetTexture.EncodeToPNG();
        File.WriteAllBytes(Application.dataPath + "/Textures/target_texture" + ".png", bytes);
    }

    void Update ()
    {
		
	}

    public void detect ()
    {
        Color c, gx, gy;
        for (int i = 0; i < sourceTexture.width; i++)
        {
            for (int j = 0; j < sourceTexture.height; j++)
            {
                gx = sourceTexture.GetPixel(i + 1, j) - sourceTexture.GetPixel(i - 1, j);
                gy = sourceTexture.GetPixel(i, j + 1) - sourceTexture.GetPixel(i, j - 1);

                targetTexture.SetPixel(i, j, new Color(Mathf.Sqrt(gx.r * gx.r + gy.r * gy.r), Mathf.Sqrt(gx.g * gx.g + gy.g * gy.g), Mathf.Sqrt(gx.b * gx.b + gy.b * gy.b)));
            }
        }
    }
}
