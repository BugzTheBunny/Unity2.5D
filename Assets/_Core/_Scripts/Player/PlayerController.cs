using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    [Header(" Settings ")]
    [SerializeField] private int moveSpeed;
    [SerializeField] private Animator anim;
    [SerializeField] private SpriteRenderer playerSprite;

    [SerializeField] private LayerMask grassLayer;
    [SerializeField] private int stepsInGrass;

    [Header(" Components ")]
    private PlayerControls playerControls;
    private Rigidbody rb;
    private Vector3 moveVector;
    private bool movingInGrass;
    private float stepTimer;

    private const string IS_WALK_PARAM = "IsMoving";
    private const float timePerStep = 0.5f;

    private void Awake()
    {
        playerControls = new PlayerControls();    
    }

    private void OnEnable()
    {
        playerControls.Enable();
    } 

    private void OnDisable()
    {
        playerControls.Disable();
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = playerControls.Player.Move.ReadValue<Vector2>().x;
        float z = playerControls.Player.Move.ReadValue<Vector2>().y;
        
        moveVector = new Vector3(x, 0, z).normalized;

        anim.SetBool(IS_WALK_PARAM,moveVector != Vector3.zero);

        if (x != 0 && x<0)
        {
            playerSprite.flipX = true;
        }

        if (x != 0 && x > 0)
        {
            playerSprite.flipX = false;
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(transform.position + moveVector * moveSpeed * Time.deltaTime);

        Collider[] colliders = Physics.OverlapSphere(transform.position, 1, grassLayer);
        movingInGrass = colliders.Length!=0 && moveVector != Vector3.zero;

        if (movingInGrass)
        {
            stepTimer += Time.fixedDeltaTime;
            if (stepTimer > timePerStep)
            {
                stepsInGrass++;
                stepTimer = 0;
            }
        }
    }
}
