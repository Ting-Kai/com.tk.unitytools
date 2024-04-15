using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[ExecuteAlways]
public class SimpleBlit : MonoBehaviour
{
    public Material m_mat;
    public RenderTexture m_rt;
    //public Shader shader;
    public bool alwaysUpdate;

    private void Awake()
    {
        BlitTexture();
    }

    private void Update()
    {
        //if (!m_mat) m_mat = new Material(shader);
        //if (!m_rt) m_rt = CreateTexture(new Vector2(128, 128), FilterMode.Point, RenderTextureFormat.ARGB32);

        if (alwaysUpdate) BlitTexture();
    }

    private void BlitTexture()
    {
        if (!m_mat) return;
        if (!m_rt) return;

        Graphics.Blit(null, m_rt, m_mat);
    }

    //private RenderTexture CreateTexture(Vector2 rez, FilterMode filterMode, RenderTextureFormat format)
    //{
    //    RenderTexture texture = new RenderTexture((int)rez.x, (int)rez.y, 1, format);
    //    texture.enableRandomWrite = true;
    //    // texture.dimension = UnityEngine.Rendering.TextureDimension.Tex2D;
    //    texture.filterMode = filterMode;
    //    texture.wrapMode = TextureWrapMode.Repeat;
    //    // texture.autoGenerateMips = false;
    //    texture.useMipMap = false;
    //    texture.Create();

    //    return texture;
    //}

    //private void Release()
    //{
    //    if (m_rt != null)
    //    {
    //        m_rt.Release();
    //    }

    //    if (m_rt != null)
    //    {
    //        m_rt.Release();
    //    }
    //}

    //private void OnDestroy()
    //{
    //    Release();
    //}

    //private void OnEnable()
    //{
    //    Release();
    //}

    //private void OnDisable()
    //{
    //    Release();
    //}
}
