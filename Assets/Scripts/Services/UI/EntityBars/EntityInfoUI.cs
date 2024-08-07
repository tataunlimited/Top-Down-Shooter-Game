using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Services.UI.EntityBars
{
    public class EntityInfoUI : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
        [SerializeField] private TMP_Text entityName;
        
        public void Init(string title)
        {
            entityName.text = title;
            healthBar.fillAmount = 1;
        }
        
        public void UpdateHealth(float healthPercentage)
        {
            healthBar.fillAmount = healthPercentage;
        }
    }
}
