using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour {

    private Stack<Command> Commands = new Stack<Command>();
    
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
        
        if (Input.GetButtonDown("Jump") && Commands.Count > 0) {
            Command command = Commands.Pop();
            command.Undo();
        }
    }
    
}
