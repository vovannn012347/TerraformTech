using RimWorld;
using Verse;

namespace CellAutomato
{
    public class SpawnPlantChecker : CheckerTreeNode
    {
        public override bool Check(IntVec3 center, Map map, bool secondCheck = false)
        {
            if (center.GetPlant(map) != null || 
                center.GetCover(map) != null || 
                center.GetEdifice(map) != null || 
                !PlantUtility.SnowAllowsPlanting(center, map))
            {
                return success == Success.Normal ? false : true;
            }

            return success == Success.Normal ? true : false;
        }
    }
}
