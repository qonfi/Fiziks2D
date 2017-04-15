

using System;
using UnityEngine;

namespace Fiziks2D
{
    /// <summary>
    /// コンポーネント。接地判定のインターフェイスに依存している。
    /// </summary>
    public class BounceSimulator2D : MonoBehaviour, IMovementCalculator2D
    {
        public Vector2 MovementPerFrame { get; set; }
        private IGroundDetector2D detector;


        private void Start()
        {
            detector = GetComponent<IGroundDetector2D>();
        }


        private void Update()
        {
            if (detector.Info == null) { return; }

            if (detector.Info.IsGrounding)
            {
                MovementPerFrame = Vector2.up * 10f;
            }

        }
    }
}