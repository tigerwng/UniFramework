/*
 * @Author: zhen wang 
 * @Date: 2018-12-14 14:04:59 
 * @Last Modified by:   zhen wang 
 * @Last Modified time: 2018-12-14 14:04:59 
 */

using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

#if AADOTWEEN
using DG.Tweening;
#endif

using CALL_BACL = System.Action<string>;



namespace zw.uniframework.Extension.UI
{
    public class Toast : MonoBehaviour
    {
        public bool AUTO_HIDE {set;get;}
        public float DURATION {set;get;}

        public CALL_BACL d_msgDelegate = null;

        public CALL_BACL MESSAGE_DELEGAET{
            set
            {
                d_msgDelegate = value;
            }
        }


        public static Toast Create(RectTransform parent, bool autoHide, float duration)
        {
            var obj = new GameObject("UIToast");

            var img = obj.AddComponent<Image>();
            img.sprite = null;
            img.color = new Color(0, 0, 0, 1);
            img.raycastTarget = false;

            var ret = obj.AddComponent<Toast>();
            ret.AUTO_HIDE = autoHide;
            ret.DURATION = duration;

            var rt = obj.GetComponent<RectTransform>();
            rt.SetParent(parent);
            rt.anchorMin = new Vector2(0, 0);
            rt.anchorMax = new Vector2(1, 0);
            rt.offsetMin = new Vector2(50, 0);
            rt.offsetMax = new Vector2(-50, 80);
            rt.pivot = new Vector2(0.5f, 0);
            rt.anchoredPosition3D = new Vector3(0, 20, 0);
            rt.localScale = Vector3.one;

            var cg = obj.AddComponent<CanvasGroup>();
            cg.alpha = 0.0f;

            var text = (new GameObject("text")).AddComponent<Text>();
            text.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            text.fontSize = 40;
            text.text = "";
            text.supportRichText = false;
            text.alignment = TextAnchor.MiddleCenter;
            text.alignByGeometry = true;
            text.resizeTextForBestFit = true;
            text.resizeTextMaxSize = 40;
            text.resizeTextMinSize = 10;
            text.color = new Color(1, 1, 1, 1);
            text.raycastTarget = false;

            var textRT = text.GetComponent<RectTransform>();
            textRT.SetParent(rt);
            textRT.anchoredPosition3D = new Vector3(0, 0, 0);
            textRT.anchorMin = new Vector2(0, 0);
            textRT.anchorMax = new Vector2(1, 1);
            textRT.offsetMin = new Vector2(8, 8);
            textRT.offsetMax = new Vector2(-8, -8);
            textRT.pivot = new Vector2(0.5f, 0.5f);
            textRT.localScale = Vector3.one;

            return ret;
        }

        void OnDestroy()
        {
            d_msgDelegate = null;
        }

        public void SetMessage(string msg)
        {
            var msgText = transform.Find("text").GetComponent<Text>();
            msgText.text = msg;
        }

        public void Show()
        {
            var cg = transform.GetComponent<CanvasGroup>();

#if AADOTWEEN
            if(AUTO_HIDE)
            {
                Sequence seq = DOTween.Sequence();
                seq.Append(cg.DOFade(1.0f, 0.2f))
                    .AppendInterval(DURATION)
                    .AppendCallback(()=>{
                        this.Hide();
                    });
            }
            else
            {
                cg.DOFade(1.0f, 0.2f);
            }
#else
            cg.alpha = 1.0f;
#endif
        }

        public void Hide()
        {
            var cg = transform.GetComponent<CanvasGroup>();

#if AADOTWEEN
            cg.DOFade(0, 0.2f).OnComplete(()=>{
                Destroy(gameObject);

                if(d_msgDelegate != null)
                    d_msgDelegate("toast_hide");
            });
#else
            cg.alpha = 0;
            Destroy(gameObject);

            if(d_msgDelegate != null)
            {
                d_msgDelegate("toast_hide");
            }
#endif
        }

    }
}