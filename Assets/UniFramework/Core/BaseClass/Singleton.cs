/*
 * @Author: zhen wang 
 * @Date: 2018-12-10 11:02:35 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2018-12-14 14:03:10
 */


using System;

namespace zw.UniFramework.Core
{
    public class Singleton<T> where T : class, new()
    {
        protected static T _instance = null;

        public static T Instance
        {
            get
            { 
                if (_instance == null)
                {
                    _instance = new T();
                }
                
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
    }
}