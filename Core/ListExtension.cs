/*
 * @Author: zhen wang 
 * @Date: 2018-05-02 09:59:08 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2018-08-09 10:54:29
 */

using System.Collections.Generic;
using System.Text;
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

        public static string ToStringOneElementByOneLine<T>(this List<T> list)
        {
            StringBuilder sb = new StringBuilder();
            for(int i=0; i<list.Count; i++)
            {
                sb.AppendLine(list[i].ToString());
            }

            return sb.ToString();
        }

        public static string ToStringBySeparator<T>(this List<T> list, char separator)
        {
            StringBuilder sb = new StringBuilder();
            for(int i=0; i<list.Count; i++)
            {
                sb.Append(list[i].ToString());

                if(i < list.Count-1)
                {
                    sb.Append(separator);
                }
            }

            return sb.ToString();
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