using UnityEngine;
using System.Collections;
using UnityEditor;

public class GamestateWindow : EditorWindow {

    [MenuItem("SceneObjects/Add GAMESTATE to Scene")]
    static void Init() {
        Debug.Log("Adding Gamestate Object to current scene");
        AddObject.AddGamestate();
    }
}
