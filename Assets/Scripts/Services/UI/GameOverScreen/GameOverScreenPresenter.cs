using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Services.UI.GameOverScreen
{
    public class GameOverScreenPresenter : BaseUIPresenter<GameOverScreenModel>
    {
        [SerializeField] private TMP_Text winText;
        [SerializeField] private Button restartButton;
        protected override void OnShow()
        {
            base.OnShow();
            winText.text = Model.IsWinner ? "You win!" : "You lose!";
            restartButton.onClick.AddListener(Model.Restart);
            
        }

        protected override void OnHide()
        {
            restartButton.onClick.RemoveAllListeners();
        }
    }
}
