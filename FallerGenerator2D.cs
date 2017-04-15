

using UnityEngine;

namespace Fiziks2D
{


    public class FallerGenerator2D : MonoBehaviour
    {
        [SerializeField] private GameObject FallerPrefab;
        private TimeCounter timer;
        private float GenerateRange { get; set; }


        private void Start()
        {
            timer = new TimeCounter();
            GenerateRange = 8f;
        }


        private void Update()
        {
            timer.Update();

            if (timer.HasPassed(1f))
            {
                Generate();
            }
        }


        private void Generate()
        {
            // FallerPrefab.GetComponent<GroundDetector2D>().Caster = new OverlapCircleCaster2D();

            GameObject instantiatedObject = Instantiate(FallerPrefab);

            instantiatedObject.transform.position = 
                new Vector2(Random.Range(-GenerateRange, GenerateRange), instantiatedObject.transform.position.y);
        }


    }


}