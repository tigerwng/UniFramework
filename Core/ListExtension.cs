/*
 * @Author: zhen wang 
 * @Date: 2018-05-02 09:59:08 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2018-05-02 11:10:05
 */

using System.Collections.Generic;
using UnityEngine;

namespace tiger
{
    public static class ListExtension
    {
        public static void Print<T>(this List<T> list)
        {
            for(int i=0; i<list.Count; i++)
            {
                Debug.LogFormat("list[{0}]: " + list[i].ToString());
            }
        }

        public static string ConvertToString<T>(this List<T> list)
        {
            string ret = "";
            for(int i=0; i<list.Count; i++)
            {
                ret += list[i].ToString();
                ret += "|";
            }

            return ret;
        }

        public static bool IsAllElementsUnique<T>(this List<T> list)
        {
            for(int i=0; i<list.Count; i++)
            {
                var pattern = list[i];

                for(int j=0; j<list.Count; j++)
                {
                    if(j==i)
                    {
                        continue;
                    }

                    if(pattern.ToString().Equals(list[j].ToString()))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        public static void InitFromArray<T>(this List<T> list, T[] array)
        {
            for(int i=0; i<array.Length; i++)
            {
                list.Add(array[i]);
            }
        }
    }
}