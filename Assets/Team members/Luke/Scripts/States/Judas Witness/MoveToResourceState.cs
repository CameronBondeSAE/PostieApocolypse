﻿using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;
using ZachFrench;

namespace Luke
{
    public class MoveToResourceState : AntAIState
    {
         public GameObject owner;
         public NavMeshAgent navMeshAgent;
         public JudasWitnessModel judasWitnessModel;
         public AntAIAgent antAIAgent;
         public float remainingDistance = .5f;
         
         public override void Create(GameObject aGameObject)
         {
             base.Create(aGameObject);
    
             owner = aGameObject;
             antAIAgent = owner.GetComponent<AntAIAgent>();
             navMeshAgent = owner.GetComponent<NavMeshAgent>();
             judasWitnessModel = owner.GetComponent<JudasWitnessModel>();
         }
         
         public override void Enter()
         {
             base.Enter();
             
             Debug.Log("Move to resource state");

             if (judasWitnessModel.waterTargets.Count < 1)
             {
                 Debug.Log("waterTarget Null");
                 Finish();
             }
         }
         
         public override void Execute(float aDeltaTime, float aTimeScale)
         {
             base.Execute(aDeltaTime, aTimeScale);

             if (navMeshAgent.remainingDistance < remainingDistance)
             {
                 Finish();
             }
             
         }

         public override void Exit()
         {
             base.Exit();
             
             antAIAgent.worldState.BeginUpdate(antAIAgent.planner);
             antAIAgent.worldState.Set("atResourcePos", true);
             antAIAgent.worldState.EndUpdate();
             
             Debug.Log("At resource position");
         }
    }
}
