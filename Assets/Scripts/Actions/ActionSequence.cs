using UnityEngine;
using System.Collections;
namespace Core
{
    public class ActionSequence : MonoBehaviour
    {
        [SerializeField]
        private Action[] m_ActionList;
        private int m_CurrentAction;
        /// <summary>
        /// Initializes Action Sequence
        /// </summary>
        public void Init()
        {
            m_CurrentAction = 0;
            // check if list there's no actions added to the list
            if (m_ActionList.Length == 0)
            {
                m_CurrentAction = -1;
            }
        }
        /// <summary>
        /// Plays the action at the assigned index
        /// </summary>
        /// <param name="index">Index of Action to execute</param>
        public void PlayAction(int index)
        {
            if (index > m_ActionList.Length - 1)
            {
                Debug.LogError("Index is higher than sequence lenght!");
                return;
            }
            else if (m_CurrentAction == -1)
            {
                Debug.LogError("List is empty");
                return;
            }
            ActionResult retCode = m_ActionList[index].OnExecute();
            if (retCode == ActionResult.FAIL)
            {
                throw new System.Exception("Action Execution failed");
            }
        }
        /// <summary>
        /// Obtain current Action. Returns null if action list is empty
        /// </summary>
        public Action CurrentAction
        {
            get
            {
                if (m_CurrentAction == -1)
                {
                    return null;
                }
                return m_ActionList[m_CurrentAction];
            }
        }
        /// <summary>
        /// Moves list to Next Action
        /// </summary>
        public void Next()
        {
            if (m_CurrentAction < m_ActionList.Length - 1)
            {
                m_CurrentAction++;
            }
        }
        /// <summary>
        /// Checks if there's a next action
        /// </summary>
        /// <returns>True if there's a next action. Returns false otherwise.</returns>
        public bool hasNext()
        {
            if (m_ActionList.Length == 0)
            {
                return false;
            }

            if (m_CurrentAction < m_ActionList.Length - 1)
            {
                return true;
            }
            return false;
        }
        /// <summary>
        /// Executes all actions in this sequence
        /// </summary>
        public void Run()
        {
            foreach(Action action in m_ActionList)
            {
                action.Execute();
            }
        }
    }
}
