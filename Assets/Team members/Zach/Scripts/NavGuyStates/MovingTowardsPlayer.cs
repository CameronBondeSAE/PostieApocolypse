﻿using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;

namespace ZachFrench
{
    
    public class MovingTowardsPlayer : AntAIState
    {
        private GameObject parent;
        public NavMeshAgent NavMeshAgent;
        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            parent = aGameObject;
            NavMeshAgent = parent.GetComponent<NavMeshAgent>();
        }

        public override void Enter()
        {
            base.Enter();
            NavMeshAgent.SetDestination(parent.GetComponent<UnitSense>().playerTarget.position);
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            if (NavMeshAgent.remainingDistance < 1f)
            {
                Finish();
            }
        }
    }
}
