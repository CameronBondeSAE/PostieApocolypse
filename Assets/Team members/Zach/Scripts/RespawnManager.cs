﻿using System;
using System.Collections;
using System.Collections.Generic;
using RileyMcGowan;
using UnityEngine;
using Random = UnityEngine.Random;


namespace ZachFrench
{


    public class RespawnManager : MonoBehaviour
    {

        public Vector3 homeSpawn;
        
        public Vector3 civSpawn;

        public Vector3 playerSpawn;

        public GameObject civilianPrefab;

        public int numberOfCivilian;

        public int numberOfPlayers;

        public List<GameObject> civilians;

        public List<GameObject> players;

        public PostieNetworkManager postieNetworkManager;
        
        
        // Civilian don't get created instead are still currently part of the list
        void Start()
        {
            homeSpawn = transform.position;
            numberOfCivilian = 4;
            postieNetworkManager = FindObjectOfType<PostieNetworkManager>();
            postieNetworkManager.newPlayerEvent += PostieNetworkManagerOnNewPlayerEvent;
            postieNetworkManager.playerDisconnectedEvent += PostieNetworkManagerOnPlayerDisconnectedEvent;

            for (int i = 0; i < numberOfCivilian; i++)
            {
                civSpawn = new Vector3(homeSpawn.x + Random.Range(0,5),homeSpawn.y,homeSpawn.z + Random.Range(0,5));
                civilians.Add(Instantiate(civilianPrefab,civSpawn,new Quaternion(0,0,0,0)));
                //civilians[i].GetComponent<Health>().deathEvent += RespawnAfterDeath;
            }
        }

        private void PostieNetworkManagerOnNewPlayerEvent(GameObject obj)
        {
            obj.GetComponent<Health>().deathEvent += RespawnAfterDeath;
        }
        
        private void PostieNetworkManagerOnPlayerDisconnectedEvent(GameObject obj)
        {
            obj.GetComponent<Health>().deathEvent -= RespawnAfterDeath;
        }

        //Function/event that resets player position
        //Civilian's now get removed from list
        //Need to make sure that when we have a real game object to destroy them here
        private void RespawnAfterDeath(Health obj)
        {
            if (civilians.Count > 0)
            {
                GameObject civilianToDelete = civilians[Random.Range(0,civilians.Count)];
                Destroy(civilianToDelete);
                civilians.Remove(civilianToDelete);
                obj.transform.position = civilianToDelete.transform.position;
                //civilians[numberOfCivilian].GetComponent<Health>().deathEvent -= RespawnAfterDeath;
            }
            else
            {
                Debug.Log("You have run out of lives");
            }
            
        }
        

        
    }
}
