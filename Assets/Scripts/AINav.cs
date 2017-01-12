using UnityEngine;
using System.Collections;

public class AINav : MonoBehaviour 
{
	public Transform player;

	void start ()
	{
		UnityEngine.AI.NavMeshAgent agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
		agent.destination = player.position;
	}
}
