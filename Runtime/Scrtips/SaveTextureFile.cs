using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class SaveTextureFile : MonoBehaviour
{
    public RenderTexture RT;
    public string folderPath;
    public TextureCapture.SaveTextureFileFormat format = TextureCapture.SaveTextureFileFormat.PNG;

    private void Start()
    {
        Debug.Log(Texture.allowThreadedTextureCreation);
    }

    public void SaveFile()
    {
        if (!RT) return;

        if (string.IsNullOrEmpty(folderPath))
        {
            string textureFolde = $"{Application.dataPath}\\_Texture";
            if (!Directory.Exists(textureFolde)) Directory.CreateDirectory(textureFolde);
            folderPath = textureFolde;
        }

        string fileName = DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss");
        TextureCapture.SaveTextureToFile(RT, $"{folderPath}\\{fileName}.{format.ToString().ToLower()}", RT.width, RT.height, format);
        Debug.Log($"Complete Save Texture");
    }
}
