using System.Collections.Generic;
using Verse;

namespace CellAutomato
{
    public class BuildingChecker : CheckerTreeNode
    {
        private List<Traversability> traversability;

        public override bool Check(IntVec3 center, Map map, bool secondCheck = false)
        {
            //Log.Message("BuildingOnTopChecker");
            if (traversability != null)
            {
                var building = center.GetFirstBuilding(map);
                if (building != null && traversability.Contains(building.def.passability))
                {
                    return success == Success.Normal ? true : false;
                }
            }
            else
            {
                if (center.GetFirstBuilding(map) != null)
                {
                    return success == Success.Normal ? true : false;
                }
            }

            return success == Success.Normal ? false : true;
        }
    }
}
//[Guid("4F91E2EC-EC8C-48D1-B185-9898C0738CBE")]
