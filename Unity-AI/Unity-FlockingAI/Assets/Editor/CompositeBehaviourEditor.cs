using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CompositeBehaviour))]
public class CompositeBehaviourEditor : Editor
{
    SerializedObject classObject;
    SerializedProperty compBehav;
    SerializedProperty weights;

    private void OnEnable()
    {
        classObject = new SerializedObject(target);
        compBehav = classObject.FindProperty("behaviours");
        weights = classObject.FindProperty("weights");
    }

    public override void OnInspectorGUI()
    {
        classObject.Update();
        EditorGUIUtility.labelWidth = 100.0f;

        EditorGUILayout.BeginVertical();

        if (compBehav == null || compBehav.arraySize <= 0)
        {
            EditorGUILayout.HelpBox("Flocking Behaviours is Empty", MessageType.Warning);
        }
        else
        {
            for (int i = 0; i < compBehav.arraySize; ++i)
            {
                EditorGUILayout.BeginHorizontal();
                EditorGUILayout.ObjectField(compBehav.GetArrayElementAtIndex(i), typeof(FlockBehaviour), new GUIContent("Behaviours " + (i + 1)));
                weights.GetArrayElementAtIndex(i).floatValue = EditorGUILayout.FloatField(new GUIContent("Weights " + (i + 1)), weights.GetArrayElementAtIndex(i).floatValue);
                EditorGUILayout.EndHorizontal();
                GUILayout.Space(5.0f);
            }
        }

        if (GUILayout.Button(new GUIContent("Add Behaviours")))
        {
            AddBehaviours();
        }
        else if (GUILayout.Button(new GUIContent("Remove Behaviours")))
        {
            RemoveBehaviours();
        }

        EditorGUILayout.EndVertical();
        classObject.ApplyModifiedProperties();
    }

    private void AddBehaviours()
    {
        Debug.Log("Add Behaviour");
    }
    private void RemoveBehaviours()
    {
        Debug.Log("Remove Behaviour");
    }
}
