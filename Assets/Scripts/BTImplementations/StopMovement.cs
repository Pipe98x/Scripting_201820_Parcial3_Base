/// <summary>
/// Task that instructs ControlledAI to stop its current movement.
/// </summary>
using UnityEngine;
public class StopMovement : Task
{
    [SerializeField]
    private ActorController mine;

    public override bool Execute()
    {
        mine.agent.SetDestination(transform.position);
        return true;
    }
}