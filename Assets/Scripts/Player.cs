using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveTime = 0.1f;

    private BoxCollider2D boxCollider;

    public LayerMask collidablesLayer;

    private float inverseMoveTime {
        get {
            return 1f / moveTime;
        }
    }

    private Rigidbody2D rb2D;
    // Start is called before the first frame update
    void Start()
    {
        collidablesLayer = LayerMask.GetMask("Collidables");
        rb2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D> ();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.instance.playerMoving)
            return;
        var direction = InputManager.getDirection();
        if(direction == Direction.None)
            return;
        Move(direction);
    }
    protected IEnumerator SmoothMovement (Vector3 end)
	{
		float sqrRemainingDistance = (transform.position - end).sqrMagnitude;

		while (sqrRemainingDistance > float.Epsilon) {
			Vector3 newPosition = Vector3.MoveTowards (rb2D.position, end, inverseMoveTime * Time.deltaTime);
			rb2D.MovePosition(newPosition);
			sqrRemainingDistance = (transform.position - end).sqrMagnitude;
			yield return null;
		}
        GameManager.instance.playerMoving = false;
	}

    private void Move(Direction direction) {
        var current = transform.position;
        Vector2 end = current + direction.GetVector3();

        boxCollider.enabled = false;
        var hit = Physics2D.Linecast (current, end, collidablesLayer);
        boxCollider.enabled = true;
        if (hit.transform != null) {
            GameManager.instance.playerMoving = false;
			return;
        }

        GameManager.instance.playerMoving = true;
        StartCoroutine (SmoothMovement (end));
    }
}
