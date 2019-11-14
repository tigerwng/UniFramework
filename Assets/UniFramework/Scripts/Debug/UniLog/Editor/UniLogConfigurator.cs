/*
 * @Author: zhen wang 
 * @Date: 2018-12-14 14:39:45 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2018-12-14 14:42:57
 */

using System;
using System.Collections.Generic;
using UnityEditor;


namespace zw.UniFramework
{
    public class UniLogConfigurator
    {
        readonly static string DEBUG_DEFINE = "UNILOG_DEBUG";
        readonly static string MENU_PATH = "Tools/UniFramework/Enable UniLog";


        [MenuItem("Tools/UniFramework/Enable UniLog")]
        private static void EnableDebugMode()
        {
            var defines = new List<string>(PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup).Split(';'));
            bool isChecked = Menu.GetChecked(menuPath: MENU_PATH);

            if(isChecked)
            {
                defines.Remove(DEBUG_DEFINE);
                EditorPrefs.SetBool(MENU_PATH, false);
            }
            else
            {
                defines.Add(DEBUG_DEFINE);
                EditorPrefs.SetBool(MENU_PATH, true);
            }
            
            PlayerSettings.SetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup, string.Join(";", defines.ToArray()));
        }

        [MenuItem("Tools/UniFramework/Enable UniLog", true)]
        private static bool CheckDebugMode()
        {
            var defines = new List<string>(PlayerSettings.GetScriptingDefineSymbolsForGroup(EditorUserBuildSettings.selectedBuildTargetGroup).Split(';'));

            if(string.IsNullOrWhiteSpace(defines.Find(x => x.Equals(DEBUG_DEFINE))))
            {
                Menu.SetChecked(MENU_PATH, false);
            }
            else
            {
                Menu.SetChecked(MENU_PATH, true);
            }

            return true;
        }
    }
}