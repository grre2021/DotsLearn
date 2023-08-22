using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;//[serializable]��Ҫ�������ռ�
public enum StateType//����һ��enum�����ڱ�ʾ����״̬
{
    Idle, Attack, Chase
}
[Serializable]
public class Parameter//���л���ɫ�Ĳ���������Щ�����洢��Parameter��
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
    public Parameter parameter;//������ɫ��Parameter
    private IState currentState;//��ʾ��ɫ��ǰ��״̬
    private Dictionary<StateType, IState> state = new Dictionary<StateType, IState>();//ע���ֵ�

    void Start()
    {
        
        state.Add(StateType.Idle,new IdleState(this));
        state.Add(StateType.Chase,new ChaseState(this));
        //��ʼ������״̬
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

    public void TransitionState(StateType type)//�ı�״̬
    {

        if (currentState != null)
            currentState.OnExit();
        currentState = state[type];
        currentState.OnEnter();
    }
}