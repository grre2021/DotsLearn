using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// 巡逻机制，不准备设置任何一个路劲点，让敌人自行检测是否需要更改巡逻路线
/// 
/// </summary>
public class IdleState : IState
{
    private FSM manager;
    private Parameter parameter;
    private int current_patrol_point;

    float idle_time;
    public IdleState(FSM manager)
    {
        this.manager = manager;
        this.parameter = manager.parameter;
    }
    void IState.OnEnter()
    {
        idle_time=Random.Range(1f, 10f);
        current_patrol_point = (int)Random.Range(0, parameter.patrol_point.Length);
    }
    void IState.OnUpdate()
    {
        if(parameter.Distance<7f)
        {
            manager.TransitionState(StateType.Chase);
        }
        idle_time -= Time.deltaTime;
        if(idle_time<0)
        {
            float distance = Vector3.Distance(parameter.patrol_point[current_patrol_point].position, parameter.transform.position);
            Vector3 turn_direction = parameter.patrol_point[current_patrol_point].position - parameter.transform.position;
            turn_direction = new Vector3(turn_direction.x, 0, turn_direction.z);
            /*
          
            turn_direction = new Vector3(turn_direction.x, 0, turn_direction.y);                  
            Quaternion targetRotation = Quaternion.LookRotation(parameter.transform.up,turn_direction ); 
            parameter.transform.rotation = Quaternion.Lerp(parameter.transform.rotation, targetRotation, 5f);*/
            var angle = Vector3.Angle(parameter.transform.forward, turn_direction);
            var cross = Vector3.Cross(parameter.transform.forward, turn_direction);

            var turn = cross.y >= 0 ? 1f : -1f;
            parameter.transform.Rotate(parameter.transform.up, angle * Time.deltaTime * 5f * turn, Space.World);

            parameter.transform.position=Vector3.MoveTowards(parameter.transform.position,parameter.patrol_point[current_patrol_point].position,
                2*Time.deltaTime);
            
            if (distance<1f)
            {
                idle_time = Random.Range(5, 15);
                Debug.Log("idle_time"+idle_time);
                current_patrol_point =  (int)Random.Range(0, parameter.patrol_point.Length);
                Debug.Log(current_patrol_point);
            }
        }
       
        
    }


    void IState.OnExit()
    {

    }

    void chase()
    {

    }

}
