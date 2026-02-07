using Godot;

public partial class Coin : Area2D
{
    private AnimationPlayer animationPlayer = null;
    private string PickUpAnimationName = "PickUpAnimation";

    public override void _Ready()
    {
        animationPlayer = GetNode<AnimationPlayer>("AnimationPlayer");
    }

    private void OnBodyEntered(Node2D body)
    {
        AddPoint();
    }

    private void AddPoint()
    {
        GameManager.Instance.AddPoint();
        animationPlayer.Play(PickUpAnimationName);
    }
}
