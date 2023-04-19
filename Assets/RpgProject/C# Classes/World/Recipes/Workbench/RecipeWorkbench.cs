using System.Collections.Generic;
using RpgProject.Objects;

public class RecipeWorkbench 
{
    /*==============={ Necessary }================*/
        public List<ItemComponent> recipeRequires;
        public List<ItemComponent> recipeResults;

    /*==============={ Optionnal }================*/

        // For this class, the level of player is checked but for other Recipe classes it may be the Jobs level
        public int unlockAtLevel;

        // !!FOR VERY SPECIFIC CASE!!
        public bool KeepItems;

    public RecipeWorkbench(List<ItemComponent> a, List<ItemComponent> b, int unlockAtLevel, bool KeepItems)
    {
        recipeRequires = a;
        recipeResults = b;
        this.unlockAtLevel = unlockAtLevel;
        this.KeepItems = KeepItems;

        RpgClass.WORKBENCH_RECIPES.Add(this);
    }

    public bool isValid()
    {
        //blablabla return false;
        return true;
    }

    public void Make()
    {
        //Blabla delete items and give item to player
        for(int i = 0; i < recipeResults.Count; ++i)
        {
            Player.instance.inventory.AddItem(recipeResults[i].getItem());
        }
    }
}
