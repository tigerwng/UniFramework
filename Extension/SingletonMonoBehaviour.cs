/*
 * @Author: zhen wang 
 * @Date: 2018-10-04 12:57:22 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2018-10-04 12:58:16
 */


using UnityEngine;



public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance = null;
    public static T GetInstance()
    {
        if(_instance == null)
        {
            var obj = new GameObject(typeof(T).ToString());
            _instance = obj.AddComponent<T>();
        }

        return _instance;
    }

    public static void DestoryInstance()
    {
        if(_instance)
        {
            Destroy(_instance.gameObject);
            _instance = null;
        }
    }
}