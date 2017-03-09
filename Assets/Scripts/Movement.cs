using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

//Allowing networking
using UnityEngine.Networking;

public class Movement : NetworkBehaviour 
{
	public float rotate_speed = 85;
	public float speed = 10;
	Rigidbody rb;
	public float rotationSpeed = 10;

	//AudioFiles
	public AudioClip Shoot;
	public AudioClip hit;
	//public AudioClip BossHit;

	//Camera Reference
	public Camera cam;


	//bulletPrefab Variables
	public GameObject bulletPrefab;
	public Transform bulletSpawn;
	public float delayTime = 1.0f;
	private float counter = 0;
	public float bulletSpeed;

	//Grenade Variables
	public GameObject grenadePrefab;
	public Transform grenadeSpawn;
	public float grenadeSpeed;
	private float GrenadeCounter = 1.0f;
	public float delayGrenadeTime = 5.0f;
	public float numOfGrenades;
    public float ROF = 0.1f;


	//Josh's Script

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();


		//
		if (isLocalPlayer) 
		{

			return;
		}

		cam.enabled = false; 

	
	}
	
    // Update is called once per frame
	void Update () 
	{
		

		//check for isLocalPlayer in the Update function, so that only the local player processes input.
		if (!isLocalPlayer)
		{
			return;


		}
			
		if (Input.GetKeyDown (KeyCode.Space)) {
            InvokeRepeating("CmdKeyboardInput", 0.001f, ROF);
		}
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CancelInvoke("CmdKeyboardInput");
        }


        if (Input.GetButtonDown ("PS4_R1")) {

			CmdGun ();
		}



		if (Input.GetButtonDown ("PS4_L1")) {

			CmdGrenade ();
		}

		//if(isLocalPlayer)
			CmdgameController();


		float hAxis = Input.GetAxis ("Horizontal");
		float vAxis = Input.GetAxis ("Vertical");	


		// Controller Analog sticks Code
		/*

		float rStickX = Input.GetAxis("PS4_RightStickX");


		Vector3 movement = transform.TransformDirection (new Vector3 (hAxis, 0, vAxis) * speed * Time.deltaTime);

		rb.MovePosition (transform.position + movement);

		Quaternion rotation = Quaternion.Euler (new Vector3 (0, rStickX, 0) * rotate_speed * Time.deltaTime); 

		transform.Rotate (new Vector3 (0, rStickX, 0), rotate_speed * Time.deltaTime);

	
	*/
	
	
	}

	[Command]
	void CmdgameController()
	{

		if (isLocalPlayer) 
		{

			//Movement Code
			float hAxis = Input.GetAxis ("Horizontal");
			float vAxis = Input.GetAxis ("Vertical");

			float rStickX = Input.GetAxis("PS4_RightStickX");


			Vector3 movement = transform.TransformDirection (new Vector3 (hAxis, 0, vAxis) * speed * Time.deltaTime);

			rb.MovePosition (transform.position + movement);

			Quaternion rotation = Quaternion.Euler (new Vector3 (0, rStickX, 0) * rotate_speed * Time.deltaTime); 

			transform.Rotate (new Vector3 (0, rStickX, 0), rotate_speed * Time.deltaTime);

		}


	}
		

	//On Start the material will be set to blue to identify which gameobject belongs to the player 
	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer>().material.color = Color.red;
	}
	
	//Firing Weapon Code
	[Command] // Command here indicates that the following function will be called by the client,but will be run on the server.
    void CmdGun() //When making a networked command, the function name must being with "Cmd"
    {
        
        //if (Input.GetButtonDown("PS4_R1"))
        //{
			
			var bullet = (GameObject)Instantiate(
				bulletPrefab,
				bulletSpawn.position,
				bulletSpawn.rotation);


			bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

			NetworkServer.Spawn(bullet);
	
			Destroy(bulletPrefab,2.0f);

			AudioSource.PlayClipAtPoint(Shoot, transform.position);
            counter = 0;
       // }
        counter += Time.deltaTime;

      }


	
	[Command]
    void CmdGrenade()
    {
        //Grenade code
        //if (Input.GetButtonDown("PS4_L1"))
        //{
			//Rigidbody instantiatedgrenade = Instantiate(grenade, grenadeSpawn, transform.rotation) as Rigidbody;
            //instantiatedgrenade.velocity = transform.TransformDirection(new Vector3(0, 0, grenadeSpeed));

			var grenade = (GameObject)Instantiate(
				grenadePrefab,
				grenadeSpawn.position,
				grenadeSpawn.rotation);

			grenade.GetComponent<Rigidbody>().velocity = grenade.transform.forward * grenadeSpeed;

			NetworkServer.Spawn(grenade);

			Destroy(grenadePrefab,2.0f);

			numOfGrenades--;

            GrenadeCounter = 0;

            Debug.Log("Throw grenade!!");
       // }
        delayGrenadeTime += Time.deltaTime;
    }
    
	


	//Trigger Codes

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Enemy")) 
		{
			//Scream.PlayOneShot(sound, 0.8f);
			AudioSource.PlayClipAtPoint(hit,transform.position);
			//Destroy (this.gameObject);
			Debug.Log("Zambie hit!!");
		}
	
	
	}

	//Dodge Mechanic input



    /*
    void Fire()

    {
		//Shooting Code (R2 for PS4)
		float triggerAxis = Input.GetAxis("PS4_RTrigger");

		if (triggerAxis != 0 && counter > delayTime) {
			Instantiate (bulletPrefab, spawbulletSpawnition, transform.rotation);
			AudioSource.PlayClipAtPoint(Shoot,transform.position);
			counter = 0;

		} 

		else 
		{
			triggerAxis = 0;
		}
		counter += Time.deltaTime;


    }

	

    void Grenade ()
	{
		float triggerAxis = Input.GetAxis("PS4_LTrigger");

		if (triggerAxis != 0 && counter > delayGrenadeTime) 
		{
			Rigidbody instantiatedgrenade = Instantiate (grenade, grenadeSpawbulletSpawnition, transform.rotation) as Rigidbody;
			instantiatedgrenade.velocity = transform.TransformDirection (new Vector3 (0, 0, -grenadeSpeed));


			numOfGrenades--;

			GrenadeCounter = 0;

            Debug.Log ("Throw grenade!!");


		}

        GrenadeCounter += Time.deltaTime;
	}


    */




	public GameObject hitObject;


	//Pick up GameObjects
	void PickUpObject()
	{

		/*
		RaycastHit hit;

		if (Input.GetKey (KeyCode.P)) {



			if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition),hit))
				{
				hitObject = hit.collider.gameObject;
				hitObject.transform.parent = gameObject.transform;

				}

			//Pick up the game object here
		}

		*/
	}






	[Command]
	void CmdKeyboardInput()
	{
		
		// Create the Bullet from the Bullet Prefab
			var bullet = (GameObject)Instantiate(
				bulletPrefab,
				bulletSpawn.position,
				bulletSpawn.rotation);

		// Add velocity to the bullet
		bullet.GetComponent<Rigidbody>().velocity = bullet.transform.forward * bulletSpeed;

			NetworkServer.Spawn(bullet);

			// Destroy the bullet after 2 seconds
			Destroy(bullet, 2.0f);        

			//Spawn the bulletPrefab on the Clients
			//Networking the bulletPrefab :)

			AudioSource.PlayClipAtPoint(Shoot,transform.position);
			//counter = 0;


	}



}
