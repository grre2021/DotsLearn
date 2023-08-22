using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
[CreateAssetMenu]
public class InputCenter : ScriptableObject, InputManager.IGameInputActions
{
    private InputManager inputActions;

    public event UnityAction<Vector2> Move = delegate { };
    public event UnityAction StopMove= delegate { };
    public event UnityAction<Vector2> Aim=delegate { };
    public event UnityAction IdleAim = delegate { };
    public event UnityAction Shot=delegate { };
    public event UnityAction StopShot=delegate { };
    public event UnityAction Flash=delegate { };

    public void Init()
    {
        inputActions = new InputManager();//ʵ����
        inputActions.GameInput.SetCallbacks(this);//�ȼ�Gameinput�Ļص�����
        EnableGameInput();
        Debug.Log("Enable");
    }

    public void Exit()
    {
        DisableAllInput();
        Debug.Log("DisEnable");
    }
    private void OnEnable()
    {
        inputActions = new InputManager();//ʵ����
        inputActions.GameInput.SetCallbacks(this);//�ȼ�Gameinput�Ļص�����
        EnableGameInput();
        Debug.Log("Enable");
    }

    private void OnDisable()
    {
        DisableAllInput();
        Debug.Log("DisEnable");
    }

    public void EnableGameInput()
    {
        inputActions.GameInput.Enable();//����Gameinput
    }
    public void DisableAllInput()//�˺�������ֹͣGameinput������
    {
        inputActions.GameInput.Disable();
    }


    public void OnMove(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Debug.Log("move"+"aaa");
            Move.Invoke(context.ReadValue<Vector2>());
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            StopMove.Invoke();
        }
      
    }

    public void OnAim(InputAction.CallbackContext context)
    {
       if(context.phase == InputActionPhase.Performed)
        {
            Aim.Invoke(context.ReadValue<Vector2>());
        }
       else if(context.phase == InputActionPhase.Canceled)
        {
            IdleAim.Invoke();
        }
    }

    public void OnShot(InputAction.CallbackContext context)
    {
        if(context.phase==InputActionPhase.Performed)
        {
            Shot.Invoke();
        }
        if(context.phase==InputActionPhase.Canceled)
        {
            StopShot.Invoke();
        }
    }

    public void OnFlash(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Performed)
        {
            Flash.Invoke();
        }
    }
}
