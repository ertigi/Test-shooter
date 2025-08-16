#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

[CustomPropertyDrawer(typeof(SceneReference))]
public class SceneReferenceDrawer : PropertyDrawer
{
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        SerializedProperty scenePathProp = property.FindPropertyRelative("_scenePath");

        EditorGUI.BeginProperty(position, label, property);

        var sceneAsset = string.IsNullOrEmpty(scenePathProp.stringValue)
            ? null
            : AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePathProp.stringValue);

        var newScene = EditorGUI.ObjectField(position, label, sceneAsset, typeof(SceneAsset), false) as SceneAsset;

        if (newScene != null)
        {
            string path = AssetDatabase.GetAssetPath(newScene);
            scenePathProp.stringValue = path;
        }
        else if (sceneAsset != null)
        {
            scenePathProp.stringValue = "";
        }

        EditorGUI.EndProperty();
    }
}
#endif