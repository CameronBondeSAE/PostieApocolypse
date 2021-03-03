﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Namespace use cause why not keep it out of the way of other components
namespace RileyMcGowan
{
    public class Health : MonoBehaviour
    {
        [Tooltip("Starting Health between 1-100 is reasonable.")]
        public int startingHealth;

        [Tooltip("Expected to be the same as startingHealth on start. If no value set default 100.")]
        public int maxHealth;

        [Tooltip("This is current health, do not edit unless for testing.")]
        public int health;
        
        [Tooltip("Toggle on to make object invinsible (not die).")]
        public bool invincible;
        
        //Allows us to call the object to die
        public event Action<Health> killObject;
        void Start()
        {
            StartingHealth();
            if (maxHealth == 0)
            {
                maxHealth = 100;
            }
        }
        void Update()
        {
            //If we take damage that makes the objects health 0 then invoke death
            if (health <= 0 && invincible != true)
            {
                health = 0;
                DestroyObject();
            }
            if (health > maxHealth)
            {
                health = maxHealth;
            }
        }
        
        /// DO DAMAGE AND HEALING ///
        //DoDamage function to record damage then apply it
        public void DoDamage(int damageDelt)
        {
            if (invincible != true)
            {
                health -= damageDelt;
            }
        }
        //DoHeal function to apply healing to the object until max
        public void DoHeal(int healApply)
        {
            if (health + healApply <= maxHealth && invincible != true)
            {
                health += healApply;
            }
            else
            {
                if (health < maxHealth && invincible != true)
                {
                    health = maxHealth;
                }
            }
        }
        
        //Simple add and remove max health
        public void DecreaseMaxHealth(int removeHealthMax)
        {
            maxHealth -= removeHealthMax;
        }
        public void IncreaseMaxHealth(int addHealthMax)
        {
            maxHealth += addHealthMax;
        }
        /// DO DAMAGE AND HEALING ///

        //
        public void StartingHealth()
        {
            if (startingHealth == 0)
            {
                startingHealth = 100;
            }
            health = startingHealth;
        }
        
        //Separate health trigger for editor and functionality
        public void MaxHealth()
        {
            health = maxHealth;
        }
        
        //Separated death function for editor
        public void DestroyObject()
        {
            if (killObject != null)
            {
                killObject.Invoke(this);
            }
        }
    }
}