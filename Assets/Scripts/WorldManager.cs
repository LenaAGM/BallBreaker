using UnityEngine;

namespace ballbreaker
{
    public class WorldManager : MonoBehaviour
    {

        [SerializeField]
        private GameObject topRect, bottomRect, leftRect, rightRect;

        [SerializeField]
        private GameObject player, enemy;

        [SerializeField]
        private GameObject block1, block2, block3;

        [SerializeField]
        private GameObject arrowParent;
        [SerializeField]
        private GameObject arrow;

        [HideInInspector]
        public float widthScreen, heightScreen;

        // Start is called before the first frame update
        public void generateWorld()
        {

            //Fencing
            topRect.transform.position = new Vector3(0, widthScreen / 40f + 0.1f, heightScreen / 2f - 2f);
            bottomRect.transform.position = new Vector3(0, widthScreen / 40f + 0.1f, -heightScreen / 2f + 2.5f);
            leftRect.transform.position = new Vector3(-widthScreen / 2f + 1.5f, widthScreen / 40f + 0.1f, 0);
            rightRect.transform.position = new Vector3(widthScreen / 2f - 1.5f, widthScreen / 40f + 0.1f, 0);

            topRect.transform.localScale = new Vector3(widthScreen - 1f, widthScreen / 20f, 2f);
            bottomRect.transform.localScale = new Vector3(widthScreen - 1f, widthScreen / 20f, 2f);
            leftRect.transform.localScale = new Vector3(2f, widthScreen / 20f, heightScreen - 3f);
            rightRect.transform.localScale = new Vector3(2f, widthScreen / 20f, heightScreen - 3f);

            //Blocks
            generateBlocks();

            //Player
            player.transform.position = new Vector3(0, widthScreen / 40f + 0.1f, -heightScreen / 2f + 16f);
            player.transform.localScale = new Vector3(widthScreen / 10f, widthScreen / 10f, widthScreen / 10f);

            //Enemy
            enemy.transform.position = new Vector3(0, widthScreen / 40f + 0.1f, heightScreen / 2f - 24f);
            enemy.transform.localScale = new Vector3(widthScreen / 10f, widthScreen / 20f, 2f);

            //Arrow
            arrowParent.transform.position = new Vector3(0, player.transform.position.y, player.transform.position.z + 6f);
        }

        public void generateBlocks()
        {
            Vector3 scaleBlock = new Vector3(widthScreen / 6f, widthScreen / 20f, 2f);

            block1.transform.position = new Vector3(-widthScreen / 3.7f, widthScreen / 40f + 0.1f, heightScreen / 2f - 12f);
            block2.transform.position = new Vector3(0, widthScreen / 40f + 0.1f, heightScreen / 2f - 12f);
            block3.transform.position = new Vector3(widthScreen / 3.7f, widthScreen / 40f + 0.1f, heightScreen / 2f - 12f);

            block1.transform.localScale = scaleBlock;
            block2.transform.localScale = scaleBlock;
            block3.transform.localScale = scaleBlock;
        }

        public void rotateArrow(float y)
        {
            arrowParent.transform.Rotate(0, y, 0);

            float yRotation = arrowParent.transform.rotation.eulerAngles.y;

            if (yRotation < 280f && yRotation > 180f)
            {
                arrowParent.transform.rotation = Quaternion.Euler(new Vector3(0, 280f, 0));
            }
            else if (yRotation > 80f && yRotation < 180f)
            {
                arrowParent.transform.rotation = Quaternion.Euler(new Vector3(0, 80f, 0));
            }
        }

        public void scaleArrow(float z)
        {
            arrowParent.transform.localScale = new Vector3(arrowParent.transform.localScale.x, arrowParent.transform.localScale.y, arrowParent.transform.localScale.z + z);
            if (arrowParent.transform.localScale.z < 1)
            {
                arrowParent.transform.localScale = new Vector3(arrowParent.transform.localScale.x, arrowParent.transform.localScale.y, 1f);
            }
            else if (arrowParent.transform.localScale.z > 3)
            {
                arrowParent.transform.localScale = new Vector3(arrowParent.transform.localScale.x, arrowParent.transform.localScale.y, 3f);
            }
        }

        public void enableArrow()
        {
            arrowParent.SetActive(true);
        }

        public Vector3 disableArrow()
        {
            var force = arrow.transform.position - arrowParent.transform.position;
            arrowParent.SetActive(false);
            arrowParent.transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            arrowParent.transform.localScale = new Vector3(arrowParent.transform.localScale.x, arrowParent.transform.localScale.y, 0);
            return force;
        }

        public void RestoreBallPosition()
        {
            player.transform.position = new Vector3(0, widthScreen / 40f + 0.1f, -heightScreen / 2f + 16f);
        }

        public void RestoreBlocks()
        {
            block1.SetActive(true);
            block2.SetActive(true);
            block3.SetActive(true);
        }
    }
}