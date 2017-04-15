
using UnityEngine;


namespace Fiziks2D
{


    public class FallerGroundDetector2D : MonoBehaviour, IGroundDetector2D
    {
        public IRayCaster2D Caster { get; set; }
        public GroundingInfo Info { get; set; }

        public void Start()
        {
            Caster = new CircleCaster2D(this.gameObject, 0.2f, 0.02f);
        }


        public void Update()
        {
            Info = Caster.Cast(this.transform.position);
            
        }


    }


}