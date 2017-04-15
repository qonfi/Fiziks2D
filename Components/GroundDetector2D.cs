
using UnityEngine;


namespace Fiziks2D
{


    public class GroundDetector2D : MonoBehaviour, IGroundDetector2D
    {
        public RayCastEconomizer2D economizer;
        public IRayCaster2D Caster { get; set; }
        public GroundingInfo Info { get; set; }


        public void Start()
        {
           Caster = new CircleCaster2D(this.gameObject);
            economizer = new RayCastEconomizer2D();
        }


        public void Update()
        {
            // economizer が節約すべきと判断したら何もしない。現在は 前フレームでの座標 と 現フレームでの座標が同一のとき。
            if (economizer.Update(this.transform.position)) { return; }

            Info = Caster.Cast(this.transform.position);
        }


    }


}