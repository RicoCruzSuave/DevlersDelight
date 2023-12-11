using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
[Tool]
public partial class DungeonMapGenerator : Node2D
{
    [Export]
    private bool RunTool = false;
    [Export]
    private Node2D Lines;
    [Export]
    private Node2D TopNode;
    [Export]
    private int NumberOfLayers = 3;
    [Export]
    private Vector2I LayerSize = new Vector2I(1000, 200);
    [Export]
    private Vector2I NodesPerLayer = new Vector2I(1, 5);
    [Export]
    private Texture2D tex;
    private List<Node2D> Layers = new List<Node2D>();

    public override void _Ready()
    {
        base._Ready();
        LoadLayers();
        DrawLines();
    }

    public override void _Process(double delta)
    {
        base._Process(delta);
        if (RunTool)
        {
            RunTool = false;
            LoadLayers();
            DeleteLines();
            DrawLines();
        }
    }

    private void LoadLayers()
    {
        foreach (Node2D OldLayer in Layers)
        {
            OldLayer.Free();
        }
        foreach (Node2D child in TopNode.GetChildren())
        {
            child.Free();
        }
        Layers = new List<Node2D>();

        //Create new Layers
        Random rnd = new Random();
        for (int i = 0; i < NumberOfLayers; i++)
        {
            Node2D NewLayer = new Node2D();
            NewLayer.Name = "Layer" + i.ToString();
            Layers.Add(NewLayer);
            TopNode.AddChild(NewLayer);
            NewLayer.Owner = GetTree().EditedSceneRoot;

            for (int j = 0; j < rnd.Next(NodesPerLayer.X, NodesPerLayer.Y); j++)
            {
                Marker2D NewMarker = new Marker2D();
                NewMarker.Name = "Layer" + i.ToString() + "Marker" + j.ToString();

                Vector2 NewPosition = new Vector2(
                    rnd.Next(0, LayerSize.X),
                    (LayerSize.Y * i) + rnd.Next(0, LayerSize.Y)
                );
                while (tex.GetImage().GetPixelv(new Vector2I((int)NewPosition.X, (int)NewPosition.Y)).R < 0.75)
                {
                    NewPosition = new Vector2(
                        rnd.Next(0, LayerSize.X),
                        (LayerSize.Y * i) + rnd.Next(0, LayerSize.Y)
                    );
                }
                NewMarker.GlobalPosition = NewPosition;

                NewLayer.AddChild(NewMarker);
                NewMarker.Owner = GetTree().EditedSceneRoot;
            }
        }
    }
    private void DeleteLines()
    {
        // Clean Up Lines
        foreach (Line2D child in Lines.GetChildren())
        {
            child.Free();
        }
    }

    private void DrawLines()
    {
        int Index = 0;
        while (Index < Layers.Count - 1)
        {

            foreach (Marker2D StartPoint in Layers[Index].GetChildren())
            {
                if (StartPoint is ConnectionNode)
                {
                    foreach (Node2D Connection in ((ConnectionNode)StartPoint).Connections)
                    {
                        Line2D Line = new Line2D();
                        Line.AddPoint(StartPoint.GlobalPosition);
                        Line.AddPoint(Connection.GlobalPosition);
                        Lines.AddChild(Line);
                        Line.Owner = GetTree().EditedSceneRoot;
                    }
                }
                else
                {
                    foreach (Marker2D EndPoint in Layers[Index + 1].GetChildren())
                    {
                        Line2D Line = new Line2D();
                        Line.Width = 2;
                        Line.AddPoint(StartPoint.GlobalPosition);
                        Line.AddPoint(EndPoint.GlobalPosition);
                        Lines.AddChild(Line);
                        Line.Owner = GetTree().EditedSceneRoot;
                    }
                }
            }
            Index += 1;
        }
    }
}
