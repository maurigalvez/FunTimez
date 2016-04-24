using UnityEngine;
using System.Collections;
namespace Core
{
    /// <summary>
    /// Struct that defines result of action execution
    /// </summary>
    public enum ActionResult
    {
        CONTINUE,
        SUCCESS,
        FAIL
    }
    /// <summary>
    /// Class to be used for multiple behaviours.
    /// </summary>
    public abstract class Action : MonoBehaviour
    {
        public virtual void OnEnter() { }

        public abstract ActionResult OnExecute();

        public virtual void Execute()
        {
            OnExecute();
        }

        public virtual void OnExit() { }

        public virtual void OnEnable() { }

        public virtual void OnDisable() { }
    }
}
