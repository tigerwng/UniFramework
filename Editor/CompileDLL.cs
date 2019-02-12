/*
 * @Author: zhen wang 
 * @Date: 2018-12-14 12:10:50 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2018-12-14 14:15:01
 */

using System;
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


namespace tiger
{
    public static class CompileDLL
    {
        [MenuItem("Tools/UniFramework/Compile to DLL")]
        static void CompileToDLL()
        {
            string sourceDirectory = Path.Combine(Application.dataPath, "Add-Ons/UniFramework");

            if(!Directory.Exists(sourceDirectory))
            {
                EditorUtility.DisplayDialog("Compile UniFramework Failed", "UniFramework source folder not exist", "ok");
            }
            
            string[] references = new string[] {
                Path.Combine(EditorApplication.applicationContentsPath, "Mono/lib/mono/2.0/System.dll")
            };
            string[] defines = new string[] {

            };
            string output = Path.Combine(Application.dataPath, "UniFramework/UniFramework.dll");
            List<string> sources = new List<string>();  

            foreach(var p in Directory.GetFiles(sourceDirectory, "*", SearchOption.AllDirectories))
            {
                if(Path.GetExtension(p).Equals(".cs"))
                {
                    Debug.Log("Find source file: " + p);
                    sources.Add(p);
                }
            }

            Debug.Log("Began compile UniFramework ....");

            string[] msgs = EditorUtility.CompileCSharp(sources.ToArray(), references, defines, output);

            foreach (var msg in msgs)
            {
                Debug.Log(msg);
            }

            AssetDatabase.Refresh();
        }
    }
}
