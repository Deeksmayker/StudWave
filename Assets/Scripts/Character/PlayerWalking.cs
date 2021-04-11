using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerWalking : MonoBehaviour
{
    public LayerMask ClickableLayers;

    private NavMeshAgent agent;
    [SerializeField] private float speed;

    [SerializeField] private new Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            Ray ray = camera.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 1000, ClickableLayers))
            {
                agent.SetDestination(hitInfo.point);
            }
        }
    }
}
