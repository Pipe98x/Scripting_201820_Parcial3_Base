/// <summary>
/// Selector that succeeeds if ControlledAI is marked as 'tagged'
/// </summary>
using UnityEngine;
public class ActorIsTagged : Selector
{
    [SerializeField]
    private AIController controller;

    protected override bool CheckCondition()
    {
        if (controller.IsTagged)
        {
            return true;

        }
        else
        {
            return false;
        }
    }

    public override bool Execute()
    {
        bool result = CheckCondition();
        if (result)
        {
            foreach (Node node in children)
            {
                result = result && node.Execute();
                if (ShouldBreak(result))
                {
                    break;
                }
            }
        }

        return result;
    }
}