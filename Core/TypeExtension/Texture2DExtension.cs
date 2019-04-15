/*
 * @Author: zhen wang 
 * @Date: 2018-06-01 15:15:02 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2018-12-14 14:03:40
 */

using System;
using UnityEngine;



public static class Texture2DExtension
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

    public static Sprite ConvertToSprite(this Texture2D self, Rect rect, Vector2 pivot)
    {
        return Sprite.Create(self, rect, pivot);
    }
}
