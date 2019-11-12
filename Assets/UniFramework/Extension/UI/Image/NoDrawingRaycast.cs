/*
 * @Author: zhen wang 
 * @Date: 2019-04-16 14:40:00 
 * @Last Modified by: zhen wang
 * @Last Modified by: zhen wang
 * @Last Modified time: 2019-04-16 15:27:26
*/

using UnityEngine;
using System.Collections;


namespace zw.UniFramework.Extension.UI
{
    /// <summary>
    /// 代替空的Image使用，不占用overdraw资源，但是可以接收点击事件
    /// </summary>
    public class NoDrawingRaycast : UnityEngine.UI.MaskableGraphic
    {
        protected NoDrawingRaycast()
        {
            useLegacyMeshGeneration = false;
        }

        protected override void OnPopulateMesh(UnityEngine.UI.VertexHelper vh)
        {
            vh.Clear();
        }
    }
}