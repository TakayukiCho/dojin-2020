using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Actable: MonoBehaviour
{

    protected abstract Phase waitPhase { get; }
    protected abstract Phase actPhase { get; }
    protected abstract Phase nextPhase { get; }

    // Start is called before the first frame update
    protected float moveTime = 0.1f;

    protected BoxCollider2D boxCollider;

    protected LayerMask collidablesLayer;

    protected Rigidbody2D rb2D;

    protected float inverseMoveTime {
        get {
            return 1f / moveTime;
        }
    }

    protected virtual void Start()
    {
        collidablesLayer = LayerMask.GetMask("Collidables");
        rb2D = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D> ();
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
        GameManager.instance.phase = nextPhase;
	}

    protected abstract Action Decide();

    protected abstract void Act(Action action);

    protected bool CanMove(Direction direction) {
        var current = transform.position;
        Vector2 end = current + direction.GetVector3();
        boxCollider.enabled = false;
        var hit = Physics2D.Linecast (current, end, collidablesLayer);
        boxCollider.enabled = true;
        return hit.transform == null;
    }


    protected void Move(Direction direction) {
        var current = transform.position;
        Vector2 end = current + direction.GetVector3();
        StartCoroutine (SmoothMovement(end));
    }





}
