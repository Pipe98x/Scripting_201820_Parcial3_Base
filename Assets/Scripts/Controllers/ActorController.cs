using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Collider))]
public abstract class ActorController : MonoBehaviour
{
    public NavMeshAgent agent;

    [SerializeField]
    protected Color baseColor = Color.blue;

    protected Color taggedColor = Color.red;

    protected MeshRenderer renderer;

    public delegate void OnActorTagged(bool val);

    public OnActorTagged onActorTagged;

    public bool IsTagged { get; protected set; }

    [SerializeField]
    private GameController controller;
    public int puntuacion;
    public bool canMove = true;

    // Use this for initialization
    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        renderer = GetComponent<MeshRenderer>();
        controller = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<GameController>();
        SetTagged(false);
        onActorTagged += SetTagged;
    }

    protected abstract Vector3 GetTargetLocation();

    protected void MoveActor()
    {
        agent.SetDestination(GetTargetLocation());
    }

    protected void OnCollisionEnter(Collision collision)
    {
        ActorController otherActor = collision.gameObject.GetComponent<ActorController>();


        if (otherActor != null && IsTagged && otherActor.gameObject != controller.lastTaggedplayer)
        {
            controller.GetLastTaggedPlayer(gameObject);
            otherActor.IsTagged = true;
            otherActor.puntuacion += 1;
            IsTagged = false;
            otherActor.onActorTagged(true);
            onActorTagged(false);
        }
    }

    protected virtual void OnDestroy()
    {
        agent = null;
        renderer = null;
        onActorTagged -= SetTagged;
    }

    private void SetTagged(bool val)
    {
        IsTagged = val;

        if (renderer)
        {
            renderer.material.color = val ? taggedColor : baseColor;
        }
    }
}