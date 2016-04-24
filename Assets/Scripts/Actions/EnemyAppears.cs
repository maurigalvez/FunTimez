using UnityEngine;
using System.Collections;
using System;

namespace Core
{

    public class EnemyAppears : Action
    {
        
        private bool springUp = false;
        [SerializeField]
        private float speed = 3;
        [SerializeField]
        private Vector3 m_DestinationAngle;
        private float dTime = 0;

        public override ActionResult OnExecute()
        {
            springUp = true;
            return ActionResult.SUCCESS;
        }

        public void Update()
        {
            if (springUp)
            {
                dTime += Time.deltaTime;
                
                if (!Quaternion.Equals(this.transform.localRotation, m_DestinationAngle))
                {
                    Vector3 rotateUp = Vector3.Lerp(Vector3.zero, m_DestinationAngle, dTime * speed);
                    this.transform.localRotation = Quaternion.Euler(rotateUp);
                }
                else
                {
                    dTime = 0;
                    springUp = false;
                }
            }
        }
    }
}
