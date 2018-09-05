/*
 * @Author: zhen wang 
 * @Date: 2018-08-09 10:21:17 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2018-08-09 10:29:35
 */

using System.Text;

public static class ArrayExtension
{

    /// <summary>
    /// return string about the array's value
    /// </summary>
    /// <param name="array"></param>
    /// <typeparam name="T"></typeparam>
    /// <returns>one element by one line</returns>
    public static string ToString<T>(this T[] array)
    {
        StringBuilder sb = new StringBuilder();

        foreach(var t in array)
        {
            sb.AppendLine(t.ToString());
        }

        return sb.ToString();
    }
}