
/*
 * @Author: zhen wang 
 * @Date: 2018-12-11 17:40:09 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2018-12-11 17:45:26
 */


using UnityEngine;


namespace tiger.Core
{
    public class SingletonAssetMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
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
    }
}