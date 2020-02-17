using UnityEngine;

namespace ballbreaker
{
    public class Block : MonoBehaviour
    {

        [SerializeField]
        private BlockController blockController;

        private void OnCollisionEnter(Collision collision)
        {
            if (collision.collider.name == "Player")
            {
                gameObject.SetActive(false);
                blockController.DestroyBlock();
            }
        }
    }
}