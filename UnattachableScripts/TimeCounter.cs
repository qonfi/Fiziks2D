

using UnityEngine;

namespace Fiziks2D
{


    public class TimeCounter 
    {
        public float PassedTime { get; private set; }
        private float LastSatisfiedTime;


        /// <summary>
        /// 計測情報を更新する。毎フレーム呼ばれる必要がある。
        /// </summary>
        public void Update()
        {
            PassedTime += Time.deltaTime;
        }
        

        /// <summary>
        /// n秒たつごとにそのフレーム内でのみTrueを返す。精度はそこそこ。毎フレーム呼ばれる必要がある。
        /// </summary>
        /// <param name="interval"></param>
        /// <returns></returns>
        public bool HasPassed(float interval)
        {
            if( LastSatisfiedTime + interval < PassedTime)
            {
                LastSatisfiedTime = Mathf.Floor(PassedTime);
                return true;
            }

            return false;
        }
    }


}