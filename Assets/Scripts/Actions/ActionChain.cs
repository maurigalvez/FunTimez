using UnityEngine;
using System.Collections;
namespace Core
{
    /// <summary>
    /// Class used to trigger an ActionSequence
    /// </summary>
    [RequireComponent(typeof(ActionSequence))]
    public class ActionChain : MonoBehaviour
    {
        [SerializeField]
        private ActionSequence m_Sequence;

        void Start()
        {
            m_Sequence = gameObject.GetComponent<ActionSequence>();
            // Initialize sequence
            m_Sequence.Init();
            // Enter current action
            m_Sequence.CurrentAction.OnEnter();
        }

        // Update is called once per frame
        void Update()
        {
            ActionResult retCode = m_Sequence.CurrentAction.OnExecute();
            // check if action failed
            if (retCode == ActionResult.FAIL)
            {
                Debug.LogError("Current action failed");
            }
            else if (retCode == ActionResult.SUCCESS)
            {
                // exit action and go to next action
                m_Sequence.CurrentAction.OnExit();
                m_Sequence.Next();
            }
        }
    }
}