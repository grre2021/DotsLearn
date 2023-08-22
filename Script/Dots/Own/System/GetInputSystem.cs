using Unity.Burst;
using Unity.Entities;
using UnityEngine;
using UnityEngine.InputSystem;

[UpdateInGroup(typeof(SpampleSceneSystemGroup))]
public partial class GetInputSystem : SystemBase
{
    private InputManager _inputManager;
    private Entity player;
    protected override void OnCreate()
    {
        base.OnCreate();
        RequireForUpdate<ShootTag>();
        RequireForUpdate<ShootAthoring>();
        _inputManager = new InputManager();
        
    }

    protected override void OnStartRunning()
    {
        base.OnStartRunning();
        _inputManager.Enable();
        _inputManager.GameInput.shot.performed += Shoot;
        player = SystemAPI.GetSingletonEntity<ShootAthoring>();
    }

    protected override void OnUpdate()
    {
        
    }

    protected override void OnStopRunning()
    {
        base.OnStopRunning();
        _inputManager.Disable();
       
    }

    protected override void OnDestroy()
    {
        base.OnDestroy();
    }
    
    private void Shoot(InputAction.CallbackContext obj)
    {
        Debug.Log(SystemAPI.Exists(player));
        if (!SystemAPI.Exists(player)) return;
        Debug.Log("shoot");
        Ray camRay = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit floorHit;
        Debug.Log(Physics.Raycast(camRay, out floorHit, 200, LayerMask.NameToLayer("Floor")));

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, 200, LayerMask.NameToLayer("Floor")))
        {
            Debug.Log(floorHit.point);
        }
        SystemAPI.SetComponentEnabled<ShootTag>(player,true);
    }
}        
