using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour {

    private Stack<Command> Commands = new Stack<Command>();

    public GameObject PostPro;

    public float TimeStart, TimeCadence;

    public AudioSource musique;

    private bool Rewind = false;
    
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Z) && Rewind == false) {
            Command command = new Forward(transform);
            command.Do();
            Commands.Push(command);
        }
        
        if (Input.GetKeyDown(KeyCode.S) && Rewind == false) {
            Command command = new Backward(transform);
            command.Do();
            Commands.Push(command);
        }
        
        if (Input.GetKeyDown(KeyCode.Q) && Rewind == false) {
            Command command = new Left(transform);
            command.Do();
            Commands.Push(command);
        }
        
        if (Input.GetKeyDown(KeyCode.D) && Rewind == false) {
            Command command = new Right(transform);
            command.Do();
            Commands.Push(command);
        }
        
        if (Input.GetButtonDown("Jump") && Rewind == false && Commands.Count > 0)
        {
            musique.pitch = -1;
            Rewind = true;
            Invoke("TimeMachine", TimeStart);
            PostPro.gameObject.SetActive(true);
        }
        
        
        /*if (Input.GetButtonDown("Jump") && Commands.Count > 0) {
            Command command = Commands.Pop();
            command.Undo();
            PostPro.gameObject.SetActive(true);
        }if (Input.GetButtonUp("Jump")) PostPro.gameObject.SetActive(false);*/
    }

    public void TimeMachine()
    {
        TimeStart -= 0.1f ;
        Command command = Commands.Pop();
        command.Undo();
        Invoke(nameof(TimeMachine), TimeStart);

        if (TimeStart <= 0.2f) TimeStart = 0.2f;
        
        if (Commands.Count == 0)
        {
            musique.pitch = 1;
            TimeStart = TimeCadence;
            Rewind = false;
            PostPro.gameObject.SetActive(false);
            CancelInvoke();
        }
    }
    
}
