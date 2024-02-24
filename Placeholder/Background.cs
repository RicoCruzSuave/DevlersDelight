using Godot;
using System;
using System.Linq;
using System.Collections.Generic;
public partial class Background : Node2D
{
    [Export]
    private int min_width = 400;
    [Export]
    private int max_width = 600;
    private Node2D chunk_sequence;
    private List<Sprite2D> chunk_list = new List<Sprite2D>();
    public override void _Ready()
    {
        //Onready vars
        chunk_sequence = GetNode<Node2D>("Sequence");
    }

    public override void _Process(double delta)
    {
        // Position += new Vector2(10.0F, 0.0F);
        //If empty, add a chunk
        if (chunk_list.Count <= 0)
        {
            AddChunk(true);
        }
        //Make sure there are chunks up to the min_width 
        var first_chunk = chunk_list.First();
        var last_chunk = chunk_list.Last();
        if (this.GlobalPosition.DistanceTo(first_chunk.GlobalPosition) < min_width)
        {
            AddChunk(true);
        }
        if (this.GlobalPosition.DistanceTo(last_chunk.GlobalPosition) < min_width)
        {
            AddChunk(false);
        }
        //If chunk is outside max_width, delete it
        if (this.GlobalPosition.DistanceTo(first_chunk.GlobalPosition) > max_width)
        {
            first_chunk.Free();
            chunk_list.RemoveAt(0);
        }
        if (this.GlobalPosition.DistanceTo(last_chunk.GlobalPosition) > max_width)
        {
            last_chunk.Free();
            chunk_list.RemoveAt(chunk_list.Count - 1);
        }

    }

    public void AddChunk(bool is_left_side)
    {
        Sprite2D new_bg_piece = (Sprite2D)chunk_sequence.Call("get_current_node");
        new_bg_piece = (Sprite2D)new_bg_piece.Duplicate();
        AddChild(new_bg_piece);


        if (is_left_side)
        {
            float offset = 0.0F;
            if (chunk_list.Count > 0)
            {
                var currentChunk = chunk_list.First();
                var currentChunkSize = currentChunk.Texture.GetWidth() * currentChunk.Scale.X;
                var bgPieceSize = new_bg_piece.Texture.GetWidth() * new_bg_piece.Scale.X;
                offset = currentChunkSize / 2 + bgPieceSize / 2;
                // offset = chunk_list.First().Texture.GetWidth() / 2 + (new_bg_piece.Texture.GetWidth() * new_bg_piece.Scale.X) / 2;
                new_bg_piece.GlobalPosition = new Vector2(chunk_list.First().Position.X - offset, this.GlobalPosition.Y);
            }
            chunk_list.Insert(0, new_bg_piece);
        }
        else
        {
            float offset = 0.0F;
            if (chunk_list.Count > 0)
            {
                var currentChunk = chunk_list.Last();
                var currentChunkSize = currentChunk.Texture.GetWidth() * currentChunk.Scale.X;
                var bgPieceSize = new_bg_piece.Texture.GetWidth() * new_bg_piece.Scale.X;
                offset = currentChunkSize / 2 + bgPieceSize / 2;
                // offset = chunk_list.Last().Texture.GetWidth() / 2 + (new_bg_piece.Texture.GetWidth() * new_bg_piece.Scale.X) / 2;
                new_bg_piece.GlobalPosition = new Vector2(chunk_list.Last().Position.X + offset, this.GlobalPosition.Y);
            }
            chunk_list.Add(new_bg_piece);
        }

    }
}
