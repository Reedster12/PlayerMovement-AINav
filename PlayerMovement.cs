using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    private Vector3 targetPosition;
    public LayerMask groundLayer;

    private NavMeshAgent agent;

    void Start()
    {
        targetPosition = transform.position;

        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
            {
                targetPosition = hit.point;
                targetPosition.y = transform.position.y;
            }

            agent.SetDestination(targetPosition);
        }
        else if (transform.position == targetPosition)
        {
            agent.SetDestination(transform.position);
        }
    }
}
