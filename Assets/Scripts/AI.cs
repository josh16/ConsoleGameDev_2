using UnityEngine;
using System.Collections;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
	Animator anim;

	/*NavMeshAgent agent;
    public Transform target;
    public int moveSpeed;
    public int rotationSpeed;
     Rigidbody rb;

    //Zach's Script 

	void Start()
    {
        target = GameObject.Find("Player").transform;
		agent = GetComponent<NavMeshAgent> ();
    }

    void Update()
    {
        if (target != null)
        {
            Vector3 dir = target.position - transform.position;
            // Only needed if objects don't share 'z' value.
            dir.z = 0.0f;
            if (dir != Vector3.zero)
                transform.rotation = Quaternion.Slerp(transform.rotation,
                    Quaternion.FromToRotation(Vector3.right, dir),
                    rotationSpeed * Time.deltaTime);

            //Move Towards Target
            transform.position += (target.position - transform.position).normalized
                * moveSpeed * Time.deltaTime;
        }
        //rb.velocity = Vector3.zero;
    }*/
	NavMeshAgent agent;
	public Transform target;

	void Start(){
		
		anim = GetComponent<Animator> ();
		agent = GetComponent<NavMeshAgent> ();
		//GameObject Target = GameObject.FindGameObjectWithTag("Player");
		//target = Target.transform;
	}

	void Update()
	{
		GameObject Target = GameObject.FindGameObjectWithTag("Player");
		anim.SetBool ("isRun", true);

		target = Target.transform;


		if (target != null) {
			
			agent.SetDestination (target.position);

		}


	}


}