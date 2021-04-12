using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerWalking : MonoBehaviour
{
    public LayerMask ClickableLayer;

    private NavMeshAgent agent;

    [SerializeField] private new Camera camera;

    [SerializeField] GameObject interactPanel;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            Ray ray = camera.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 1000, ClickableLayer))
            {
                interactPanel.SetActive(true);
                agent.SetDestination(hitInfo.point);
            }
        }
    }
}
