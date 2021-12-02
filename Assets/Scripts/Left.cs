using UnityEngine;

public class Left : Command
{
    public Left(Transform transform) : base(transform) { }
    public override void Do() {
        _transform.Translate(-1, 0, 0);
    }
    
    public override void Undo() {
        _transform.Translate(1, 0, 0);
    }
}