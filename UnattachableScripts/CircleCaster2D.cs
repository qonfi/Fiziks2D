

using UnityEngine;


namespace Fiziks2D
{


    public class CircleCaster2D : IRayCaster2D
    {
        GroundingInfo info;
        private float radius = 0.5f;
        private float length = 1f;
        private int mask;


        public CircleCaster2D(GameObject gObject)
        {
            info = new GroundingInfo();

           int[]  ignoredLayer = new int[] { gObject.layer };
           mask = LayerMaskGenerator.Generate(LayerMaskGenerator.Ignore.SpecifiedLayer, ignoredLayer);
        }


        public GroundingInfo Cast(Vector2 origin)
        {
            RaycastHit2D hitInfo =
                Physics2D.CircleCast(origin, radius, Vector2.down, length, mask);

            if ( hitInfo.collider == null)
            {
                info.GroundBeingDetected = null;
                info.IsGrounding = false;
            } else {
                GameObject detectedObject = hitInfo.collider.gameObject;
                info.LastDetectedGround = detectedObject;
                info.GroundBeingDetected = detectedObject;
                info.IsGrounding = true;
            }

            return info;
        }
    }


}