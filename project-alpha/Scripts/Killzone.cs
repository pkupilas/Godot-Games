using Godot;

public partial class Killzone : Area2D
{
    private Timer timer;

    public override void _Ready()
    {
        timer = GetNode<Timer>("Timer");
        SetUpTimer();
    }

    private void SetUpTimer()
    {
        if (timer == null)
        {
            return;
        }

        timer.Timeout += OnTimerTimeout;
    }

    private void OnTimerTimeout()
    {
        GetTree().ReloadCurrentScene();
    }

    private void OnBodyEntered(Node2D body)
    {
        timer.Start();
    }
}
