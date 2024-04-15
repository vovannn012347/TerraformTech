using System.Collections.Generic;
using Verse;

namespace CellAutomato
{
    public class TreeOnTopChecker : CheckerTreeNode
    {
        public override bool Check(IntVec3 center, Map map, bool secondCheck = false)
        {
            //Log.Message("TreeOnTopChecker");
            var plant = center.GetPlant(map);
            if (plant != null && plant.def.plant.IsTree)
            {
                return success == Success.Normal ? true : false;
            }

            return success == Success.Normal ? false : true;
        }
    }
}
