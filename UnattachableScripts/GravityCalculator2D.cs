﻿
// using UnityEngine;


namespace Fiziks2D
{


    public class GravityCalculator2D
    {

        public float GravityAccel { get; set; }


        public GravityCalculator2D()
        {
            GravityAccel = 8f;
        }

        
        public float CalcMovement(float floatingTime)
        {
            return floatingTime * GravityAccel;
        }

    }


}