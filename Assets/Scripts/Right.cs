using UnityEngine;

public class Right : Command
{
    public Right(Transform transform) : base(transform) { }
    public override void Do() {
        _transform.Translate(1, 0, 0);
    }
    
    public override void Undo() {
        _transform.Translate(-1, 0, 0);
    }
}
