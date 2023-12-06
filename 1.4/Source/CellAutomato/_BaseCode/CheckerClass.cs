using System.Collections.Generic;
using Verse;

namespace CellAutomato
{
    public enum CheckerType
    {
        And,
        Or
    }

    public abstract class CheckerClass
    {
        public string patchTag;
        public bool Check(int center, Map map, bool secondCheck = false)
        {
            return Check(map.cellIndices.IndexToCell(center), map);
        }

        public virtual bool Check(Verse.IntVec3 center, Map map, bool secondCheck = false)
        {
            return true;
        }
    }

    public class CheckerTreeNode : CheckerClass
    {
        public enum Success
        {
            Normal,
            Invert
        }
        
        public CheckerType operation;
        public List<CheckerTreeNode> subNodes;
        public Success success;
        
        public override bool Check(IntVec3 center, Map map, bool secondCheck = false)
        {
            if(subNodes != null)
            {
                if (operation == CheckerType.And)
                {
                    bool result = true;
                    foreach (var rule in subNodes)
                        if (result)
                        {
                            result &= rule.Check(center, map, secondCheck);
                        }
                        else return success == Success.Normal ? false : true;

                    return success == Success.Normal ? result : !result;
                }
                else
                if (operation == CheckerType.Or)
                {
                    bool result = false;
                    foreach (var rule in subNodes)
                    {
                        result |= rule.Check(center, map, secondCheck);
                        if (result) return success == Success.Normal ? true : false;
                    }

                    return success == Success.Normal ? false : true;
                }

                return success == Success.Normal ? false : true;
            }
            else
            {
                return success == Success.Normal ? true : false;
            }
        }
    }   
}
