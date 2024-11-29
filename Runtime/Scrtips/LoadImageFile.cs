using System.Collections;
using UnityEngine;
using UnityEngine.Networking;

public class LoadImageFile : MonoBehaviour
{
    public static LoadImageFile Instance
    {
        get
        {
            var component = GameObject.FindAnyObjectByType<LoadImageFile>();
            if(component == null)
            {
                var obj = new GameObject("LoadImageFile (Instance)");
                component = obj.AddComponent<LoadImageFile>();
            }
            return component;
        }
    }

    public void Load(string filePath, System.Action<Texture2D> callback)
    {
        this.StartCoroutine(LoadFile(filePath,callback));
    }

    IEnumerator LoadFile(string file, System.Action<Texture2D> callback)
    {
        UnityWebRequest request = UnityWebRequestTexture.GetTexture(file);

        yield return request.SendWebRequest();

        Texture2D result = null;
        if (string.IsNullOrEmpty(request.error))
        {
            result = DownloadHandlerTexture.GetContent(request);
        }
        else
        {
            Debug.Log(request.error);
        }

        callback?.Invoke(result);
    }
}
