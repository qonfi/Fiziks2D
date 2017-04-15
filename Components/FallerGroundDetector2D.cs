
using UnityEngine;


namespace Fiziks2D
{


    public class FallerGroundDetector2D : MonoBehaviour, IGroundDetector2D
    {
        public IRayCaster2D Caster { get; set; }
        public GroundingInfo Info { get; set; }
        private string GroundName { get; set; }
        public bool Fallen { get; private set; }

        public void Start()
        {
            GroundName = "Ground";
            Caster = new CircleCaster2D(this.gameObject, 0.5f, 0.1f);
        }


        public void Update()
        {
            Info = Caster.Cast(this.transform.position);

            if (Info.LastDetectedGround == null) { return; }
            if ( Info.LastDetectedGround.name == GroundName)
            {
                Fallen = true;
            }
        }


    }


}