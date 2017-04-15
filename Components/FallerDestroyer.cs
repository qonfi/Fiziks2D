

using UnityEngine;

namespace Fiziks2D
{


    public class FallerDestroyer : MonoBehaviour
    {

        private FallerGroundDetector2D detector;
        private string GroundTag { get; set; }
        public bool Fallen { get; private set; }


        private void Start()
        {
            GroundTag = "Ground";
            detector = GetComponent<FallerGroundDetector2D>();
        }


        public void Update()
        {
            if (detector.Info == null) { return; }
            if (detector.Info.LastDetectedGround == null) { return; }

            if (detector.Info.LastDetectedGround.tag == GroundTag)
            {
                // Fallen なら すべてのコライダーと接触しないようになる。
                Fallen = true;
                detector.Caster.Mask = 0;
                Destroy(this.gameObject, 3f);
            }

        }
    }



}