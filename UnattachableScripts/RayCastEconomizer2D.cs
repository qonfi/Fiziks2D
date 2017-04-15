
using UnityEngine;


namespace Fiziks2D
{

    /// <summary>
    /// コンポーネントではない。前フレームでの座標と現フレームでの座標が同じ場合、
    /// 接地判定をする必要がないというフラグを立てる。Mathf.Approximately() を使って座標の比較をしている。
    /// </summary>
    public class RayCastEconomizer2D
    {
        private Vector2 LastPosition { get; set; }
        private Vector2 CurrentPosition { get; set; }
        

        public bool Update(Vector2 currentPosition)
        {
            bool result;

            this.CurrentPosition = currentPosition;


            if (LastPosition == Vector2.zero)
            {
                LastPosition = currentPosition;
                return false;
            }


            if (Mathf.Approximately(LastPosition.x, CurrentPosition.x) &&
                Mathf.Approximately(LastPosition.y, CurrentPosition.y))
            {
                result = true;
            }else{
                result = false;
            }


            LastPosition = this.CurrentPosition;
            return result;
        }
    }


}