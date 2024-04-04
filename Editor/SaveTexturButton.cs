using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SaveTextureFile))]
public class SaveTexturButton : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        SaveTextureFile saveTextureFile = (SaveTextureFile)target;
        if(GUILayout.Button("Save Texture"))
        {
            saveTextureFile.SaveFile();
        }
    }
}
