

using UnityEngine;
using Fiziks2D;


namespace IMGUI
{


    public class DetectorDebugger2D : MonoBehaviour,IDebuggerRow
    {

        public bool Visible { get; set; }
        [SerializeField] private GroundDetector2D detector;

        
        
        public void Display()
        {
            if (detector == null)
            {
                GUILayout.Box("GroundDetector == null");
                return;
            }

            GUILayout.Box("");
            GUILayout.Box(
                "IsGrounding : " + detector.Info.IsGrounding + "\n" +
                "GroundBeingDetected : " + detector.Info.GroundBeingDetected + "\n" + 
                "LastDetectedGround : " + detector.Info.LastDetectedGround
                );
        }

    }


}