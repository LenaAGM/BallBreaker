using System;
using UnityEngine;

namespace ballbreaker
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private WorldManager worldManager;

        [SerializeField]
        private InputController inputController;

        [SerializeField]
        private UIController uiController;

        [SerializeField]
        private PlayerController playerController;

        [SerializeField]
        private EnemyController enemyController;

        [SerializeField]
        private BlockController blockController;

        [SerializeField]
        private GameStateVariable gameState;

        [SerializeField]
        private IntVariable level;

        [SerializeField]
        private FloatVariable speedEnemy;

        private Vector3 force;

        private void Awake()
        {
            force = Vector3.zero;
            worldManager.widthScreen = Camera.main.aspect * Camera.main.orthographicSize * 2.0f * 10f;
            worldManager.heightScreen = Camera.main.orthographicSize * 2.0f * 10f;
        }

        // Start is called before the first frame update
        void Start()
        {

            inputController.onTouchMoved += HandleRotateArrow;
            inputController.onTouchMoved += HandleScaleArrow;
            inputController.onTouchBegan += HandleEnableArrow;
            inputController.onTouchEnded += HandleDisableArrow;
            inputController.onTouchEnded += HandleRunPlayer;

            inputController.onClickPause += HandleClickPause;
            inputController.onClickPlayContinue += HandleClickPlayContinue;
            inputController.onClickExit += HandleClickExit;

            enemyController.onCatchPlayer += HandleCatchPlayer;

            blockController.onDestroyBlock += HandleDestroyedBlock;
        }

        // Update is called once per frame
        void Update()
        {
            if (gameState.Value == GameStateVariable.GameState.START)
            {
                worldManager.RestoreBallPosition();
                gameState.Value = GameStateVariable.GameState.WAIT;
            }
            if (gameState.Value == GameStateVariable.GameState.PASS_LEVEL)
            {
                ++level.Value;
                speedEnemy.Value += 1f;
                worldManager.RestoreBlocks();
                gameState.Value = GameStateVariable.GameState.WAIT;
            }
        }

        private void HandleRotateArrow(object sender, RotateScaleArrowEventArgs e)
        {
            worldManager.rotateArrow(e.yRotate);
        }

        private void HandleScaleArrow(object sender, RotateScaleArrowEventArgs e)
        {
            worldManager.scaleArrow(e.zScale);
        }

        private void HandleEnableArrow(object sender, EventArgs e)
        {
            worldManager.enableArrow();
        }

        private void HandleDisableArrow(object sender, EventArgs e)
        {
            force = worldManager.disableArrow();
        }

        private void HandleRunPlayer(object sender, EventArgs e)
        {
            playerController.Run(force);
        }

        private void HandleDestroyedBlock(object sender, EventArgs e)
        {
            playerController.Stop();
            worldManager.RestoreBallPosition();
            gameState.Value = GameStateVariable.GameState.WAIT;
        }

        private void HandleCatchPlayer(object sender, EventArgs e)
        {
            playerController.Stop();
            worldManager.RestoreBallPosition();
            gameState.Value = GameStateVariable.GameState.WAIT;
        }

        private void HandleClickPause(object sender, EventArgs e)
        {
            uiController.ShowMenu();
            gameState.Value = GameStateVariable.GameState.PAUSE;
        }

        private void HandleClickPlayContinue(object sender, EventArgs e)
        {
            if (gameState.Value == GameStateVariable.GameState.START_MENU)
            {
                uiController.ChangeToPauseMenu();
                worldManager.generateWorld();
                gameState.Value = GameStateVariable.GameState.WAIT;
            } else {
                gameState.Value = GameStateVariable.GameState.RUN;
            }
            uiController.HideMenu();
        }

        private void HandleClickExit(object sender, EventArgs e)
        {
            Application.Quit();
        }
    }
}