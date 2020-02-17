using System;
using UnityEngine;

namespace ballbreaker
{
    public class RotateScaleArrowEventArgs : EventArgs
    {
        public float yRotate;
        public float zScale;
    }

    public class InputController : MonoBehaviour
    {

        [SerializeField]
        private GameStateVariable gameState;

        public event EventHandler<RotateScaleArrowEventArgs> onTouchMoved;
        public event EventHandler<EventArgs> onTouchBegan;
        public event EventHandler<EventArgs> onTouchEnded;

        public event EventHandler<EventArgs> onClickPause;
        public event EventHandler<EventArgs> onClickPlayContinue;
        public event EventHandler<EventArgs> onClickExit;

        private Vector2 prevPos = Vector2.zero;

        private bool isBegan = false;

        // Update is called once per frame
        void Update()
        {
            if (Input.touchCount > 0 && gameState.Value == GameStateVariable.GameState.WAIT)
            {
                if (Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    isBegan = true;
                    onTouchBegan(this, new EventArgs());
                    prevPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 81f));
                }
                if (Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    if (isBegan)
                    {
                        var rotateScaleArrowEventArgs = new RotateScaleArrowEventArgs();
                        rotateScaleArrowEventArgs.yRotate = (Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 81f)).x - prevPos.x) * 5f;
                        rotateScaleArrowEventArgs.zScale = (Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 81f)).y - prevPos.y) / 5f;
                        onTouchMoved(this, rotateScaleArrowEventArgs);

                        prevPos = Camera.main.ScreenToWorldPoint(new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 81f));
                    }
                }
                if (Input.GetTouch(0).phase == TouchPhase.Ended || Input.GetTouch(0).phase == TouchPhase.Canceled)
                {
                    if (isBegan)
                    {
                        gameState.Value = GameStateVariable.GameState.RUN;
                        onTouchEnded(this, new EventArgs());
                        isBegan = false;
                    }
                }
            }
        }

        public void Pause()
        {
            onClickPause(this, new EventArgs());
        }

        public void PlayContinue()
        {
            onClickPlayContinue(this, new EventArgs());
        }

        public void Exit()
        {
            onClickExit(this, new EventArgs());
        }
    }
}