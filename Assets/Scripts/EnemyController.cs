using System;
using UnityEngine;

namespace ballbreaker
{
    public class EnemyController : MonoBehaviour
    {

        [SerializeField]
        private FloatVariable playerX;

        [SerializeField]
        private FloatVariable speedEnemy;

        public event EventHandler<EventArgs> onCatchPlayer;

        // Update is called once per frame
        void Update()
        {
            if (gameObject.transform.position.x < playerX.Value)
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x + speedEnemy.Value * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
            } else
            {
                gameObject.transform.position = new Vector3(gameObject.transform.position.x - speedEnemy.Value * Time.deltaTime, gameObject.transform.position.y, gameObject.transform.position.z);
            }
        }

        private void OnCollisionEnter(Collision collision)
        {
            onCatchPlayer(this, new EventArgs());
        }
    }
}