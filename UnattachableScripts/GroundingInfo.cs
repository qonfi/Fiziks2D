

using UnityEngine;


namespace Fiziks2D
{


    public class GroundingInfo
    {
        public GameObject LastDetectedGround { get; set; }
        public GameObject GroundBeingDetected { get;   set; }
        public bool IsGrounding { get;  set; }
        public bool HasTakenOff { get;  set; } // ?
        public RaycastHit2D HitInfo { get; set; }
    }


}