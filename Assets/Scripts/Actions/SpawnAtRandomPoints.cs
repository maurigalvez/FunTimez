using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;

namespace Core
{
    public class SpawnAtRandomPoints : Action
    {
        [SerializeField]
        private List<Transform> m_SpawnPoints;
        [SerializeField]
        private GOPool gopool;


        public override ActionResult OnExecute()
        {
            GameObject enemy = gopool.GetNextAvailable();
            if (enemy != null)
            {
                enemy.transform.position = getRandomSpawnPoint();
            }

            return ActionResult.SUCCESS;
        }

        public Vector3 getRandomSpawnPoint()
        {
            if (m_SpawnPoints.Count > 0)
            {
                int rng = UnityEngine.Random.Range(0, m_SpawnPoints.Count);
                return m_SpawnPoints[rng].position;
            }
            return Vector3.zero;
        }
    }
}
