
using UnityEngine;


namespace Fiziks2D
{


    public interface IRayCaster2D
    {
        int Mask { get; set; }
        GroundingInfo Cast(Vector2 origin);
    }


}