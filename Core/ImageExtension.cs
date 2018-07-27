/*
 * @Author: zhen wang 
 * @Date: 2018-06-01 15:15:02 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2018-06-01 15:28:10
 */


/*
 * @Author: zhen wang 
 * @Date: 2018-03-13 16:50:54 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2018-03-13 16:51:23
 */


using UnityEngine;
using System;


public static class ImageExtension
{
    public static Texture2D CloneTexture2D(this Texture2D self)
    {
        // create a render texture and size same res
        RenderTexture tmp = RenderTexture.GetTemporary(
                                self.width, 
                                self.height,
                                0,
                                RenderTextureFormat.Default,
                                RenderTextureReadWrite.Linear);

        // copy pixel data into render texture
        Graphics.Blit(self, tmp);

        // backup current render texture
        RenderTexture previous = RenderTexture.active;

        // set current render texture use new one
        RenderTexture.active = tmp;

        // create a texture2d and copy pixels
        Texture2D copy = new Texture2D(self.width, self.height);
        copy.ReadPixels(new Rect(0, 0, tmp.width, tmp.height), 0, 0);
        copy.Apply();

        // reset current render texture
        RenderTexture.active = previous;

        // destory temp render texture object
        RenderTexture.ReleaseTemporary(tmp);

        return copy;
    }

    public static Color Color2Grey(Color color)
    {
        var rgb = new Vector3(color.r, color.g, color.b) * 255;

        // Byte y = Convert.ToByte(Vector3.Dot(rgb, new Vector3(0.299f, 0.587f, 0.114f)));

        Byte u = Convert.ToByte(Vector3.Dot(rgb, new Vector3(0.1687f, -0.3313f, 0.5f)) + 128);

        // Byte v = Convert.ToByte(Vector3.Dot(rgb, new Vector3(0.5f, -0.4187f, 0.0813f)) + 128);

        return new Color32(u, u, u, 255);
    }

    public static Sprite ConvertToSprite(this Texture2D self, Rect rect, Vector2 pivot)
    {
        return Sprite.Create(self, rect, pivot);
    }
}
