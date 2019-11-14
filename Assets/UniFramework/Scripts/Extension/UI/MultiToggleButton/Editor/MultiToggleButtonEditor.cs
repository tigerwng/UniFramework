/*
 * @Author: zhen wang 
 * @Date: 2018-12-14 14:04:03 
 * @Last Modified by:   zhen wang 
 * @Last Modified time: 2018-12-14 14:04:03 
 */


using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using zw.uniframework.Extension.UI;

namespace zw.uniframework.Extension.UI.Editor
{
    [CustomEditor(typeof(zw.uniframework.Extension.UI.MultiToggleButton), true)]
    [CanEditMultipleObjects]
    public class MultiToggleButtonEditor : UnityEditor.Editor
    {
        private SerializedObject m_serializedObject;

        private SerializedProperty m_InteractableProperty;
        private SerializedProperty m_AutoUpdateProperty;
        private SerializedProperty m_OnClickProperty;
        private SerializedProperty m_TargetGraphicProperty;

        private SerializedProperty m_optionsProperty;
        private SerializedProperty m_currentOptionProperty;

        private SerializedProperty m_ColorBlockProperty;

        void OnEnable()
        {
            m_serializedObject = new SerializedObject(target);
            
            m_InteractableProperty = m_serializedObject.FindProperty("m_Interactable");
            m_AutoUpdateProperty = m_serializedObject.FindProperty("m_isAutoUpdate");

            m_OnClickProperty = m_serializedObject.FindProperty("m_OnClick");
            m_TargetGraphicProperty = m_serializedObject.FindProperty("m_TargetGraphic");

            m_optionsProperty = m_serializedObject.FindProperty("m_optionSources");
            m_currentOptionProperty = m_serializedObject.FindProperty("m_curOptionIndex");

            m_ColorBlockProperty    = m_serializedObject.FindProperty("m_Colors");
        }

        public override void OnInspectorGUI()
        {
            // 更新
            m_serializedObject.Update();

            // 开始检查是否有修改
            EditorGUI.BeginChangeCheck();

            EditorGUILayout.PropertyField(m_InteractableProperty);

            EditorGUILayout.PropertyField(m_AutoUpdateProperty);

            EditorGUILayout.Space();

            var graphic = m_TargetGraphicProperty.objectReferenceValue as Graphic;
            if (graphic == null)
            {
                graphic = (target as Selectable).GetComponent<Graphic>();
            }

            EditorGUILayout.PropertyField(m_TargetGraphicProperty);

            // 显示数组或者list的情况下，第二个参数必须为true，否则无法显示子节点
            EditorGUILayout.PropertyField(m_optionsProperty, true);

            EditorGUILayout.PropertyField(m_currentOptionProperty);

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(m_ColorBlockProperty);

            EditorGUILayout.Space();

            EditorGUILayout.PropertyField(m_OnClickProperty);
            
            // 结束检查是否有修改
            if(EditorGUI.EndChangeCheck())
            {
                // 提交修改
                m_serializedObject.ApplyModifiedProperties();
            }
        }

    }
}
