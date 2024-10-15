
    using System;
    using UnityEngine;

    public class EnemyBrain : MonoBehaviour
    {

        [SerializeField] private string initState;
        [SerializeField] private FSMState[] States;
        
        public FSMState currenState { get; set; }
        public Transform player { get; set; }



        private void Start()
        {
            ChangeState(initState);
        }

        private void Update()
        {
            
            currenState?.UpdateState(this);
        }

        public void ChangeState(string newStateID)
        {

            FSMState newState = getState(newStateID);

            if(newState==null) return;
            currenState = newState;

        }

        private FSMState getState(string newStateID)
        {
            for (int i = 0; i < States.Length; i++)
            {

                if (States[i].ID == newStateID)
                {
                    return States[i];
                }
                
            }

            return null;
        }

    }
