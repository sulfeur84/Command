using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour {

    private Stack<Command> Commands = new Stack<Command>();

    public GameObject PostPro;
    
    private void Update() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            Command command = new Forward(transform);
            command.Do();
            Commands.Push(command);
        }
        
        if (Input.GetKeyDown(KeyCode.S)) {
            Command command = new Backward(transform);
            command.Do();
            Commands.Push(command);
        }
        
        if (Input.GetKeyDown(KeyCode.Q)) {
            Command command = new Left(transform);
            command.Do();
            Commands.Push(command);
        }
        
        if (Input.GetKeyDown(KeyCode.D)) {
            Command command = new Right(transform);
            command.Do();
            Commands.Push(command);
        }
        
        if (Input.GetButtonDown("Jump"))
        {
            Invoke("TimeMachine", 0.1f);
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
        Command command = Commands.Pop();
        command.Undo();
        Invoke(nameof(TimeMachine), 0.5f);
        if (Commands.Count == 0)
        {
            PostPro.gameObject.SetActive(false);
            CancelInvoke();
        }
    }
    
}
