using UnityEngine;
using System.Collections;
using UnityEditor;

public class AddObject : MonoBehaviour {

    static string gamestatePath = "Assets/Prefabs/Gamestate.prefab";
    static string canvasPath = "Assets/Prefabs/CanvasUI.prefab";

    /// <summary>
    /// Add Gamestate Object to current scene
    /// </summary>
    public static void AddGamestate(){

        if (GameObject.Find("Gamestate"))
        {
            Debug.Log("GAMESTATE already exists on scene");
        }
        else {
            AddObjectToScene(gamestatePath);
        }
    }

    /// <summary>
    /// Add CanvasUI Object to current scene
    /// </summary>
    public static void AddCanvas()
    {

        if (GameObject.Find("CanvasUI"))
        {
            Debug.Log("CANVASUI already exists on scene");
        }
        else
        {
            AddObjectToScene(canvasPath);
        }
    }

    /// <summary>
    /// Adds an object to current scene
    /// </summary>
    /// <param name="path">Path of the object</param>
    static void AddObjectToScene(string path) {
        Object go;
        go = AssetDatabase.LoadAssetAtPath(path, typeof(GameObject));

        PrefabUtility.InstantiatePrefab(go);
    }
}
