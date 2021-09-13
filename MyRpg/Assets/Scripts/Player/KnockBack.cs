using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class KnockBack : MonoBehaviour
{
    [SerializeField] private float knockTime;
    [SerializeField] private float thrust;
    [SerializeField] private string otherTag;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag(otherTag) && other.isTrigger)
        {

            Rigidbody2D hit = other.GetComponentInParent<Rigidbody2D>();
            if (hit != null)
            {
                Vector3 difference = hit.transform.position - transform.position;
                difference = difference.normalized * thrust;
                hit.DOMove(hit.transform.position + difference, knockTime);
                //hit.AddForce(difference, ForceMode2D.Impulse);
                if (other.gameObject.CompareTag("Enemy") && other.isTrigger)
                {
                    hit.GetComponent<Enemy>().currentState = EnemyState.stagger;
                    other.GetComponent<Enemy>().Knock(hit, knockTime);
                }
                if (other.GetComponentInParent<PlayerMovement>().currentState != PlayerState.stagger)
                {
                    hit.GetComponent<PlayerMovement>().currentState = PlayerState.stagger;
                    other.GetComponentInParent<PlayerMovement>().Knock(knockTime);
                }
            }
        }
        /*if (other.gameObject.CompareTag("Breakable") && this.gameObject.CompareTag("PlayerAttackHitBox"))
        {
            other.GetComponent<Pot>().brakePot();
        }*/
    }

    /*private IEnumerator knockCo(Rigidbody2D enemy)
    {
        if(enemy != null)
        {
            yield return new WaitForSeconds(knockTime);
            enemy.velocity = Vector2.zero;
            if (enemy.gameObject.CompareTag("Enemy"))
            {
                enemy.GetComponent<Enemy>().currentState = EnemyState.idle;
            }
        }
    }*/
}
