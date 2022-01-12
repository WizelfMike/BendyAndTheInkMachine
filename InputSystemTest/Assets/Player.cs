using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
	public int JumpForce;
	public float Speed;
	public bool IsJumping;
	public bool Isgrounded;
	public PlayerController playerController;
	public Material ColorTurn;
	public Color Left;
	public Color Right;
	public GameObject Sphere;

	private Renderer SphereRender;
	private Rigidbody SphereRB;

	Vector2 moveDirection = Vector2.zero;
	
	void Awake()
	{
		SphereRender = Sphere.GetComponent<Renderer>();
		playerController = new PlayerController();
		Isgrounded = true;
		SphereRB = GetComponent<Rigidbody>();
	}

	void Update()
	{
		moveDirection = playerController.Player.Movement.ReadValue<Vector2>();
	}

	void FixedUpdate()
	{
		float moveX = moveDirection.x * Speed * Time.deltaTime;
		float moveY = moveDirection.y * Speed * Time.deltaTime;
		transform.Translate(moveX, 0, moveY);

		if (moveX > 0)
		{
			SphereRender.material.SetColor("_Color", Right);
		}
		if (moveX < 0)
		{
			SphereRender.material.SetColor("_Color", Left);
		}

	}

	/*	public void Movement(InputAction.CallbackContext ctx)
		{
			Vector2 input = ctx.ReadValue<Vector2>();
			SphereRB.velocity = new Vector3(input.x, 0, input.y * Speed * Time.deltaTime);
		}*/

	void OnEnable()
	{
		playerController.Player.Enable();
	}

	void OnDisable()
	{
		playerController.Player.Disable();
	}

	public void Jump()
	{
		if (Isgrounded)
		{
			SphereRB.AddForce(new Vector3(0, JumpForce, 0), ForceMode.Impulse);
			IsJumping = true;
			Isgrounded = false;
		}
		else
		{
			return;
		}
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.name == "Floor")
		{
			Isgrounded = true;
			IsJumping = false;
		}
	}
}
