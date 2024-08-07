namespace Services.UI.GameOverScreen
{
    public class GameOverScreenModel : BaseUIModel
    {
        private bool _isWinner;
        public bool IsWinner => _isWinner;
        public void Init(bool isWinner)
        {
            _isWinner = isWinner;
        }
        
        public void Restart()
        {
            Hide();
            GameManager.Instance.Restart();
        }
        
    }
}
