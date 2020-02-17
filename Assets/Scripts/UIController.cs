using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace ballbreaker
{
    public class UIController : MonoBehaviour
    {

        [SerializeField]
        private TextMeshProUGUI textLevel;

        [SerializeField]
        private Button btnPause;

        [SerializeField]
        private Canvas menu;

        [SerializeField]
        private Button btnPlayContinue;

        [SerializeField]
        private IntVariable level;

        private int mlevel = 1;

        // Update is called once per frame
        void Update()
        {
            if (mlevel != level.Value)
            {
                mlevel = level.Value;
                textLevel.text = "Level " + mlevel;
            }
        }

        public void ChangeToPauseMenu()
        {
            btnPlayContinue.GetComponentInChildren<TextMeshProUGUI>().text = "Продолжить игру";
        }

        public void ShowMenu()
        {
            textLevel.gameObject.SetActive(false);
            btnPause.gameObject.SetActive(false);
            menu.gameObject.SetActive(true);
        }

        public void HideMenu()
        {
            textLevel.gameObject.SetActive(true);
            btnPause.gameObject.SetActive(true);
            menu.gameObject.SetActive(false);
        }
    }
}