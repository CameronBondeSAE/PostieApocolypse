﻿using Anthill.AI;
using UnityEngine;
using ZachFrench;

namespace TimPearson
{
    public class SprinterAI : MonoBehaviour
    {
        public PatrolManager target;
        public AntAIAgent antAIAgent;
        public Rigidbody rb;
        public LayerMask RaycastHitLayer;
        private Sprint sprint;
        public PatrolPoint currentTarget;
       

        // Start is called before the first frame update
        private void Start()
        {
            if (!(antAIAgent is null)) antAIAgent.SetGoal("At Position");
            sprint = GetComponent<Sprint>();
        }

        // Update is called once per frame
        private void Update()
        {
            if (target != null)
            {
                var ray = new Ray(transform.position, transform.forward);
                RaycastHit raycastBoost;
                if (Physics.Raycast(ray, out raycastBoost, 500, RaycastHitLayer))
                {
                    Debug.DrawLine(ray.origin, raycastBoost.point, Color.green);
                    sprint.isBoosting = true;
                }
                else
                {
                    Debug.DrawLine(transform.position, currentTarget.transform.position);
                    sprint.isBoosting = false;
                }
            }
        }

        
    }
}