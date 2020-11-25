using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public float maxSpeed = 4.0f;
    public Transform waypoint;
    public float maxHealth = 100.0f;

    private NavMeshAgent _agent;
    private Animator _animator;
    private float dividedSpeed = 0.0f;
    private bool isDead = false;
    private bool isAttacking = false;
    private WaypointManager.Path _path;
    private int _currentWaypoint = 0;
    private float _currentHealth = 0.0f;
    private float deathClipLength;
    private float getHitClipLength;
    public GameObject dropPrefab;


    // Start is called before the first frame update
    void Start()
    {
        _currentHealth = maxHealth;
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        
        if(_agent != null)
        {
            _agent.SetDestination(waypoint.position);
            _agent.speed = maxSpeed;
        }
        dividedSpeed = 1 / maxSpeed;

        AnimationClip[] animations = _animator.runtimeAnimatorController.animationClips;
        if(animations == null || animations.Length <= 0)
        {
            Debug.Log("animations Error");
            return;
        }

        for(int i = 0; i<animations.Length; ++i)
        {
            if(animations[i].name == "Die")
            {
                deathClipLength = animations[i].length;
            }
            if(animations[i].name == "GetHit")
            {
                getHitClipLength = animations[i].length;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        UpdateAnimation();

        if(waypoint == null)
        {
            return;
        }
        float dist = Vector3.Distance(waypoint.position, transform.position);
        if(dist < 1.5f)
        {
            isAttacking = true;
        }
        else
        {
            isAttacking = false;
        }
        if (_agent.speed < maxSpeed)
        {
            _agent.speed = maxSpeed;
        }
        /*if(_path == null || _path.Waypoints == null || _path.Waypoints.Count <= _currentWaypoint)
        {
            return;
        }
        Transform destination = waypoint;        
        _agent.SetDestination(destination.position);
        if((transform.position - destination.position).sqrMagnitude < 3.0f * 3.0f)
        {
            _currentWaypoint++;
        }*/

        _agent.SetDestination(waypoint.position);

    }

    private void UpdateAnimation()
    {
        //_animator.SetFloat("EnemySpeed", _agent.velocity.magnitude * dividedSpeed);
        _animator.SetBool("isDead", isDead);
        _animator.SetBool("isAttacking", isAttacking);
    }

    public void Initialize(WaypointManager.Path path)
    {
        _path = path;
    }

    public float GetHealth()
    {
        return _currentHealth;
    }

    public void TakeDamage(float damage)
    {
        _currentHealth -= damage;
        if(isAttacking == false && isDead == false)
        {
            _animator.Play("GetHit");
        }
        if(_currentHealth <= 0.0f && isDead == false)
        {
            isDead = true;
            StartCoroutine("Kill");
        }
    }

    public IEnumerator Kill()
    {
        _agent.isStopped = true;
        Vector3 pos = transform.position;
        pos.y += 1;
        GameObject dropItem = Instantiate(dropPrefab, pos, Quaternion.identity);
        yield return new WaitForSeconds(deathClipLength);
        Destroy(gameObject,2f);
    }
}
