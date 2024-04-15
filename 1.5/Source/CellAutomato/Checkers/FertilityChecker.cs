using RimWorld;
using Verse;

namespace CellAutomato
{
    public class FertilityChecker : CheckerTreeNode
    {
        float fertilityLevel = 0f;

        public override bool Check(IntVec3 center, Map map, bool secondCheck = false)
        {
            if (map.fertilityGrid.FertilityAt(center) > fertilityLevel)
            {
                return success == Success.Normal ? true : false;
            }

            return success == Success.Normal ? false : true;
        }
    }
}
