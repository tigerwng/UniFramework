/*
 * @Author: zhen wang 
 * @Date: 2017-11-15 15:49:49 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2018-12-14 14:05:24
 */

using System;
using System.IO;
using UnityEngine;


namespace tiger
{
    public static class AssetBundleHelper
    {
        public static string StreamingAssetsFileURL(string relativePath)
        {
#if UNITY_EDITOR
            var path = "file://" + Application.dataPath + "/StreamingAssets";
#elif UNITY_ANDROID
            var path = "jar:file://" + Application.dataPath + "!/assets/";
#else
            var path = Application.streamingAssetsPath;
#endif

            return Path.Combine(path, relativePath);
        }

        static internal string GetBundlePathForLoadFromFile(string relativePath)
        {
#if UNITY_ANDROID && !UNITY_EDITOR
            var streamingAssetsPath = Application.dataPath + "!assets/";
#elif UNITY_IOS && !UNITY_EDITOR
            var streamingAssetsPath = Application.dataPath + "/Raw/";
#else
            var streamingAssetsPath = Application.streamingAssetsPath;
#endif
            return Path.Combine(streamingAssetsPath, relativePath);
        }

        public static AssetBundle LoadBundleFromStreamingAssets(string relativePath)
        {
            var ret = AssetBundle.LoadFromFile(GetBundlePathForLoadFromFile(relativePath));
            
            if(ret == null)
                UniLog.Warning("Warning: Load asset bundle on error (" + relativePath + ")");

            return ret;
        }

        public static AssetBundleCreateRequest LoadBundleAsyncFromStreamingAssets(string relativePath)
        {
            return AssetBundle.LoadFromFileAsync(GetBundlePathForLoadFromFile(relativePath));
        }

    }
}

