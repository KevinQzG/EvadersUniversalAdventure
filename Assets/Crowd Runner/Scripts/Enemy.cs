using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    enum State { Idle, Running }

    [Header("Settings")]
    [SerializeField] private float searchRadius;
    [SerializeField] private float moveSpeed;
    private State state;
    private Transform targetRunner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ManageState();
    }

    private void ManageState()
    {
        switch (state)
        {
            case State.Idle:
                SearchForTarget();
                break;

            case State.Running:
                RunTowardsTarget();
                break;
        }
    }

    private void SearchForTarget()
    {
        Collider[] detectedColliders = Physics.OverlapSphere(transform.position, searchRadius);
        for (int i = 0; i < detectedColliders.Length; i++)
        {
            if (detectedColliders[i].TryGetComponent(out Runner runner))
            {
                if (runner.IsTarget())
                    continue;
                
                runner.SetTarget();
                targetRunner = runner.transform;

                StartRunningTowardsTarget();
            }
        }
    }

    private void StartRunningTowardsTarget()
    {
        state = State.Running;
        GetComponent<Animator>().Play("Run");
    }

    private void RunTowardsTarget()
    {
        if (targetRunner == null)
            return;

        transform.position = Vector3.MoveTowards(transform.position, targetRunner.position,
            Time.deltaTime * moveSpeed);
        
        if(Vector3.Distance(transform.position, targetRunner.position) < .1f)
        {
            Destroy(targetRunner.gameObject);
            Destroy(gameObject);
        }
    }
}
