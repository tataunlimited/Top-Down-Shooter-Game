using System;
using UnityEngine;

namespace Services.UI
{
    public class BaseUIModel : MonoBehaviour
    {
        public event Action OnShow;
        public event Action OnHide;
        
        public void Hide()
        {
            gameObject.SetActive(false);
            OnHide?.Invoke();
        }
        public void Show()
        {
            gameObject.SetActive(true);
            OnShow?.Invoke();
        }
    }
}
