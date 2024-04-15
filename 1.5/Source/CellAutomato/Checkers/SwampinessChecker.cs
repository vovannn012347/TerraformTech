using System.Collections.Generic;
using Verse;

namespace CellAutomato
{
    public class SwampinessChecker : CheckerTreeNode
    {
        private IntRange valueRange;

        private float swampinessMult = 0f;
        private float rainfallMult = 0f;

        private List<CheckerValueModifier> valueModifiers;
        
        public float CheckResult(IntVec3 center, Map map)
        {
            float value = map.TileInfo.rainfall * (rainfallMult + map.TileInfo.swampiness * swampinessMult);

            if(valueModifiers != null)
                foreach (var valueModifier in valueModifiers)
                {
                    value = valueModifier.Modify(center, map, value);

                }

            return value;
        }

        public override bool Check(IntVec3 center, Map map, bool secondCheck = false)
        {
            //Log.Message("SwampinessChecker");
            float value = CheckResult(center, map);

            if (valueRange.min < value && value < valueRange.max)
                return success == Success.Normal ? true : false;

            return success == Success.Normal ? false : true;
        }
    }
}
