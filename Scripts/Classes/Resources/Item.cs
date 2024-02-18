using Godot;
using System;


public partial class Item : Resource
{
    [Export] public Texture Icon;
    [Export] public string ItemName {get;set;}
    [Export] public GlobalStuff.ItemTypes Type {get;set;}

}
