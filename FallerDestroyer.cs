

using UnityEngine;

namespace Fiziks2D
{


    public class FallerDestroyer : MonoBehaviour
    {
        private FallerGroundDetector2D detector;

        private void Start()
        {
            detector = GetComponent<FallerGroundDetector2D>();
        }

        public void Update()
        {
            if (detector.Fallen)
            {
                // Fallen なら すべてのコライダーと接触しないようになる。
                detector.Caster.Mask = 0;

                Destroy(this.gameObject, 3f);
            }

        }
    }



}