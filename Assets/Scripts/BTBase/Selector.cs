public class Selector : Composite
{
    protected override bool MustAllChildrenSucceed
    {
        get
        {
            return false;
        }
    }

    public override bool Execute()
    {
        bool result = false;
        int childCount = 0;

        if (CheckCondition())
        {
            foreach (Node node in children)
            {
                result = result || node.Execute();

                childCount += 1;

                if (ShouldBreak(result))
                {
                    break;
                }
            }
        }

        return result;
    }

    protected override bool ShouldBreak(bool result)
    {
        return result;
    }

    protected virtual bool CheckCondition()
    {
        return true;
    }
}