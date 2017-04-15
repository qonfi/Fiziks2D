

using System;
using UnityEngine;

namespace Fiziks2D
{


    public class OverlapCircleCaster2D : IRayCaster2D
    {
        GroundingInfo info;
        private float radius = 1f;
        int mask;


        public OverlapCircleCaster2D()
        {
            info = new GroundingInfo();
        }


        public GroundingInfo Cast(Vector2 origin)
        {
            Collider2D overlappedCollider =
                Physics2D.OverlapCircle(origin, radius);

            Debug.Log("casting");

            if (overlappedCollider == null)
            {
                info.GroundBeingDetected = null;
                info.IsGrounding = false;
            }else{
                info.LastDetectedGround = overlappedCollider.gameObject;
                info.GroundBeingDetected = overlappedCollider.gameObject;
                info.IsGrounding = true;

            }

            return info;
        }
    }


}