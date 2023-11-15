using Godot;
using System;
using System.Linq;
public partial class Background : Node2D
{
    [Export]
    private int total_pieces = 2;
    [Export]
    private bool mirrored = true;
    private Vector2 current_offset;
    private Node2D chunk_sequence;
    public override void _Ready()
    {
        //Onready vars
        chunk_sequence = GetNode<Node2D>("Sequence");
        //Initialize background pieces
        for (int i = -total_pieces; i <= total_pieces; i++)
        {
            if (!mirrored && i < 0)
            {
                continue;
            }
            Sprite2D new_bg_piece = (Sprite2D)chunk_sequence.Call("get_current_node", true);
            new_bg_piece = (Sprite2D)new_bg_piece.Duplicate();
            AddChild(new_bg_piece);
            new_bg_piece.Position = new Vector2(i * new_bg_piece.Texture.GetWidth(), 0);
            new_bg_piece.Offset = this.Position;
        }
    }

    public override void _Process(double delta)
    {
        //Get all children that arent the sequence
        var children = GetChildren()
            .Where(child => child.Name != "Sequence")
            .Select(child => child)
            .ToList();

    }
}
