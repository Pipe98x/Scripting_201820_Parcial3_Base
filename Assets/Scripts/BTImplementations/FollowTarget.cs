/// <summary>
/// Task that instructs ControlledAI to follow its designated 'target'
/// </summary>
using UnityEngine;
public class FollowTarget : Task
{
    [SerializeField]
    private ActorController mine;
    public GetNearestTarget target;

    public override bool Execute()
    {
        mine.agent.SetDestination(target.target.transform.position);
        return true;
    }
}