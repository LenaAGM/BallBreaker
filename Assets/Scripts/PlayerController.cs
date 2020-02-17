using UnityEngine;

namespace ballbreaker
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField]
        private GameStateVariable gameState;

        [SerializeField]
        private FloatVariable playerX;

        private void Update()
        {
            if (gameObject.GetComponent<Rigidbody>().velocity == Vector3.zero && gameState.Value == GameStateVariable.GameState.RUN)
            {
                gameState.Value = GameStateVariable.GameState.START;
            }

            playerX.Value = gameObject.transform.position.x;
        }

        public void Run(Vector3 force)
        {
            gameObject.GetComponent<Rigidbody>().AddForce(force * 12, ForceMode.Impulse);
        }

        public void Stop()
        {
            gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            gameObject.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        }
    }
}