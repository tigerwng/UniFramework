/*
 * @Author: zhen wang 
 * @Date: 2018-11-26 13:04:12 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2019-01-04 19:57:41
 */

using System;
using System.Text;
using UnityEngine;


namespace tiger
{
    public static class NumberExtension
    {
        public static string KiloFormat(float num)
        {
            //max: 9999000000
            num = Mathf.Clamp(num, 0, 9999000000);

            if(num >= 9999000000)
                return (num / 1000000).ToString("#,0M") + "+";

            if (num >= 100000000)
                return (num / 1000000).ToString("#,0M");

            if (num >= 10000000)
                return (num / 1000000).ToString("0.#") + "M";

            if (num >= 100000)
                return (num / 1000).ToString("#,0K");

            if (num >= 10000)
                return (num / 1000).ToString("0.#") + "K";

            return string.Format("{0:N2}", num);
        } 

        /// <summary>
        /// 数字字符串缩写转换
        /// </summary>
        /// <param name="value">必须为正整数的字符串</param>
        /// <param name="digit">缩写规则</param>
        /// <param name="splits">数字单位 k, m, g, t...etc</param>
        public static string FormatPositiveIntegerAbbreviation(string value, float digit, char[] splits=null)
        {
            try
            {
                if(splits == null)
                {
                    splits = new char[]{'K', 'M', 'G', 'T'};
                }

                ulong v = Convert.ToUInt64(value);
                
                double t = v;

                int splitIndex = 0;

                if(v < digit)
                {
                    return value;
                }
                
                while(true)
                {
                    if(t / digit >= 1 && splitIndex < splits.Length)
                    {
                        t /= digit;
                        splitIndex++;
                    }
                    else
                    {
                        var s1 = (Math.Truncate(t * 100) / 100).ToString();

                        if(s1.Length > 5 && splitIndex < splits.Length)
                        {
                            t /= digit;
                            splitIndex++;
                        }

                        break;
                    }
                }

                string ret = ((Math.Truncate(t * 100) / 100).ToString() + splits[splitIndex-1]);
                return ret;
            }
            catch(IndexOutOfRangeException e)
            {
                throw new Exception("NumberExtension:FormatPositiveIntegerAbbreviation -> Failed (array index out range");
            }
            catch(FormatException e)
            {
                throw new Exception("NumberExtension:FormatPositiveIntegerAbbreviation -> Failed (Number must be a value type)");
            }
            catch(Exception e)
            {
                throw new Exception("NumberExtension:FormatPositiveIntegerAbbreviation -> Failed (" + e.Message + ")");
            }
        }
    }    
}
