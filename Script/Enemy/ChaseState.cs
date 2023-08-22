using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : MonoBehaviour,IState
{
    private FSM manager;
    private Parameter parameter;

    private float shot_time;
    public ChaseState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    void IState.OnEnter()
    {
        shot_time = 0.5f;
    }
    void IState.OnUpdate()
    {
        shot_time-=Time.deltaTime;
        parameter.transform.LookAt(parameter.Target);
        parameter.transform.position = Vector3.MoveTowards(parameter.transform.position, parameter.Target.position,
               2 * Time.deltaTime);
        if (parameter.Distance < 4 && shot_time<0)
        {
             GameObject.Instantiate(parameter.bullent_perfad, parameter.gun_position.position, parameter.gun_position.rotation);
            manager.TransitionState(StateType.Idle);
            shot_time = 0.5f;

        }
    }


    void IState.OnExit()
    {

    }

   
}

