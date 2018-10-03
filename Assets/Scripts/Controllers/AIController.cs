using UnityEngine;
using UnityEngine.AI;

public class AIController : ActorController
{
    [SerializeField]
    private float moveRadius = 50F;

    [SerializeField]
    private Root btRootNode;

    [SerializeField]
    private float rootTime;

    public void MoveAI()
    {
        MoveActor();
    }

    protected override void Start()
    {
        base.Start();
        AIMoveTest.Instance.onAIMoveIssued += MoveAI;

        if (btRootNode != null)
        {
            btRootNode.SetControlledAI(this);
            InvokeRepeating("ExecuteBT", 0.4F, rootTime);  
        }
           
     }

    private void ExecuteBT()
    {
        //print(string.Format("Executed root with result {0}", root.Execute()));
        if(canMove)
        btRootNode.Execute();
    }

    
    

    protected override void OnDestroy()
    {
        AIMoveTest.Instance.onAIMoveIssued -= MoveAI;
        base.OnDestroy();
    }

    protected override Vector3 GetTargetLocation()
    {
        Vector3 result = transform.position;

        Vector3 randomDirection = Random.insideUnitSphere * moveRadius;
        randomDirection += transform.position;

        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomDirection, out hit, moveRadius, 1))
        {
            result = hit.position;
        }

        return result;
    }
}