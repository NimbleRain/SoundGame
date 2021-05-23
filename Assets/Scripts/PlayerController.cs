using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] //2
[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{

    Rigidbody myRigidbody;                                                  //2
    Vector3 velocity;
    public Camera mainCamera;
    public Transform crosshairs;

    private CharacterController characterController = null;

    private float movementSpeed = 15.0f;                                //플레이어의 속도
                                                                        //private bool isWalk = false;
    private Vector3 lastPos;                                            //움직임 체크 변수


    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    private const float clampAngleDegrees = 80.0f;
    private const float sensitivity = 2.0f;
    void Start()
    {
        characterController = GetComponent<CharacterController>();
        myRigidbody = GetComponent<Rigidbody>(); //2
        Vector3 rotation = mainCamera.transform.localRotation.eulerAngles;
        rotationX = rotation.x;
        rotationY = rotation.y;
    }
    public void Move(Vector3 _velocity)
    {
        velocity = _velocity;
    }

    public void LookAt(Vector3 lookPoint)
    {
        Vector3 heightCorrectedPoint = new Vector3(lookPoint.x, transform.position.y, lookPoint.z);
        transform.LookAt(lookPoint);
    }

    public void FixedUpdate()
    {
        myRigidbody.MovePosition(myRigidbody.position + velocity * Time.fixedDeltaTime);
    }
    void LateUpdate()
    {

        //if (Input.GetMouseButtonDown(0))
        //{
        //    SetCursorLock(true);
        //}
        //else if (Input.GetKeyDown(KeyCode.Escape)) //esc 키
        //{
        //    SetCursorLock(false);
        //}

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y");


        rotationX += sensitivity * mouseY;
        rotationY += sensitivity * mouseX;
        rotationX = Mathf.Clamp(rotationX, -clampAngleDegrees, clampAngleDegrees);
        mainCamera.transform.localRotation = Quaternion.Euler(rotationX, rotationY, 0.0f);

        float movementX = Input.GetAxis("Horizontal");
        float movementY = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(movementX, 0.0f, movementY);
        movementDirection = mainCamera.transform.localRotation * movementDirection;
        movementDirection.y = 0.0f;
        characterController.SimpleMove(movementSpeed * movementDirection);
    }   
   
    //void SetCursorLock(bool lockCursor)                         //게임 속 마우스 커서를 화면 창 밖에 안나가기 위한 함수
    //{
    //    if (lockCursor)
    //    {
    //        Cursor.lockState = CursorLockMode.Locked;
    //        Cursor.visible = false;
    //    }
    //    else
    //    {
    //        Cursor.lockState = CursorLockMode.None;
    //        Cursor.visible = true;
    //    }
    //}



}

    
