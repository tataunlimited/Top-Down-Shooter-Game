using System;
using UnityEngine;

namespace Services.UI
{
    public class BaseUIPresenter<T> : MonoBehaviour where T : BaseUIModel
    {
        protected T Model;

        private void Awake()
        {
            Model = GetComponent<T>();
            Model.OnShow += OnShow;
            Model.OnHide += OnHide;
        }

        protected virtual void OnHide()
        {
        }

        protected virtual void OnShow()
        {
        }

        private void OnDestroy()
        {
            Model.OnShow -= OnShow;
            Model.OnHide -= OnHide;
        }
    }
}
