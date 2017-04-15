
using System.Collections.Generic;
using UnityEngine;


namespace Fiziks2D
{


    public class FallerDiverIntoBasket2D : MonoBehaviour
    {
        private IGroundDetector2D detector;
        private List<Component> components;
        private Vector2 localPositionInBasket;
        private string BasketTag { get; set; }
        private bool IsDiving { get; set; }


        private void Start()
        {
            BasketTag = "Basket";
            detector = GetComponent<IGroundDetector2D>();
            components = new List<Component>();
            components.AddRange(GetComponents<Component>());
            localPositionInBasket = new Vector2(0.31f, 0.35f);
        }


        private void Update()
        {
            if (IsDiving)
            {
                this.transform.Translate(Vector2.down * 0.004f);
                return;
            }
            
            if (detector.Info == null) { return; }
            if ( detector.Info.LastDetectedGround == null) { return; }

            // バスケットと衝突したら、Fallerからこのスクリプトとトランスフォーム以外のすべてのコンポーネントを削除。
            // バスケットの子オブジェクトとなって、アニメーションを行う。
            if ( detector.Info.LastDetectedGround.tag == BasketTag)
            {
                RemoveComponents();
                StartDivingAnimation(detector.Info.LastDetectedGround);
            }
        }


        private void RemoveComponents()
        {
            foreach (Component element in components)
            {
                if (element is Transform) { continue; }
                if (element is FallerDiverIntoBasket2D) { continue; }

                Destroy(element);
            }
        }


        private void StartDivingAnimation(GameObject newParent)
        {
            IsDiving = true;
            this.transform.parent = newParent.transform;
            this.transform.localPosition = localPositionInBasket;
            Destroy(this.gameObject, 3f);
        }
    }


}