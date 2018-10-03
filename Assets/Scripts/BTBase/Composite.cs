using UnityEngine;

public abstract class Composite : Node
{
    [SerializeField]
    protected Node[] children;

    protected abstract bool MustAllChildrenSucceed { get; }

    public override bool Execute()
    {
        bool result = true;
        int childCount = 0;

        foreach (Node node in children)
        {
            result = result && node.Execute();

            if (ShouldBreak(result))
            {
                break;
            }
        }

        return result;
    }

    public override void SetControlledAI(AIController newControlledAI)
    {
        base.SetControlledAI(newControlledAI);

        foreach (Node child in children)
        {
            child.SetControlledAI(newControlledAI);
        }
    }

    protected abstract bool ShouldBreak(bool result);
}