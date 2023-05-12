using Assets.Scripts.Configs;
using Assets.Scripts.Services;
using Assets.Scripts.UI.NotificationWindow;
using Assets.Scripts.UI.NotificationWindow.Elements;
using UnityEngine;

namespace Assets.Scripts.Gameplay
{
    public class GameMode : MonoBehaviour
    {
        [SerializeField] private SceneLoadConfig _menuSceneConfig;
        private ISceneLoadService _sceneLoader;
        private INotificationWindowService _notificationService;
        private ICoinCounter _coinCounter;

        public void Inject(ILoseCondition loseCondition, INotificationWindowService notificationService, ICoinCounter coinCounter, ISceneLoadService sceneLoader)
        {
            loseCondition.OnPlayerLose += LoseHandler;
            _notificationService = notificationService;
            _coinCounter = coinCounter;
            _sceneLoader = sceneLoader;
        }

        private void LoseHandler()
        {
            var text = $"You collect {_coinCounter.GetCoinCount()} coins";
            _notificationService.ShowNotification(
                new INotificationWindowElementBuilder[]
                {
                    new TextElementBuilder(text),
                    new ButtonElementBuilder(ReturnToMenu, "Complete")
                });
        }

        private void ReturnToMenu()
        {
            _notificationService.HideNotification();
            _sceneLoader.LoadScene(_menuSceneConfig);
        }

    }
}