using UnityEngine;

namespace ballbreaker
{
    [CreateAssetMenu(fileName = "ScreenParameters", menuName = "ScreenParameters", order = 52)]
    public class ScreenParameters : ScriptableObject
    {
        public float widthScreenPixel;
        public float heightScreenPixel;
        public float pixelInUnit;
    }
}