using System;

namespace Assets.Scripts.CreateWithCode.Unit2
{
    [Serializable]
    public struct Bounds
    {
        public float min;
        public float max;

        public float ClampValue(float value)
        {
            return UnityEngine.Mathf.Clamp(value, min, max);
        }
    }
}