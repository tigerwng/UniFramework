/*
 * 单例类
 *  * 单例类
 * 创建unity脚本单例类，并加载在与类型同名的对象上。
 * @Author: zhen wang 
 * @Date: 2019-04-15 16:30:56 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2019-04-15 16:42:46
 */


using UnityEngine;
using System.Collections;


namespace zw.uniframework.Core
{
    /// <summary>
    /// 单例类 - 单例对象，用于唯一的游戏对象
    /// </summary>
    /// <typeparam name="T">单例类型</typeparam>
    public class SingletonGameObject<T> : MonoBehaviour where T : MonoBehaviour
    {
        
#region Static Instance Member
        private static T instance = null;
#endregion

#region Static Member Property
        /// <summary>
        /// 获取单例实例对象，对实例变量值是空时：
        /// 1. 首先检查场景内是否有挂载脚本的游戏对象
        /// 2. 如果不存在的话，创建一个新的游戏对象并添加单例脚本
        /// </summary>
        /// <value>静态单例对象</value>
        public static T Instance
        {
            get
            {
                if(instance == null)
                {
                    var obj = GameObject.FindObjectOfType<T>();
                    if(obj)
                    {
                        instance = obj;
                    }
                    else
                    {
                        instance = new GameObject(typeof(T).Name).AddComponent<T>();
                    }
                }

                return instance;
            }
        }
#endregion

#region Static Method
        public static void DestoryInstance()
        {
            if(instance != null)
            {
                Destroy(instance.gameObject);
                instance = null;
            }
        }
#endregion

#region Unity Method
        protected virtual void Start()
        {
            DontDestroyOnLoad(gameObject);
        }

        void OnApplicationQuit()
        {
            DestoryInstance();
        }
#endregion
    }
}