using Godot;

public partial class GameManager : Node
{
    [Signal]
    public delegate void PointsChangeEventHandler(int points);

    public static GameManager Instance { get; private set; }

    public int Score { get; private set; } = 0;

    public override void _Ready()
    {
        Instance = this;
    }

    public void AddPoint()
    {
        Score++;
        EmitSignal(SignalName.PointsChange, Score);
    }
}
