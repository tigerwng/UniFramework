/*
 * @Author: zhen wang 
 * @Date: 2018-06-01 12:26:23 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2018-12-14 14:04:42
 */


using System;
using UnityEngine;
using tiger;


public abstract class UniPooledObject : MonoBehaviour
{
    public UniObjectPoolManager Pool {set;get;}

    public void PushToPool()
    {
        UniLog.CCAssert(Pool!=null, "Pool is not signed");

        Pool.AddToPool(this);
    }
} 