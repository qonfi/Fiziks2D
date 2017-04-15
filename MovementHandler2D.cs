
using System.Collections.Generic;
using UnityEngine;


namespace Fiziks2D
{

    /// <summary>
    /// フレームごとの各コンポーネントの移動量を合計して実行するクラス。
    /// </summary>
    public class MovementHandler2D : MonoBehaviour
    {
        // CharacterController を2D でも使えれば使う予定だが、そのあたりが決まっていないのでいろいろ暫定。
        // しかしかなり洗練されてきているので3Dのほうでもこのクラスは参考にしたい。

        private List<IMovementCalculator2D> calculators;
        public Vector2 TotalMovement { get; private set; }

        private void Start()
        {
            calculators = new List<IMovementCalculator2D>();
            calculators.AddRange(GetComponents<IMovementCalculator2D>());
        }


        private void Update()
        {
            TotalMovement = Vector2.zero;

            foreach (IMovementCalculator2D calcator in calculators)
            {
                TotalMovement += calcator.MovementPerFrame;
            }

            transform.Translate(TotalMovement * Time.deltaTime);
        }

    }


}