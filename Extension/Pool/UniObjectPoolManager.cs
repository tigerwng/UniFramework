/*
 * @Author: zhen wang 
 * @Date: 2018-06-01 12:00:43 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2018-12-14 14:04:33
 */

using System;
using System.Collections.Generic;
using UnityEngine;
using zw.UniFramework;

public sealed class UniObjectPoolManager : MonoBehaviour
{
    public GameObject m_prefab;

    public int m_minCapacity;

    public List<UniPooledObject> m_availabilityElements = new List<UniPooledObject>();




    [ContextMenu("init pool")]
    void InitPool()
    {
        UniLog.CCAssert(m_availabilityElements.Count==0, "Can not initialized pool, because this pool is not empty");

        UniLog.CCAssert(m_prefab!=null, "Found error when initialize pool, case by prefab is null");

        if(m_availabilityElements == null)
        {
            m_availabilityElements = new List<UniPooledObject>();
        }

        for (int i = 0; i < m_minCapacity; i++)
        {
            var obj = Instantiate(m_prefab, transform);
            obj.SetActive(false);
            
            UniPooledObject t = null;
            if(t = obj.GetComponent<UniPooledObject>())
            {
                t.Pool = this;
                m_availabilityElements.Add(t);
            }
        }
    }

    public UniPooledObject GetPooledObjectInstance()
    {
        UniPooledObject ret = null;

        if(m_availabilityElements.Count > 0)
        {
            ret =  m_availabilityElements[0];
            m_availabilityElements.Remove(ret);
        }
        else
        {
            var obj = Instantiate(m_prefab);
            ret = obj.GetComponent<UniPooledObject>();
            ret.Pool = this;
        }

        ret.gameObject.SetActive(true);

        return ret;
    }

    public void AddToPool(UniPooledObject obj)
    {
        obj.gameObject.SetActive(false);
        obj.transform.SetParent(transform);
        
        m_availabilityElements.Add(obj);
    }





    
}