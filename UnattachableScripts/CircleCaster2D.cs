

using UnityEngine;


namespace Fiziks2D
{


    public class CircleCaster2D : IRayCaster2D
    {
        GroundingInfo info;
        private float radius;
        private float length;
       public int Mask { get; set; }


        public CircleCaster2D(GameObject gObject, float _radius = 0.5f, float _castLength = 1f)
        {
            this.radius = _radius;
            this.length = _castLength;

            info = new GroundingInfo();

           int[]  ignoredLayer = new int[] { gObject.layer };
           Mask = LayerMaskGenerator.Generate(LayerMaskGenerator.Ignore.SpecifiedLayer, ignoredLayer);
            
            //Debug.Log("<color=navy>" + 
            //    "This Object is on [" + LayerMask.LayerToName(gObject.layer) + "] layer. " + "GroundDetector is ignoring this layer. "
            //    + "</color>");
        }




        public GroundingInfo Cast(Vector2 origin)
        {
            RaycastHit2D hitInfo =
                Physics2D.CircleCast(origin, radius, Vector2.down, length, Mask);

            if ( hitInfo.collider == null)
            {
                info.GroundBeingDetected = null;
                info.IsGrounding = false;
            } else {
                GameObject detectedObject = hitInfo.collider.gameObject;
                info.LastDetectedGround = detectedObject;
                info.GroundBeingDetected = detectedObject;
                info.HitInfo = hitInfo;
                info.IsGrounding = true;
            }

            return info;
        }
    }


}