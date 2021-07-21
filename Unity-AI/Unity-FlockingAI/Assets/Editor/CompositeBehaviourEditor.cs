using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(CompositeBehaviour))]
public class CompositeBehaviourEditor : Editor
{
    SerializedObject serialized_object;
    SerializedProperty compBehav;
    SerializedProperty weights;

    private void OnEnable()
    {
        serialized_object = new SerializedObject(target);
        compBehav = serialized_object.FindProperty(Globals.behaviours);
        weights = serialized_object.FindProperty(Globals.weights);
    }

    public override void OnInspectorGUI()
    {
        //DrawDefaultInspector();
        serialized_object.Update();
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
            AddBehaviours(compBehav, weights);
        }
        else if (GUILayout.Button(new GUIContent("Remove Behaviours")))
        {
            RemoveBehaviours(compBehav, weights);
        }

        //if (EditorGUI.EndChangeCheck())
        //{
        //    EditorUtility.SetDirty(target);
        //}

        EditorGUILayout.EndVertical();
        serialized_object.ApplyModifiedProperties();
    }

    private void AddBehaviours(params SerializedProperty[] orig)
    {
        if (orig.Length < 2) return;

        orig[0].arraySize += 1;
        orig[0].GetArrayElementAtIndex(orig[0].arraySize - 1).objectReferenceValue = default;

        orig[1].arraySize += 1;
        orig[1].GetArrayElementAtIndex(orig[1].arraySize - 1).floatValue = 0;
    }
    private void RemoveBehaviours(params SerializedProperty[] orig)
    {
        if (orig.Length < 2) return;

        orig[0].DeleteArrayElementAtIndex(orig[0].arraySize - 1);
        orig[1].DeleteArrayElementAtIndex(orig[1].arraySize - 1);
    }
}
