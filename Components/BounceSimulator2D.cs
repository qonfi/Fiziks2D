

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
                // 衝突した面の法線ベクトルを取得して、その方向へ移動させる。これで面の垂直方向に跳ねる。
                // 衝突前に進行してきた方向を考慮して跳ね返ると更によい。
                Vector2 bounceDirection = detector.Info.HitInfo.normal;

                MovementPerFrame =  bounceDirection * 8f;
            }

        }
    }
}