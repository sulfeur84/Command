using UnityEngine;

public class Backward : Command {
    
    public Backward(Transform transform) : base(transform) { }
    
    public override void Do() {
        _transform.Translate(0, 0, -1);
    }

    public override void Undo() {
        _transform.Translate(0, 0, 1);
    }
    
}