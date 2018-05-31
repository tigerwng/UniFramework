/*
 * @Author: zhen wang 
 * @Date: 2018-05-15 15:04:14 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2018-05-15 16:34:11
 */


using UnityEngine;
using System.Text;

#if UNITY_EDITOR
using UnityEditor;
using System.Collections.Generic;
#endif



namespace tiger
{
    public static class UniLog
    {   
    #if UNITY_EDITOR
        readonly static string DEBUG_DEFINE = "UNILOG_DEBUG";
        readonly static string MENU_PATH = "Tools/UniLog/Enable Debug Mode";
    #endif

        static internal void Info(string msg)
        {
        #if UNILOG_DEBUG
            StringBuilder sb = new StringBuilder();
            sb.Append("<size=20><color=lightblue>").Append(msg).Append("</color></size>");

            Debug.Log(sb.ToString());
        #endif
        }

        static internal void InfoFromat(string format, params object[] args)
        {
        #if UNILOG_DEBUG
            Info(string.Format(format, args));
        #endif
        }

        static internal void Warning(string msg)
        {
        #if UNILOG_DEBUG
            StringBuilder sb = new StringBuilder();
            sb.Append("<size=20><color=orange>").Append(msg).Append("</color></size>");

            Debug.LogWarning(sb.ToString());
        #endif
        }

        static internal void WarningFormat(string format, params object[] args)
        {
        #if UNILOG_DEBUG
            Warning(string.Format(format, args));
        #endif
        }

        static internal void Error(string msg)
        {
        #if UNILOG_DEBUG
            StringBuilder sb = new StringBuilder();
            sb.Append("<size=20><color=red>").Append(msg).Append("</color></size>");

            Debug.LogError(sb.ToString());     
        #endif       
        }

        static internal void Print(string msg)
        {
        #if UNILOG_DEBUG
            StringBuilder sb = new StringBuilder();
            sb.Append("<size=20><color=cyan>").Append(msg).Append("</color></size>");

            MonoBehaviour.print(sb.ToString());
        #endif
        }

        static internal void CCAssert(bool cond, string msg)
        {   
        #if UNILOG_DEBUG
            if(!cond)
            {
                Error("CCASSERT: " + msg);
            }
        #endif
        }


     #if UNITY_EDITOR
        [MenuItem("Tools/UniLog/Enable Debug Mode")]
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

        [MenuItem("Tools/UniLog/Enable Debug Mode", true)]
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
    #endif

    }
}

