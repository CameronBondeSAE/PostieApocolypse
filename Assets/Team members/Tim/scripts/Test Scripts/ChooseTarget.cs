﻿using System.Collections;
using System.Collections.Generic;
using Anthill.AI;
using UnityEngine;

namespace TimPearson
{
    public class ChooseTarget : AntAIState
    {
        private GameObject parent;
        public Target[] targets;
        public override void Create(GameObject aGameObject)
        {
            base.Create(aGameObject);
            parent = aGameObject;
        }

        public override void Enter()
        {
            base.Enter();
            Debug.Log("Finding Target");
            //bodgejob array probs should do a manager
            targets = FindObjectsOfType<Target>();
            Target target = targets[Random.Range(0, targets.Length)];
            if (target != null)
            {
                parent.GetComponent<Sprinter>().target = target;
            }

            Finish();
        }
    }

}