using Godot;

public partial class GameplayPanel : CanvasLayer
{
    [Export]
    public Label scoreLabel;

    public override void _Ready()
    {
        GameManager.Instance.PointsChange += OnPointChanged;
        scoreLabel.Text = "0";
    }

    private void OnPointChanged(int points)
    {
        scoreLabel.Text = $"{points}";
    }
}
