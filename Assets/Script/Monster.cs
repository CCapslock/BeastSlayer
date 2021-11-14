using UnityEngine;
using UnityEngine.AI;

public class Monster : MonoBehaviour
{
    public GameObject Player;
    public float Radius = 15;
    public float Distance;
    NavMeshAgent NavMesh;

    void Start()
    {
        NavMesh = GetComponent<NavMeshAgent>();
        Distance = Vector3.Distance(Player.transform.position, transform.position);
    }

    void Update()
    {
        Distance = Vector3.Distance(Player.transform.position, transform.position);
        if (Distance > Radius)
            NavMesh.enabled = false;

        if(Distance < Radius)
        {
            NavMesh.enabled = true;
            NavMesh.SetDestination(Player.transform.position);
        }
        if(Distance < 2)
        {
            NavMesh.enabled = false;
            gameObject.GetComponent<Animator>().SetTrigger("Attake");
        }
    }
}
