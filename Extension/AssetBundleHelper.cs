/*
 * @Author: zhen wang 
 * @Date: 2017-11-15 15:49:49 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2018-08-06 14:29:11
 */


using UnityEngine;
using System;
using System.IO;

namespace tiger
{
    public sealed class AssetBundleHelper
    {
        static internal string GetBundlePathForLoadFromFile(string relativePath)
        {
        #if UNITY_EDITOR
            var streamingAssetsPath = Application.streamingAssetsPath;
        #elif UNITY_ANDROID
            var streamingAssetsPath = Application.dataPath + "!assets/";
        #elif UNITY_IOS
            var streamingAssetsPath = Application.dataPath + "/Raw/";
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

