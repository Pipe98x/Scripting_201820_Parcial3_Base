/// <summary>
/// Task that instructs ControlledAI to move away from 'tagged' player
/// </summary>
using UnityEngine;
public class FleeFromTagged : Task
{
    [SerializeField]
    private AIController mine;
    public override bool Execute()
    {
        mine.MoveAI();
        return true;
    }
}