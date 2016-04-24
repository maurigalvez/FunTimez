using UnityEngine;
using System.Collections;
namespace Core
{
    /// <summary>
    /// Used to inherit any input events that will trigger actions.
    /// </summary>
    public abstract class InputTrigger : MonoBehaviour
    {
        [SerializeField]
        protected Action[] m_Actions;
        /// <summary>
        /// Execute all actions in list.
        /// </summary>
        public virtual void FireActions()
        {           
            // iterate through actions
            foreach(Action a in m_Actions)
            {                
                a.Execute();
            }
        }
    }
}
