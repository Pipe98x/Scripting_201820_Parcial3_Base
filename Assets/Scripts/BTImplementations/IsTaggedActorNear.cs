using UnityEngine;
/// <summary>
/// Selector that succeeds if 'tagged' player is within a 'acceptableDistance' radius.
/// </summary>
public class IsTaggedActorNear : Selector
{
    [SerializeField]
    private float acceptableDistance = 15F;
    [SerializeField]
    private GameController controller;

    public void Start()
    {
        controller = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>();
    }

    protected override bool CheckCondition()
    {
        for (int i = 0; i < controller.players.Length; i++)
        {
            if (controller.players[i].IsTagged)
            {
                if(Vector3.Distance(transform.position, controller.players[i].transform.position) < acceptableDistance)
                {
                    return true;
                }
            }
        }
        return false;
    }


}