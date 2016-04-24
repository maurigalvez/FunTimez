using UnityEngine;
using System.Collections.Generic;
/// <summary>
/// Class used to spawn and recycle objects
/// </summary>
public class GOPool : MonoBehaviour
{   
    [SerializeField]
    private Transform m_Prefab;             // Prefab of object to spawn
    [SerializeField]
    private int m_InstanceNumber = 0;       // Number of instances to create
    private Queue<GameObject> m_Instances;       // Array of instances available
    private int m_CurrentIndex;             // Index of next available instance
    // Use this for initialization
    void Start()
    {
        // check if a prefab was provided
        if(m_Prefab)
        {
            GameObject instance;
            // Create many instances and add them to list
            m_Instances = new Queue<GameObject>();
            // Add them to list
            for(int i=0; i < m_InstanceNumber; i++)
            {
                instance = (GameObject)GameObject.Instantiate(m_Prefab.gameObject, Vector3.zero, Quaternion.identity);
                instance.SetActive(false);
                m_Instances.Enqueue(instance);
            }
        }

    }
    /// <summary>
    /// Returns next available object from pool
    /// </summary>
    /// <returns>Next available object in Queue, returns null if queue is empty</returns>
    public virtual GameObject GetNextAvailable()
    {
        if (m_Instances.Count == 0)
        {
            return null;
        }
        GameObject instance = m_Instances.Dequeue();
        if (!instance.GetComponent<PoolObject>())
        {
            instance.AddComponent<PoolObject>().m_Pool = this;
        }
        return instance;
    }
    /// <summary>
    /// Hides and returns assigned poolobject to this pool
    /// </summary>
    /// <param name="obj"></param>
    public virtual void Return(PoolObject obj)
    {
        obj.gameObject.SetActive(false);
        m_Instances.Enqueue(obj.gameObject);
    }
}
