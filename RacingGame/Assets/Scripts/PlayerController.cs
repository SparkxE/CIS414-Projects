using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Subject
{
    private CameraController cameraController;
    [SerializeField] private float turnRadius;
    [SerializeField] private float driveAccel;
    public bool IsWarpOn
    {
        get; private set;
    }

    private void Awake()
    {    // we may have to change it later 
        
        cameraController = FindObjectOfType<CameraController>();

        // gameObject.AddComponent<CameraController>;//we might have to find the camera and then find it 
    }

    private void OnEnable()
    {
      
        if (cameraController)
        {

            Attach(cameraController);
        }


    }
    private void OnDisable()
    {
       

        if (cameraController)
        {

            Detach(cameraController);
        }


    }

    [SerializeField] private Transform playerTransform;
    private List<IMove> moves = new List<IMove>();

    // Update is called once per frame
    void FixedUpdate()
    {
        Move();
        // if(Input.GetKey(KeyCode.W)){
        //     playerTransform.position = playerTransform.position + transform.forward;
        // }
        // if(Input.GetKey(KeyCode.A)){
        //     playerTransform.position = playerTransform.position - transform.right;
        // }
        // if(Input.GetKey(KeyCode.S)){
        //     playerTransform.position = playerTransform.position - transform.forward;
        // }
        // if(Input.GetKey(KeyCode.D)){
        //     playerTransform.position = playerTransform.position + transform.right;
        // }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))
        {
            MoveCommand aCommand = new MoveCommand("W", gameObject);
            moves.Add(aCommand);
            // playerTransform.position = playerTransform.position + transform.forward;
            aCommand.Execute();
        }
        if (Input.GetKey(KeyCode.A))
        {
            MoveCommand aCommand = new MoveCommand("A", gameObject);
            moves.Add(aCommand);
            // playerTransform.position = playerTransform.position - transform.right;
            aCommand.Execute();
        }
        if (Input.GetKey(KeyCode.S))
        {
            MoveCommand aCommand = new MoveCommand("S", gameObject);
            moves.Add(aCommand);
            // playerTransform.position = playerTransform.position - transform.forward;
            aCommand.Execute();
        }
        if (Input.GetKey(KeyCode.D))
        {
            MoveCommand aCommand = new MoveCommand("D", gameObject);
            moves.Add(aCommand);
            // playerTransform.position = playerTransform.position + transform.right;
            aCommand.Execute();
        }
        if (Input.GetKey(KeyCode.R))
        {
            foreach (var m in moves)
            {
                m.Execute();
            }
        }
        if (Input.GetKey(KeyCode.P))
        {
            foreach (var m in moves)
            {
                Debug.Log(m.Direction);
            }
        }
        if (Input.GetKey(KeyCode.U))
        {
            for (int i = moves.Count - 1; i >= 0; i--)
            {
                moves[i].UnExecute();
            }
            moves.Clear();
        }
    }
}