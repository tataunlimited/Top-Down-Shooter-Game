using System.Collections.Generic;
using UnityEngine;

namespace Services.UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private List<BaseUIModel> uiModels;
        
        private void Start()
        {
            foreach (var uiModel in uiModels)
            {
                uiModel.Hide();
            }
        }
    
        public void ShowGameOverScreen(bool isWinner)
        {
            foreach (var uiModel in uiModels)
            {
                if (uiModel is GameOverScreen.GameOverScreenModel gameOverUIModel)
                {
                    gameOverUIModel.Init(isWinner);
                    gameOverUIModel.Show();
                }
            }
        }
    }
}
