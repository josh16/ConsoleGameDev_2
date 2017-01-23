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

	//AudioFiles
	public AudioClip Shoot;
	public AudioClip hit;
	//public AudioClip BossHit;

	//Bullet Variables
	public GameObject bullet;
	public Transform spawner;
	public float delayTime = 1.0f;
	private float counter = 0;


	//Grenade Variables
	public Transform grenadeSpawner;
	public Rigidbody grenade;
	public float grenadeSpeed;
	private float GrenadeCounter = 1.0f;
	public float delayGrenadeTime = 5.0f;
	public float numOfGrenades;



	//Josh's Script

	// Use this for initialization
	void Start () 
	{
		rb = GetComponent<Rigidbody> ();
	}
	
    // Update is called once per frame
	void Update () 
	{
		
		//check for isLocalPlayer in the Update function, so that only the local player processes input.
		if (!isLocalPlayer)
		{
			return;
		}

		//Firing Gun Function/ Keyboard and Controller input.
		CmdGun();
		CmdKeyboardInput ();


        
		CmdGrenade();
        //Fire ();
		//Grenade ();




	//Movement Code
		float hAxis = Input.GetAxis ("Horizontal");
		float vAxis = Input.GetAxis ("Vertical");
		 
		//The sticks
		float rStickX = Input.GetAxis("PS4_RightStickX");


		Vector3 movement = transform.TransformDirection (new Vector3 (hAxis, 0, vAxis) * speed * Time.deltaTime);


		rb.MovePosition (transform.position + movement);

		Quaternion rotation = Quaternion.Euler (new Vector3 (0, rStickX, 0) * rotate_speed * Time.deltaTime); 

		transform.Rotate (new Vector3 (0, rStickX, 0), rotate_speed * Time.deltaTime);
		//movement Code
	


	}

	//On Start the material will be set to blue to identify which gameobject belongs to the player 
	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer>().material.color = Color.blue;
	}


	[Command] // Command here indicates that the following function will be called by the client,but will be run on the server.
    void CmdGun()//When making a networked command, the function name must being with "Cmd"
    {
        //Gun Code
        if (Input.GetButtonDown("PS4_R1"))
        {
            Instantiate(bullet, spawner.position, transform.rotation);

			//Networking
			NetworkServer.Spawn(bullet);//Spawn the bullet on the Clients
			Destroy(bullet,2.0f);

			AudioSource.PlayClipAtPoint(Shoot, transform.position);
            counter = 0;
        }
        counter += Time.deltaTime;

      
    }

	[Command]
    void CmdGrenade()
    {
        //Grenade code
        if (Input.GetButtonDown("PS4_L1"))
        {
            Rigidbody instantiatedgrenade = Instantiate(grenade, grenadeSpawner.position, transform.rotation) as Rigidbody;
            instantiatedgrenade.velocity = transform.TransformDirection(new Vector3(0, 0, grenadeSpeed));

            numOfGrenades--;

            GrenadeCounter = 0;

            Debug.Log("Throw grenade!!");
        }
        delayGrenadeTime += Time.deltaTime;
    }
    

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Enemy")) 
		{
			//Scream.PlayOneShot(sound, 0.8f);
			AudioSource.PlayClipAtPoint(hit,transform.position);
			//Destroy (this.gameObject);
			Debug.Log("Zambie hit!!");
		}
	
		/*if (other.gameObject.CompareTag ("Boss")) 
		{
			
			AudioSource.PlayClipAtPoint(BossHit,transform.position);
			Debug.Log("Boss hit!!");
		}

		

		if (other.gameObject.CompareTag ("portal1")) 
		{
			SceneManager.LoadScene("Boss");
		}

		if(other.gameObject.CompareTag("portal2"))
		{
			SceneManager.LoadScene ("Scene");
		}

	*/
	
	}

	//Dodge Mechanic input



    /*
    void Fire()

    {
		//Shooting Code (R2 for PS4)
		float triggerAxis = Input.GetAxis("PS4_RTrigger");

		if (triggerAxis != 0 && counter > delayTime) {
			Instantiate (bullet, spawner.position, transform.rotation);
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
			Rigidbody instantiatedgrenade = Instantiate (grenade, grenadeSpawner.position, transform.rotation) as Rigidbody;
			instantiatedgrenade.velocity = transform.TransformDirection (new Vector3 (0, 0, -grenadeSpeed));


			numOfGrenades--;

			GrenadeCounter = 0;

            Debug.Log ("Throw grenade!!");


		}

        GrenadeCounter += Time.deltaTime;
	}


    */

	[Command]
	void CmdKeyboardInput()
	{
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			Instantiate (bullet, spawner.position, transform.rotation);
			//Spawn the bullet on the Clients
			//Networking the bullet :)
			NetworkServer.Spawn(bullet);
			Destroy (bullet, 2.0f);
			AudioSource.PlayClipAtPoint(Shoot,transform.position);
			counter = 0;


		}
		counter += Time.deltaTime;
	}



}
