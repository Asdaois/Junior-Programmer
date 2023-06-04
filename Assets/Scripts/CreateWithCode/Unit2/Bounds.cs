using System;
using UnityEngine;

namespace CreateWithCode.Unit2
{
    [Serializable]
    public struct Bounds
    {
        public float min;
        public float max;

        public float ClampValue(float value)
        {
            return Mathf.Clamp(value, min, max);
        }
    }
}