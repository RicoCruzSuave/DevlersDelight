using Godot;
using System;
public partial class TextEffect : RigidBody2D
{
    [Export]
    public string text = "Test";
    [Export]
    public float speed = 500.0F;
    [Export]
    public float time = 1.5F;
    private Timer timer;
    private Label label;
    public override void _Ready()
    {
        label = GetNode<Label>("Label");
        timer = GetNode<Timer>("Timer");
        label.Text = text;
        timer.WaitTime = time;
        timer.Start();

    }

    public override void _Process(double delta)
    {
        Color mod = Modulate;
        mod.A = (float)((timer.TimeLeft / timer.WaitTime) * (timer.TimeLeft / timer.WaitTime));
        Modulate = mod;

        if (timer.IsStopped()) { Free(); }
    }

    public void Launch(Vector2 dir, double variance)
    {
        var rand = new Random();
        float rand_variance = (float)(rand.NextDouble() * (variance - -variance) + -variance);
        Vector2 impulse = dir.Rotated(rand_variance);
        ApplyCentralImpulse(impulse * speed);
    }
}

