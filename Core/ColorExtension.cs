/*
 * @Author: zhen wang 
 * @Date: 2018-07-06 10:34:42 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2018-08-09 10:21:48
 */

using UnityEngine;
using System.Text;

public static class ColorExtension
{
    public static Color Format(this Color color, string format)
    {
        float r, g, b, a;

        r = float.Parse(color.r.ToString(format));
        g = float.Parse(color.g.ToString(format));
        b = float.Parse(color.b.ToString(format));
        a = float.Parse(color.a.ToString(format));

        return new Color(r, g, b, a);
    }

    public static int SortColors(Color a, Color b)
    {
        if (a.r < b.r)
            return 1;
        else if (a.r > b.r)
            return -1;
        else 
        {
            if (a.g < b.g)
                return 1;
            else if (a.g > b.g)
                return -1;
            else 
            {
                if (a.b < b.b)
                    return 1;
                else if (a.b > b.b)
                    return -1;
            }
        }

        return 0;
    }

    public static bool IsSame(this Color a, Color b, float threshold = 0.01f)
    {
        if(Mathf.Abs(a.r - b.r) >= threshold)
        {
            return false;
        }
        
        if(Mathf.Abs(a.g - b.g) >= threshold)
        {
            return false;
        }

        if(Mathf.Abs(a.b - b.b) >= threshold)
        {
            return false;
        }

        if(Mathf.Abs(a.a - b.a) >= threshold)
        {
            return false;
        }

        return true;
    }


    public static Color Color2Grey(this Color color, float contrast=1.0f)
    {
        float gray = color.grayscale * contrast;

        return new Color(gray, gray, gray, 1);
    }

}

