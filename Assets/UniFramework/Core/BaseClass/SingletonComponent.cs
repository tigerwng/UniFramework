/*
 * 单例类
 * 创建unity脚本单例类，未指定加载对象，可自行定义。
 * @Author: zhen wang 
 * @Date: 2018-12-11 17:40:09 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2019-05-13 18:47:38
 */


using System;
using UnityEngine;


namespace zw.UniFramework.Core
{
    public class SingletonComponent<T> : MonoBehaviour where T : MonoBehaviour
    {
        protected static T _instance;

        public static T Instance
        {
            set
            {
                _instance = value;
            }
            get
            {
                return _instance;
            }
        }

        public static void DestoryInstance()
        {
            if(_instance != null)
            {
                _instance = null;
            }
        }


        protected virtual void Start()
        {
            
        }

        protected virtual void OnApplicationQuit()
        {
            DestoryInstance();
        }
    }
}