
using UnityEngine;


namespace Fiziks2D
{


    public interface IRayCaster2D
    {
        GroundingInfo Cast(Vector2 origin);
    }


}