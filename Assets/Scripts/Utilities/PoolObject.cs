using UnityEngine;
using System.Collections;

public class PoolObject : MonoBehaviour
{
    public GOPool m_Pool;
    
    public void Return()
    {
        m_Pool.Return(this);
    }
}
