using player;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using static UnityEngine.PlayerLoop.PreUpdate;
using UnityEngine.SceneManagement;
public class playerscript : MonoBehaviour
{

    public Image staminaWheel;
    public Camera playerCamera;
    public float walkSpeed = 3f;
    public float runSpeed = 6f;
    public float Stamina = 20;
    public int plortsLeft = 0;

    public int scene;
    public int death = 2;
    public GameObject Winscreen;

    GameObject self;

    public bool running;

    public float lookSpeed = 2f;
    public float lookXLimit = 45f;

    public StateMachineP sm;
    public walkState ws;
    public runState rs;
    public deathState ds;


    public Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    public bool canMove = true;


    CharacterController characterController;
    void Start()
    {
        self = transform.gameObject;
        sm = gameObject.AddComponent<StateMachineP>();

        ws = new walkState(this, sm);
        rs = new runState(this, sm);
        ds = new deathState(this, sm);

        sm.Init(ws);

        characterController = GetComponent<CharacterController>();
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        GameObject[] plorts = GameObject.FindGameObjectsWithTag("Plortable");

        foreach (GameObject plort in plorts)
        {
            plortsLeft++;
        }
    }

    void Update()
    {
        sm.CurrentState.LogicUpdate();

        ObjectiveComplete();

        #region Handles Rotation
        characterController.Move(moveDirection * Time.deltaTime);

        if (canMove)
        {
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        #endregion
    }
    private void FixedUpdate()
    {
        sm.CurrentState.PhysicsUpdate();


    }
    private void OnTriggerEnter(Collider other)
    {
        print("Collided");
        if (other.transform.tag == "Plortable")
        {
            plortsLeft--;
            print(plortsLeft);
            Destroy(other.gameObject);
        }

        if (other.transform.tag == "Hurt")
        {
            Die();
        }
    }

    void ObjectiveComplete()
    {
        if(plortsLeft <= 0)
        {
            print("YOu wuin");
            Winscreen.SetActive(true);
            sm.ChangeState(ds);
        }
    }
    void Die()
    {
        SceneManager.LoadScene(death);
    }
}