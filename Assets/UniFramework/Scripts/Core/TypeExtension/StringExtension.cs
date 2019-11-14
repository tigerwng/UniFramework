/*
 * @Author: zhen wang 
 * @Date: 2018-08-13 12:58:39 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2018-12-14 14:03:25
 */

using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace zw.uniframework
{
    public static class StringExtension
    {
        public static string RemoveElementFromString(this string str, string element, params char[] separator)
        {
            // split string
            // convert to list
            // remove current cell's index
            List<string> list = new List<string>();
            list.InitFromArray(str.Split(separator));
            list.Remove(element.ToString());

            // clear string
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < list.Count; i++)
            {
                sb.Append(list[i].ToString());

                if (i != list.Count - 1)
                {
                    sb.Append(separator);
                }
            }

            return sb.ToString();
        }

        public static string AddElementWithString(this string str, string element, params char[] separator)
        {
            List<string> list = new List<string>();
            list.InitFromArray(str.Split(separator));
            
            if(!list.Contains(element))
            {
                list.Add(element);
            }
            else
            {
                UniLog.WarningFormat("[{0}] has already exist in string [{1}]", element, str);
            }

            // clear string
            StringBuilder sb = new StringBuilder();

            for(int i=0; i<list.Count; i++)
            {
                sb.Append(list[i]);

                if(i < list.Count-1)
                {
                    sb.Append(separator);
                }
            }

            return sb.ToString();
        }
   
    }

}