using System;
using Services.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Services
{
    [DefaultExecutionOrder(-100)]
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private UIManager uiManager;
        
        public UIManager UIManager => uiManager;
        public static GameManager Instance { get; private set; }

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else
            {
                Destroy(gameObject);
            }
        }
        
        public void GameOver(bool isWinner)
        { 
            uiManager.ShowGameOverScreen(isWinner);
        }

        public void Restart()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
