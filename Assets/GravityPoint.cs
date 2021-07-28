using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Murgn;

namespace Murgn
{
    public class GravityPoint : MonoBehaviour
    {
        public float gravityScale=1f, planetRadius=2f, gravityMinRange=1f, gravityMaxRange=2f;
        public GameObject planet, minRS, maxRS;
        public CircleCollider2D circleCollider2D;
        public float gravitationalPower;

        // Start is called before the first frame update
        void Update()
        {
            minRS.transform.localScale = new Vector3((planetRadius + gravityMinRange) * 2, (planetRadius + gravityMinRange) * 2, 1);
            maxRS.transform.localScale = new Vector3((planetRadius + gravityMinRange + gravityMaxRange) * 2, (planetRadius + gravityMinRange + gravityMaxRange) * 2, 1);
            circleCollider2D.radius = planetRadius + gravityMinRange + gravityMaxRange;
            planet.transform.localScale = new Vector3(1f, 1f, 1f) * planetRadius;
        }

        void OnTriggerStay2D(Collider2D obj)
        {
            gravitationalPower = gravityScale / planetRadius;
            float dist = Vector2.Distance(obj.transform.position, transform.position);

            if (dist > (planetRadius + gravityMinRange))
            {
                float min = planetRadius + gravityMinRange + 0.5f;
                gravitationalPower = gravitationalPower * (((min + gravityMaxRange) - dist) / gravityMaxRange);
            }

            Vector3 dir = (transform.position - obj.transform.position) * gravitationalPower;
            obj.GetComponent<Rigidbody2D>().AddForce(dir);

            if (obj.CompareTag("Player"))
            {
                switch(obj.GetComponent<Rocket>().state)
                {
                    case RocketStates.Idle:
                    obj.transform.up = Vector3.MoveTowards(obj.transform.up, -dir, gravitationalPower * Time.deltaTime * 5f);
                    break;

                    case RocketStates.Active:
                    obj.transform.up = Vector3.MoveTowards(obj.transform.up, -dir, gravitationalPower * Time.deltaTime);
                    break;
                }
                //obj.transform.up = Vector3.MoveTowards(obj.transform.up, -dir, gravitationalPower * Time.deltaTime * 5f);
                obj.GetComponent<RocketController>().gravitationalPower = gravitationalPower * 10;
            }
        }
    }
}
