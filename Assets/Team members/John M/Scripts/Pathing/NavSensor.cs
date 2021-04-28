﻿using Anthill.AI;
using UnityEngine;
public class NavSensor : MonoBehaviour, ISense
{
    public void CollectConditions(AntAIAgent aAgent, AntAICondition aWorldState)
    {
        
        aWorldState.BeginUpdate(aAgent.planner);
        aWorldState.Set("Found Item", false);
        aWorldState.Set("Move To Item", false);
        aWorldState.Set("Collect Item", false);
        aWorldState.Set("See Player", false);
        aWorldState.Set("Retreat", false);
        aWorldState.Set("Deposit Item", false);
        aWorldState.Set("Move To Deposit", false);
        aWorldState.EndUpdate();
    }
    
}
