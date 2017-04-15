
using System;
using UnityEngine;

namespace Fiziks2D
{

    /// <summary>
    /// コンポーネント。接地判定のインターフェイスに依存している。
    /// </summary>
    public class GravitySimulator2D : MonoBehaviour, IMovementCalculator2D
    {
        private GravityCalculator2D calculator;
        private IGroundDetector2D detector;

        public Vector2 MovementPerFrame { get; set; }
        // private Vector2 ConstantGravityMovement { get; set; }
        public bool IsGrounding { get; set; }
        public float FloatingTime { get; private set; }


        private void Start()
        {
            calculator = new GravityCalculator2D();
            detector = GetComponent<IGroundDetector2D>();
        }


        private void Update()
        {
            if (detector.Info == null) { return; }
            IsGrounding = detector.Info.IsGrounding;

            if(IsGrounding)
            {
                MovementPerFrame = Vector2.zero;
                FloatingTime = 0f;
                return;
            }

            FloatingTime += Time.deltaTime;
            MovementPerFrame = calculator.CalcMovement(FloatingTime) * Vector2.down;
        }
    }


}