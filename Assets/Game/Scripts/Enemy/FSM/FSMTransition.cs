
using System;
using UnityEngine;

[Serializable]

public class FSMTransition
{
    public FSMDecision Decision; //Player in range of player -> True or false
    public string TrueState;// currentState -> AttackState
    public string FalseState;// currentState -> PatrolState

}