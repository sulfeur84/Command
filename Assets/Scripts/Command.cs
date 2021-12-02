using UnityEngine;

public abstract class Command {

    protected Transform _transform;

    protected Command(Transform transform) {
        _transform = transform;
    }

    public abstract void Do();
    public abstract void Undo();

}
