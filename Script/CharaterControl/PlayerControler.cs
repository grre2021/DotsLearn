using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


/// <summary>
/// 不要反复开启协程，大哥。。。。。。。。。。。。。。。。。。
/// </summary>
public class PlayerControler : MonoBehaviour
{


    [SerializeField] InputCenter inputCenter;
    [SerializeField] Transform tr_camera;
    [SerializeField] float speed;
    [SerializeField] float dash_speed;
    [SerializeField] GameObject perfad_bullet;
    [SerializeField] Transform gun_position;
    [SerializeField] LayerMask floorMask;
    private Vector3 direction;
    private Vector3 aimDirction;
    private Animator animPlayer;
    private CharacterController playerController;

    private bool is_move;
    private bool is_aim;
    private bool is_dashing;

    private void OnEnable()
    {
        Debug.Log("test");
        inputCenter.Move += InputCenter_Move;
        inputCenter.StopMove += InputCenter_StopMove;
        inputCenter.Aim += InputCenter_Aim;
        inputCenter.IdleAim += InputCenter_IdleAim;
        inputCenter.Shot += InputCenter_Shot;
        inputCenter.StopShot += InputCenter_StopShot;
        inputCenter.Flash += InputCenter_Flash;
    }



    private void OnDisable()
    {
        Debug.Log("test");
        inputCenter.Move -= InputCenter_Move;
        inputCenter.StopMove -= InputCenter_StopMove;
        inputCenter.Aim -= InputCenter_Aim;
        inputCenter.IdleAim -= InputCenter_IdleAim;
        inputCenter.Shot -= InputCenter_Shot;
        inputCenter.StopShot -= InputCenter_StopShot;
        inputCenter.Flash -= InputCenter_Flash;
        inputCenter.Exit();
    }

    private void Awake()
    {
        inputCenter.Init();
    }

    private void Start()
    {
        animPlayer = GetComponent<Animator>();
        playerController = GetComponent<CharacterController>();
        is_move = false;
        is_aim = false;
    }

    private void Update()
    {
        turning();
    }
    private void InputCenter_Move(Vector2 arg0)
    {
        Debug.Log("move");
        direction = new Vector3(arg0.x, 0, arg0.y);
        if (is_move) return;
        StartCoroutine(nameof(Movement));

    }
    private void InputCenter_StopMove()
    {
        StopCoroutine(nameof(Movement));
        animPlayer.SetBool("run", false);
        is_move = false;
    }

    IEnumerator Movement()
    {
        is_move = true;
        animPlayer.SetBool("run", true);
        while (true)
        {
            //根据摄像机的方向，计算旋转值
            float trangle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + tr_camera.eulerAngles.y;
//            Debug.Log(trangle);

            if (!is_aim)
            {
                playerController.transform.rotation = Quaternion.Slerp(playerController.transform.rotation, Quaternion.Euler(0, trangle, 0), 0.2f);
            }
            Vector3 move_direction = Quaternion.Euler(0, trangle, 0) * Vector3.forward;
            move_direction = move_direction.normalized;
            playerController.Move(move_direction * speed * Time.deltaTime);

            yield return null;
        }
    }

    private void InputCenter_Aim(Vector2 arg0)
    {
        aimDirction = new Vector3(arg0.x, 0, arg0.y);
        StartCoroutine(nameof(Aim));

    }
    private void InputCenter_IdleAim()
    {
        StopCoroutine(nameof(Aim));
        aimDirction = new Vector3(0, 0, 0);
        is_aim = false;
    }
    IEnumerator Aim()
    {
        is_aim = true;
        while (true)
        {
            float trangle = Mathf.Atan2(aimDirction.x, aimDirction.z) * Mathf.Rad2Deg + tr_camera.eulerAngles.y;
            playerController.transform.rotation = Quaternion.Slerp(playerController.transform.rotation, Quaternion.Euler(0, trangle, 0), 0.2f);
            yield return null;
        }
    }

    private void InputCenter_Shot()
    {
        StartCoroutine(nameof(Shooting));
    }
    private void InputCenter_StopShot()
    {
        StopCoroutine(nameof(Shooting));
    }
    IEnumerator Shooting()
    {
        while (true)
        {
            GameObject bullet = GameObject.Instantiate(perfad_bullet, gun_position.position, gun_position.rotation);
            PlayerProjictle playerProjictle = bullet.GetComponent<PlayerProjictle>();
            //playerProjictle.shot_direction = transform.forward;
            yield return new WaitForSeconds(0.2f);

        }
    }

    private void InputCenter_Flash()
    {
        StartCoroutine(nameof(Dashing));
    }

    IEnumerator Dashing()
    {
        is_dashing = true;
        while (true)
        {
            yield return null;
        }
    }

    void turning()
    {
        is_aim = true;
        Ray camRay = Camera.main.ScreenPointToRay(Mouse.current.position.ReadValue());

        RaycastHit floorHit;

        // Perform the raycast and if it hits something on the floor layer...
        if (Physics.Raycast(camRay, out floorHit, 200, floorMask))
        {
            Vector3 playerToMouse = floorHit.point - transform.position;


            playerToMouse.y = 0f;


            Quaternion newRotatation = Quaternion.LookRotation(playerToMouse);

            transform.rotation = Quaternion.Slerp(transform.rotation, newRotatation,5* Time.deltaTime);

        }
    }
}
