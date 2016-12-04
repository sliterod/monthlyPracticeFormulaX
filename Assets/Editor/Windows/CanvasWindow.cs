using UnityEngine;
using System.Collections;
using UnityEditor;

public class CanvasWindow : EditorWindow {

    [MenuItem("SceneObjects/Add CANVAS to Scene")]
    static void Init()
    {
        Debug.Log("Adding Canvas UI Object to current scene");
        AddObject.AddCanvas();
    }
}
