/*
 * @Author: zhen wang 
 * @Date: 2018-11-20 11:39:05 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2018-12-14 14:03:20
 */

using System;
using UnityEngine;

namespace tiger.Core
{
    public class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T _instance = null;

        public static T Instance
        {
            get
            {
                if(_instance == null)
                {
                    GameObject obj = new GameObject(typeof(T).Name);
                    _instance = obj.AddComponent<T>();
                }

                return _instance;
            }
        }

        public static void DestoryInstance()
        {
            if(_instance != null)
            {
                Destroy(_instance.gameObject);
                _instance = null;
            }
        }

        protected virtual void Start()
        {
            DontDestroyOnLoad(_instance.gameObject);
        }

        void OnApplicationQuit()
        {
            DestoryInstance();
        }
    }
}

