using System;
using System.Collections.Generic;
using System.Linq;

public class Inventory 
{
    public struct inventory_item {
        public Item item;
        public int stackSize = 0;

        public inventory_item(Item item, int amount){
            this.item = item;
            this.stackSize = amount;
        }
    }

    private List<inventory_item> items = new List<inventory_item>();
    private float money = 0.00f;

    //Money Management
    public void AddMoney(float amount){
        this.money += (float)Math.Round(amount,2); //Amount will always round to 2 decimal places
    }
    public float GetMoney(){
        return this.money;
    }

    //Item Management
    public void RemoveItemOrAmount(Item item, int amount)
    {
        inventory_item inv_item = GetItemOrDefault(item);
        
        // inv_item and default(inventory_item) cannot be directly compared so this should (hopefully) do the trick
        //default(inventory_item) is basically no item found aka (this is a check if the list has found the item inventory)
        if(amount == 0 || inv_item.item == default(inventory_item).item) return;

        inv_item.stackSize -= amount;
        if(inv_item.stackSize <= 0)
            items.Remove(inv_item);
            
    }
    public void AddItemOrAmount(Item item, int amount)
    {
        if(amount == 0) return;

        inventory_item inv_item = GetItemOrDefault(item);

        // inv_item and default(inventory_item) cannot be directly compared so this should (hopefully) do the trick
        //default(inventory_item) is basically no item found aka (this is a check if the list has found the item inventory)
        if(inv_item.item == default(inventory_item).item)
        { 
            items.Add(new inventory_item(item, amount));
        }else
        {
            inv_item.stackSize += amount;
        }

    }

    //Get the inventory_item itself with stacksizeby name or item-object
    //default(inventory_item) is basically no item found aka (this is a check if the list has found the item in inventory)
    public inventory_item GetItemOrDefaultByName(string itemName)
    {
        return items.FirstOrDefault( i => i.item.ItemName == itemName);
    }
    public inventory_item GetItemOrDefault(Item item)
    {
        return items.FirstOrDefault( i => i.item == item);
    }

}
