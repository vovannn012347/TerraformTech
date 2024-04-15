﻿using System.Collections.Generic;
using Verse;

namespace CellAutomato
{
    public class AdjancentRoomChecker : CheckerTreeNode
    {

        public override bool Check(IntVec3 center, Map map, bool secondCheck = false)
        {
            var room = RegionAndRoomQuery.RoomAtOrAdjacent(center, map);
            if(room != null)
            {
                return success == Success.Normal ? true : false;
            }

            return success == Success.Normal ? false : true;
        }
    }
}
