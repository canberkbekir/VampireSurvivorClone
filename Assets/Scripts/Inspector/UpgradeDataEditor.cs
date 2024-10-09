using UnityEngine;
using UnityEditor;
using Upgrades;

namespace Inspector
{
    [CustomEditor(typeof(UpgradeData))]
    public class UpgradeDataEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            // Get the target object (UpgradeData in this case)
            var upgradeData = (UpgradeData)target;

            // Display the default fields
            EditorGUILayout.PropertyField(serializedObject.FindProperty("type"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("title"));
            EditorGUILayout.PropertyField(serializedObject.FindProperty("description"));

            switch (upgradeData.Type)
            {
                // Conditionally display the weapon or stat fields
                case UpgradeType.WeaponUpgrade:
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("weaponData"), new GUIContent("Weapon Data"));
                    break;
                case UpgradeType.StatUpgrade:
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("statType"), new GUIContent("Stat Type"));
                    EditorGUILayout.PropertyField(serializedObject.FindProperty("statValue"), new GUIContent("Stat Value"));
                    break;
            }

            // Apply the changes made in the inspector
            serializedObject.ApplyModifiedProperties();
        }
    }
}
