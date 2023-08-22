using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;//[serializable]需要此命名空间
public enum StateType//创建一个enum，用于表示各个状态
{
    Idle, Attack, Chase
}
[Serializable]
public class Parameter//序列化角色的参数，把这些参数存储到Parameter中
{
    public Animator animator;
    public Transform transform;
    public Transform[] patrol_point;
    public Transform Target;
    public float Distance;
    public GameObject bullent_perfad;
    public Transform gun_position;
}
public class FSM : MonoBehaviour
{
    public Parameter parameter;//声明角色的Parameter
    private IState currentState;//表示角色当前的状态
    private Dictionary<StateType, IState> state = new Dictionary<StateType, IState>();//注册字典

    void Start()
    {
        
        state.Add(StateType.Idle,new IdleState(this));
        state.Add(StateType.Chase,new ChaseState(this));
        //初始化各个状态
        TransitionState(StateType.Idle);
        parameter.animator = this.GetComponent<Animator>();
        parameter.transform = this.GetComponent<Transform>();
    }
    void Update()
    {
        parameter.Distance=Vector3.Distance(parameter.Target.position, transform.position);
        if (currentState == null) return;
        currentState.OnUpdate();

    }

    public void TransitionState(StateType type)//改变状态
    {

        if (currentState != null)
            currentState.OnExit();
        currentState = state[type];
        currentState.OnEnter();
    }
}