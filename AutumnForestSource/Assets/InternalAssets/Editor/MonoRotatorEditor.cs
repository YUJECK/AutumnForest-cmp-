﻿using AutumnForest.Other;
using UnityEditor;

namespace AutumnForest.EditorScripts
{
    [CustomEditor(typeof(MonoRotator))]
    public sealed class MonoRotatorEditor : Editor
    {
        private MonoRotator monoRotator;

        private SerializedProperty rotateType;
        private SerializedProperty coefficent;
        private SerializedProperty rotateTarget;
        private SerializedProperty asPlayer;

        private void OnEnable()
        {
            monoRotator = target as MonoRotator;

            rotateType = serializedObject.FindProperty("rotateType");
            coefficent = serializedObject.FindProperty("coefficent");
            rotateTarget = serializedObject.FindProperty("target");
            asPlayer = serializedObject.FindProperty("asPlayer");
        }
        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            EditorGUILayout.PropertyField(rotateType);
            EditorGUILayout.PropertyField(coefficent);

            if (monoRotator.RotateType == TransformRotation.RotateType.ByTarget)
            {
                EditorGUILayout.PropertyField(rotateTarget);
                EditorGUILayout.PropertyField(asPlayer);
            }

            serializedObject.ApplyModifiedProperties();
        }
    }
}