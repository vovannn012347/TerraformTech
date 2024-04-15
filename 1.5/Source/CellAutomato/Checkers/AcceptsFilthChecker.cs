using RimWorld;
using System.Collections.Generic;
using TerraformTech;
using Verse;

namespace CellAutomato
{
    //test whether a cell in range has all of tags in mustinclude and no tags with mustnotinclude
    public class AcceptsFilthChecker : CheckerTreeNode
    {
        public List<ThingDef> defs;
        
        public override bool Check(IntVec3 center, Map map, bool secondCheck = false)
        {
            if (defs != null && defs.Count > 0)
            {
                foreach (var def in defs)
                {
                    if (FilthMaker.TerrainAcceptsFilth(map.terrainGrid.TerrainAt(center), def))
                    {
                        return success == Success.Normal ? true : false;
                    }
                }
            }

            return success == Success.Normal ? false : true;
        }
    }
}
