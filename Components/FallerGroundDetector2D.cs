
using UnityEngine;


namespace Fiziks2D
{


    public class FallerGroundDetector2D : MonoBehaviour, IGroundDetector2D
    {
        public IRayCaster2D Caster { get; set; }
        public GroundingInfo Info { get; set; }


        public void Start()
        {
            Caster = new OverlapCircleCaster2D();
        }


        public void Update()
        {
            Info = Caster.Cast(this.transform.position);
        }


    }


}