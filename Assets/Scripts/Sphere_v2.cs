using UnityEngine;
using Random = UnityEngine.Random;

public class Sphere_v2 : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject cubeObjectPrefab;

    private GameObject cubeGameObject;
    private Transform _cubeTransform;

    private bool _active;

    [SerializeField]
    private Vector2 pauseTimeRange;

    private float _pauseTime;
    private float _pauseTimer;

    //================================================================================================================//

    // Start is called before the first frame update
    private void Start()
    {
        //_cubeTransform = cubeObject.transform;
        _pauseTime = Random.Range(pauseTimeRange.x, pauseTimeRange.y);
        
        if (Random.value > 0.5f)
        {
            ToggleAttachedObject();
        }
    }

    // Update is called once per frame
    private void Update()
    {
        if (_active && cubeGameObject == null)
            _active = false;
        
        if (_pauseTimer >= _pauseTime)
        {
            ToggleAttachedObject();
            _pauseTime = Random.Range(pauseTimeRange.x, pauseTimeRange.y);
            _pauseTimer = 0f;
        }
        else
            _pauseTimer += Time.deltaTime;

        animator.Update(Time.deltaTime);
    }

    private void ToggleAttachedObject()
    {
        if (_active == false)
        {
            _active = true;
            cubeGameObject = Instantiate(cubeObjectPrefab, transform, false);
            cubeGameObject.GetComponent<Animation>().Play();
            _cubeTransform = cubeGameObject.transform;
        }
        else
        {
            Destroy(cubeGameObject);
            _active = false;
        }

    }
    
    //================================================================================================================//

    private void OnAnimatorIK()
    {
        //Debug.Log("Testing");

        if (_active == false)
            return;

        if (_active && cubeGameObject == null)
        {
            _active = false;
            ToggleAttachedObject();
        }
        
        animator.SetIKPositionWeight(AvatarIKGoal.LeftHand,1);
        animator.SetIKRotationWeight(AvatarIKGoal.LeftHand,1);  
        animator.SetIKPosition(AvatarIKGoal.LeftHand,_cubeTransform.position);
        animator.SetIKRotation(AvatarIKGoal.LeftHand,_cubeTransform.rotation);
    }
    //================================================================================================================//

}
