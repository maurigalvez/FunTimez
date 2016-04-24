using UnityEngine;
using System.Collections;
using System;

namespace Core
{
    /// <summary>
    /// Triggers an action sequence
    /// </summary>
    public class ActionTrigger : MonoBehaviour
    {
        [SerializeField]
        private string[] m_Targets;
        [SerializeField]
        private ActionSequence m_Sequence;
        /// <summary>
        /// Happens on trigger enter
        /// </summary>
        void OnTriggerEnter(Collider other)
        {
            // check if sequence was assigned
            if(m_Sequence == null)
            {
                Debug.LogWarning(gameObject.name + ": No sequence was added to Action Trigger");
                return;
            }
            // check if other collider is a target
            foreach (string t in m_Targets)
            {
                if(other.GetComponent(t) || other.CompareTag(t))
                {
                    m_Sequence.Run();
                } 
            }
        }
        /// <summary>
        /// Triggered When Collision happens
        /// </summary>
        void OnCollisionEnter(Collision other)
        {
            // check if sequence was assigned
            if (m_Sequence == null)
            {
                Debug.LogWarning(gameObject.name + ": No sequence was added to Action Trigger");
                return;
            }
            // check if other collider is a target
            foreach (string t in m_Targets)
            {
                if (other.transform.GetComponent(t) || other.transform.CompareTag(t))
                {
                    m_Sequence.Run();
                }
            }
        }
    }
}
