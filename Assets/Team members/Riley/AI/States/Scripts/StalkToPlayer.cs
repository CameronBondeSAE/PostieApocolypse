﻿using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;
using UnityEngine.AI;

namespace RileyMcGowan
{
    public class StalkToPlayer : AntAIPlannerState
    {
        //Public Vars
        
        //Private Vars
        private float safeDistance;
        private GameObject currentTarget;
        private Vector3 targetLocation;
        private int timeToFollow;

        public override void Enter()
        {
            base.Enter();
            targetLocation = creatureMainRef.playerTarget.transform.position;
            navMeshRef.SetDestination(targetLocation);
            timeToFollow = 0;
        }

        public override void Execute(float aDeltaTime, float aTimeScale)
        {
            base.Execute(aDeltaTime, aTimeScale);
            //Take the safeDistance from the main script so all controls are on the main script
            safeDistance = creatureMainRef.safeDistance;
            if (targetLocation != creatureMainRef.playerTarget.transform.position && timeToFollow < 100)
            {
                timeToFollow += 1;
                navMeshRef.SetDestination(creatureMainRef.playerTarget.transform.position);
                targetLocation = creatureMainRef.playerTarget.transform.position;
            }
            
            if (creatureMainRef.vfxComp.GetInt("MaxParticles") < 5000)
            {
                int particalRef;
                particalRef = creatureMainRef.vfxComp.GetInt("MaxParticles") + 500;
                if (particalRef > 5000)
                {
                    particalRef = 5000;
                    creatureMainRef.vfxComp.SetInt("MaxParticles", particalRef);
                }
                else
                {
                    creatureMainRef.vfxComp.SetInt("MaxParticles", particalRef);
                }
            }
            if (creatureMainRef.vfxComp.GetFloat("Radius") > 1 || creatureMainRef.vfxComp.GetFloat("Radius") < 5)
            {
                float radiusRef;
                radiusRef = navMeshRef.remainingDistance;
                if (radiusRef < 1)
                {
                    radiusRef = 1;
                    creatureMainRef.vfxComp.SetFloat("Radius", radiusRef);
                }
                else
                {
                    if (radiusRef > 5)
                    {
                        radiusRef = 5;
                        creatureMainRef.vfxComp.SetFloat("Radius", radiusRef);
                    }
                    else
                    {
                        creatureMainRef.vfxComp.SetFloat("Radius", radiusRef);
                    }
                }
            }

            //Check the distance the creature has until it's finished
            if (navMeshRef.remainingDistance < safeDistance)
            {
                //Do the state machines job for it...
                antAIRef.worldState.BeginUpdate(antAIRef.planner);
                antAIRef.worldState.Set("PlayerReached", true);
                antAIRef.worldState.EndUpdate();
                creatureMainRef.currentPatrolPoint = null;
                //Stop navigation and finish
                Finish();
            }
        }
    }
}