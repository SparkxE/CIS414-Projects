using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : Subject
{
    [SerializeField] private float turnRadius;
    [SerializeField] private float driveAccel;
    [SerializeField] private float reverseAccel;

    private List<IMove> moves = new List<IMove>();

    //FixedUpdate allows consistent updates regardless of user's frame rate
    void FixedUpdate()
    {
        Move();
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

    public void OnCollisionEnter(Collision collision)
    {
        if(!collision.gameObject.name.Contains("TARMAC") || collision.gameObject.CompareTag("Obstacle")){
            //notify CrashEffectFactory & damage management code of collision with Obstacle
            NotifyObservers();
        }
    }
}