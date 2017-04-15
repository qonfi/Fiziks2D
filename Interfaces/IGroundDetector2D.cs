

using UnityEngine;


namespace Fiziks2D
{


    public interface IGroundDetector2D
    {
       GroundingInfo Info { get; set; }
       IRayCaster2D Caster { get; set; }
    }


}