using Godot;

public partial class Coin : Area2D
{
    private void OnBodyEntered(Node2D body)
    {
        AddPoint();
        QueueFree();
    }

    private void AddPoint()
    {
        GameManager.Instance.AddPoint();
    }
}
