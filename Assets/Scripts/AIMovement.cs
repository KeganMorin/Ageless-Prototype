using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using TMPro;

public class AIMovement : MonoBehaviour
{
    [SerializeField] private List<Transform> movePositions = new List<Transform>();
    private NavMeshAgent m_Agent;
    private Transform CurrentDestination;
    public float runtimer;
    // Start is called before the first frame update
    void Start()
    {
        m_Agent = GetComponent<NavMeshAgent>();
        CurrentDestination = RandomDestination();

    }

    // Update is called once per frame
    void Update()
    {
        runtimer += Time.deltaTime;
        Debug.Log(runtimer);
        float dist = Vector3.Distance(transform.position, CurrentDestination.position);
        if (runtimer >= 15)
        {
            CurrentDestination = RandomDestination();
            m_Agent.destination = CurrentDestination.position;
        }
        GameObject.Find("Timer").GetComponent<TMP_Text>().text = "" + runtimer;


    }

    private Transform RandomDestination()
    {
        if(movePositions.Count > 0)
        {
            int rd = Random.Range(0, movePositions.Count);
            return movePositions[rd];
        }
        return null;
    }
}
