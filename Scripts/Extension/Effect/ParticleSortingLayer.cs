/*
 * @Author: zhen wang 
 * @Date: 2019-01-27 11:14:04 
 * @Last Modified by: zhen wang
 * @Last Modified time: 2019-01-27 11:24:20
 */


using UnityEngine;


namespace zw.uniframework.Extension.Effect
{
    [ExecuteInEditMode]
    public class ParticleSortingLayer : MonoBehaviour
    {
        public string _layerName;

        public int _layerSorting;



        void OnEnable()
        {
            var particleSystem = transform.GetComponent<ParticleSystem>();
            particleSystem.shape.spriteRenderer.sortingLayerName = _layerName;
            particleSystem.shape.spriteRenderer.sortingOrder = _layerSorting;
        }
    }
}