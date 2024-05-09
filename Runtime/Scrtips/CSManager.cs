using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CSManager : MonoBehaviour
{
    protected List<ComputeBuffer> buffers;
    protected List<RenderTexture> textures;

    protected void SwapTex(ref RenderTexture tex1, ref RenderTexture tex2)
    {
        RenderTexture tmp = tex1;
        tex1 = tex2;
        tex2 = tmp;
    }

    protected RenderTexture CreateTexture(Vector2 rez, FilterMode filterMode, RenderTextureFormat format)
    {
        RenderTexture texture = new RenderTexture((int)rez.x, (int)rez.y, 1, format);
        texture.enableRandomWrite = true;
        // texture.dimension = UnityEngine.Rendering.TextureDimension.Tex2D;
        texture.filterMode = filterMode;
        texture.wrapMode = TextureWrapMode.Repeat;
        // texture.autoGenerateMips = false;
        texture.useMipMap = false;
        texture.Create();
        textures.Add(texture);

        return texture;
    }

    protected void Release()
    {
        if (buffers != null)
        {
            foreach (ComputeBuffer buffer in buffers)
            {
                if (buffer != null)
                    buffer.Release();
            }
        }

        buffers = new List<ComputeBuffer>();

        if (textures != null)
        {
            foreach (RenderTexture tex in textures)
            {
                if (tex != null)
                    tex.Release();
            }
        }

        textures = new List<RenderTexture>();
    }

    protected virtual void OnDestroy()
    {
        Release();
    }

    protected virtual void OnEnable()
    {
        Release();
    }

    protected virtual void OnDisable()
    {
        Release();
    }
}