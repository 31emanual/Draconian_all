﻿using UnityEngine;
using System.Collections;
using UnityStandardAssets._2D;

public class PlayerAttack : MonoBehaviour 
{
	//private bool chargingDash;
	//private bool dashing;
	public float chargeStart = 100f;
	public float chargeCounter;
	public Vector2 mousePos;
	private Rigidbody2D m_Rigidbody2D;
	private Vector2 dashVector;
	public float dashForce = 100f;
    //public float vectorSaveTime = .4f;
    public float dashDuration;
    public float dashStop = 1f;
    public float upTimer;
    private PlatformerCharacter2D character;




    // Use this for initialization
    void Start () 
	{
        character = (PlatformerCharacter2D)GameObject.Find("CharacterRobotBoy").GetComponent(typeof(PlatformerCharacter2D));
        Debug.Log(character.AirControl);

        m_Rigidbody2D = GetComponent<Rigidbody2D>();
		//chargingDash = false;
		//dashing = false;
		chargeCounter = 0f;
        dashDuration = dashStop;
        upTimer = 0f;
    }
	
	// Update is called once per frame
	void Update () 
	{
	 
	}
	private void FixedUpdate()
	{
        dashDuration += Time.deltaTime;

        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		Debug.DrawLine (transform.position, mousePos);
		Debug.Log (chargeCounter);

        Debug.Log(upTimer);

        if (Input.GetButton ("Fire1")) 
		{
		
			chargeCounter++;

		
			//if (chargeCounter >= chargeStart)
				//dashing = true;
				//StartCoroutine(DashChargeRoutine());
			 
		}


		if (Input.GetButtonUp ("Fire1")) 
		{				
			if (chargeCounter >= chargeStart)
			{
                dashDuration = 0f;
                // dashDuration += (dashDuration * Time.deltaTime);
                dashVector = new Vector2(mousePos.x - transform.position.x, mousePos.y - transform.position.y );
				m_Rigidbody2D.AddForce(dashVector *dashForce, ForceMode2D.Impulse);
                //dashing = true;
                //StartCoroutine( DashRoutine());
                //dashDuration = 0f;
                upTimer += (upTimer * Time.deltaTime);

               

            }
           
            chargeCounter = 0f;			
				
			   
		}
        if (dashDuration < dashStop)
            character.AirControl = false;
        else
            character.AirControl = true;




    }

    /*IEnumerator DashRoutine()
	{
        if (dashDuration < dashStop)
            character.AirControl = false;
        else
            character.AirControl = true;

        yield return null;


    }*/
}
