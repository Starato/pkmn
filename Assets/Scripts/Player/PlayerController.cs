using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    public float moveSpeed;
    public LayerMask solidObjectLayer;
    public LayerMask barrierLayer;
    public LayerMask grassLayer;
    private bool isMoving;
    private Vector2 input;
    private Animator animator;
    
    private void Awake()
    {
        animator = GetComponent<Animator>();      
    }

    // Update is called once per frame
    void Update()
    {
        if(!isMoving)
        {
            input.x = Input.GetAxisRaw("Horizontal");
            input.y = Input.GetAxisRaw("Vertical");

            if(input.x != 0){input.y = 0;}

            if(input != Vector2.zero)
            {
                animator.SetFloat("moveX", input.x);
                animator.SetFloat("moveY", input.y);

                var targetPos = transform.position;
                targetPos.x += input.x;
                targetPos.y += input.y;

                if(isWalkable(targetPos) == true)
                {
                    StartCoroutine(Move(targetPos));
                }
            }
        }
        animator.SetBool("isMoving", isMoving);
    }

    IEnumerator Move(Vector3 targetPos)
    {
        isMoving = true;
        while((targetPos - transform.position).sqrMagnitude > Mathf.Epsilon)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
            yield return null;
        }

        transform.position = targetPos;
        isMoving = false;
        checkForEncounters();
    }

    private bool isWalkable(Vector3 targetPos)
    {
        if(Physics2D.OverlapCircle(targetPos, 0.3f, solidObjectLayer) != null)
        {
            return false;
        }
        if(Physics2D.OverlapCircle(targetPos, 0.3f, barrierLayer) != null)
        {
            if(Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow)){return true;}
            return false;
        }
        return true;
    }

    private void checkForEncounters()
    {
        if(Physics2D.OverlapCircle(transform.position, 0.3f, grassLayer) != null)
        {
            if(Random.Range(1, 101) <= 10)
            {
                Debug.Log("encountered a wild pokemon");
            }
        }
    }





}
