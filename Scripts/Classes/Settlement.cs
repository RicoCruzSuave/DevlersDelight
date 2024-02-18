using System;
using System.Collections.Generic;
using System.Linq;

public class Settlement 
{
    private int population = 0;
    private int maxPopulation = 10;
    
    public struct settlement_building
    {
        public Building building;
        public int stackSize = 0;
        public settlement_building(Building building, int stackSize)
        {
            this.building = building;
            this.stackSize = stackSize;
        }
    }

    private List<settlement_building> buildings = new List<settlement_building>();


    //Building Management
    public int GetBuildingCountByType(GlobalStuff.BuildingTypes type)
    {
        return buildings.Count(b => b.building.Type == type);
    }   
    public int GetTotalBuildingCount()
    {
        return buildings.Count();
    }
    public void RemoveBuildingOrAmount(Building building, int amount)
    {
        settlement_building s_building = GetBuildingOrDefault(building);
        
        // inv_item and default(settlement_building) cannot be directly compared so this should (hopefully) do the trick
        //default(settlement_building) is basically no item found aka (this is a check if the list has found the item inventory)
        if(amount == 0 || s_building.building == default(settlement_building).building) return;

        s_building.stackSize -= amount;
        if(s_building.stackSize <= 0)
            buildings.Remove(s_building);
            
    }
    public void AddBuildingOrAmount(Building building, int amount)
    {
        if(amount == 0) return;

        settlement_building s_building = GetBuildingOrDefault(building);

        // inv_item and default(settlement_building) cannot be directly compared so this should (hopefully) do the trick
        //default(settlement_building) is basically no item found aka (this is a check if the list has found the item inventory)
        if(s_building.building == default(settlement_building).building)
        { 
            buildings.Add(new settlement_building(building, amount));
        }else
        {
            s_building.stackSize += amount;
        }

    }
    //Get the settlement_building itself with stacksizeby name or item-object
    //default(settlement_building) is basically no item found aka (this is a check if the list has found the item in inventory)
    public settlement_building GetBuildingOrDefaultByName(string buildingName)
    {
        return buildings.FirstOrDefault( i => i.building.BuildingName == buildingName);
    }
    public settlement_building GetBuildingOrDefault(Building building)
    {
        return buildings.FirstOrDefault( i => i.building == building);
    }

    //Population Management
    public void SetPopulation(int amount)
    {   
        //intentionally ignores maxPopulation
        this.population = amount;
    }
    public int GetPopulationSize()
    {
        return this.population;
    }

    public void AddPopulation(int amount)
    {
        if(population + amount > maxPopulation) return;
        this.population += amount;
    }

    //internal
    private void SetMaxPopulation(int amount)
    {
        this.maxPopulation += amount;
    }
}
