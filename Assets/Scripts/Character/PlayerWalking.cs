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

    private Vector3 targetPoint = Vector3.zero;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        MovingLogic();
    }

    public void MovingLogic()
    {
        if (Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Stationary)
        {
            Ray ray = camera.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 1000, ClickableLayer))
            {
                interactPanel.SetActive(true);
                targetPoint = hitInfo.point;
            }
        }
    }

    public void ButtonInteraction(bool isButtonYes)
    {
        if (isButtonYes)
            agent.SetDestination(targetPoint);
        interactPanel.SetActive(false);
    }
}
