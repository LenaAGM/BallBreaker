using System;
using UnityEngine;

namespace ballbreaker
{
    public class BlockController : MonoBehaviour
    {

        [SerializeField]
        private GameStateVariable gameState;

        private int countDestroyedBlocks = 0;

        public event EventHandler<EventArgs> onDestroyBlock;

        public void DestroyBlock()
        {
            countDestroyedBlocks += 1;
            onDestroyBlock(this, new EventArgs());

            if (countDestroyedBlocks == 3)
            {
                countDestroyedBlocks = 0;
                gameState.Value = GameStateVariable.GameState.PASS_LEVEL;
            }
        }
    }
}