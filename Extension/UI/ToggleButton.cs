using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;




namespace tiger
{
    [AddComponentMenu("Custom/UI/Toggle Button", 1)]
    [RequireComponent(typeof(Image))]
    [RequireComponent(typeof(CanvasRenderer))]
    public class ToggleButton : Button
    {
        [SerializeField]
        private Sprite m_onSource;
        public Sprite onSource {
            set
            {
                m_onSource = value;
                UpdateToggleButton();
            }
        }


        [SerializeField]
        private Sprite m_offSource;
        public Sprite offSource {
            set
            {
                m_offSource = value;
                UpdateToggleButton();
            }
        }

        [SerializeField]
        private bool m_isOn;
        public bool IS_SELECTED_ON{
            get
            {
                return m_isOn;
            }
            set
            {
                m_isOn = value;
                UpdateToggleButton();
            }
        }

        [SerializeField]
        private bool m_isAutoUpdate;
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
            m_isAutoUpdate = true;
        }

        protected virtual void UpdateToggleButton()
        {
            var target = targetGraphic.GetComponent<Image>();

            if(m_isOn)
            {
                target.sprite = m_onSource;
            }
            else if(!m_isOn)
            {
                target.sprite = m_offSource;
            }

            targetGraphic.color = IsInteractable() ? colors.normalColor:colors.disabledColor;
            target.SetNativeSize();
        }

        public override void OnPointerClick(PointerEventData eventData)
        {
            if (!IsActive() || !IsInteractable())
                return;

            if (eventData.button != PointerEventData.InputButton.Left)
                return;

            if(m_isAutoUpdate)
            {
                bool isOn = !IS_SELECTED_ON;
                IS_SELECTED_ON = isOn;

                // UpdateToggleButton();
            }

            base.OnPointerClick(eventData);
        }

        
    #if UNITY_EDITOR
        protected override void OnValidate()
        {
            UpdateToggleButton();
        }
    #endif
        
    }
}

