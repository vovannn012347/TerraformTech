using System.Collections.Generic;
using Verse;

namespace CellAutomato
{
    public class RoofedChecker : CheckerTreeNode
    {
        public override bool Check(IntVec3 center, Map map, bool secondCheck = false)
        {
            if (map.roofGrid.Roofed(center))
            {
                return success == Success.Normal ? true : false;
            }

            return success == Success.Normal ? false : true;
        }
    }
}
