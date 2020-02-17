using UnityEngine;

namespace ballbreaker
{
    [CreateAssetMenu(fileName = "CurrentGameState", menuName = "GameState", order = 51)]
    public class GameStateVariable : ScriptableObject
    {
        public enum GameState
        {
            START_MENU,
            START,
            WAIT,
            RUN,
            PAUSE,
            PASS_LEVEL
        }

        public GameState Value;
    }
}