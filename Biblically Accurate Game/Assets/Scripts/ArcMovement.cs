using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

namespace Assets.Scripts.Tree.Projectiles.Modules 
{ 
    public class ArcMovement : MonoBehaviour
    {   
        public AnimationCurve curve;
        [SerializeField] private float duration = 1f;
        [SerializeField] private float heightY = 3f;

        public IEnumerator Curve (Vector3 start, Vector2 target)
        {
            float timePassed = 0f;
            Vector2 end = target;

            while (timePassed < duration)
            {
                timePassed += Time.deltaTime;

                float linearT = timePassed / duration;
                float heightT = curve.Evaluate(linearT);

                float height = Mathf.Lerp(0f, heightY, heightT);
                transform.position = Vector2.Lerp(start, end, linearT) + new Vector2(0f, height);

                yield return null;
            }
        }

        public void StartCurveMovement(Vector3 start, Vector2 target)
        {
            StartCoroutine(Curve(start, target));
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }

}

