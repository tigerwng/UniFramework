using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using tiger;

[CustomEditor(typeof(ToggleButton), true)]
[CanEditMultipleObjects]
public class ToggleButtonEditor : Editor
{
        private SerializedObject m_serializedObject;

        private SerializedProperty m_InteractableProperty;

        private SerializedProperty m_ColorBlockProperty;
        private SerializedProperty m_OnClickProperty;

        private SerializedProperty m_onSourceProperty;
        private SerializedProperty m_offSourceProperty;

        private SerializedProperty m_TargetGraphicProperty;

        private SerializedProperty m_IsOnProperty;

        void OnEnable()
        {
            m_serializedObject = new SerializedObject(target);
            
            m_InteractableProperty  = m_serializedObject.FindProperty("m_Interactable");
            m_OnClickProperty       = m_serializedObject.FindProperty("m_OnClick");
            m_ColorBlockProperty    = m_serializedObject.FindProperty("m_Colors");

            m_onSourceProperty      = m_serializedObject.FindProperty("m_onSource");
            m_offSourceProperty     = m_serializedObject.FindProperty("m_offSource");

            m_TargetGraphicProperty = m_serializedObject.FindProperty("m_TargetGraphic");

            m_IsOnProperty          = m_serializedObject.FindProperty("m_isOn");
        }

        public override void OnInspectorGUI()
        {
            m_serializedObject.Update();

            EditorGUILayout.PropertyField(m_InteractableProperty);

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(m_IsOnProperty);

            var graphic = m_TargetGraphicProperty.objectReferenceValue as Graphic;
            if (graphic == null)
            {
                graphic = (target as Selectable).GetComponent<Graphic>();
            }

            EditorGUILayout.PropertyField(m_TargetGraphicProperty);
            EditorGUILayout.PropertyField(m_onSourceProperty);
            EditorGUILayout.PropertyField(m_offSourceProperty);

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(m_ColorBlockProperty);

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(m_OnClickProperty);
            
            m_serializedObject.ApplyModifiedProperties();
        }

}