using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Subject
{
    private CameraController cameraController;
    [SerializeField] private float turnRadius;
    [SerializeField] private float driveAccel;
    [SerializeField] private float reverseAccel;

    [SerializeField] private Factory crashSound;
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

    //FixedUpdate allows consistent updates regardless of user's frame rate
    void FixedUpdate()
    {
        Move();
    }

    private void OnCollisionEnter(Collision other) {
        if(!other.gameObject.name.Contains("TARMAC")){
            crashSound.GetEffect(transform.position);
        }
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.W))    //Forward input
        {
            MoveCommand aCommand = new MoveCommand("W", gameObject, driveAccel);
            moves.Add(aCommand);
            aCommand.Execute();
        }
        if (Input.GetKey(KeyCode.A))    //Turn Left input
        {
            MoveCommand aCommand = new MoveCommand("A", gameObject, turnRadius);
            moves.Add(aCommand);
            aCommand.Execute();
        }
        if (Input.GetKey(KeyCode.S))    //Backward input
        {
            MoveCommand aCommand = new MoveCommand("S", gameObject, reverseAccel);
            moves.Add(aCommand);
            aCommand.Execute();
        }
        if (Input.GetKey(KeyCode.D))    //Turn Right input
        {
            MoveCommand aCommand = new MoveCommand("D", gameObject, turnRadius);
            moves.Add(aCommand);
            aCommand.Execute();
        }
        if (Input.GetKey(KeyCode.R))    //Redo full list of inputs
        {
            foreach (var m in moves)
            {
                m.Execute();
            }
        }
        if (Input.GetKey(KeyCode.P))    //Print out list of inputs (mainly for debugging)
        {
            foreach (var m in moves)
            {
                Debug.Log(m.Direction);
            }
        }
        if (Input.GetKey(KeyCode.U))    //Undo/Unexecute function to undo any previous inputs
        {
            for (int i = moves.Count - 1; i >= 0; i--)
            {
                moves[i].UnExecute();
            }
            moves.Clear();
        }
    }
}