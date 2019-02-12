/*
 * @Author: zhen wang 
 * @Date: 2018-02-01 18:07:10 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2018-02-01 18:07:31
 */

using System;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;


namespace tiger
{
    public class StringHelper
    {
        public static string MatchString(string input, string pattern)
		{
			Regex regex = new Regex(pattern);

			return regex.Match(input).Value;
		}

		public static string ReplaceString(string input, string pattern, string replacement)
		{
			string output = Regex.Replace(input, pattern, replacement);
			return output;
		}

		public static string[] SplitString(string input, string split)
		{
			string[] ret = Regex.Split(input, split);

			return ret;
		}

    }
}