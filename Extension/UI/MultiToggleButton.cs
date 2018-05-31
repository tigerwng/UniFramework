using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


namespace tiger
{
    #pragma warning disable 0649
    [AddComponentMenu("Custom/UI/Multi Toggle Button", 1)]
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(CanvasRenderer))]
    public class MultiToggleButton : Button
    {
        [SerializeField]
        private Sprite[] m_optionSources = null;

        [SerializeField]
        private int m_curOptionIndex;
        public int CURRENT_OPTION{
            get
            {
                return m_curOptionIndex;
            }
            set
            {
                m_curOptionIndex = value;
                this.UpdateToggleButton();
            }
        }

        [SerializeField]
        private bool m_isAutoUpdate = true;
        public bool IS_AUTO_UPDATE{
            set
            {
                m_isAutoUpdate = value;
            }
            get
            {
                return m_isAutoUpdate;
            }
        }





        protected override void OnEnable()
        {
            // IS_AUTO_UPDATE = true;
        }

        protected virtual void UpdateToggleButton()
        {
            if(m_optionSources == null)
                return;

            if(m_curOptionIndex >= m_optionSources.Length)
            {
                m_curOptionIndex = 0;
            }

            targetGraphic.GetComponent<Image>().sprite = m_optionSources[m_curOptionIndex];

            targetGraphic.color = IsInteractable() ? colors.normalColor:colors.disabledColor;
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (!IsActive() || !IsInteractable())
                return;

            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            base.OnPointerClick(eventData);

            if(IS_AUTO_UPDATE)
            {
                CURRENT_OPTION += 1;
            }
        }

        
    #if UNITY_EDITOR
        protected override void OnValidate()
        {
            UpdateToggleButton();
        }
    #endif
        
    }
}

