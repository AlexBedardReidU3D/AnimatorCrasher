using UnityEngine;
using Random = UnityEngine.Random;

public class Sphere : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private GameObject cubeObject;

    private Transform _cubeTransform;

    [SerializeField]
    private Vector2 pauseTimeRange;

    private float _pauseTime;
    private float _pauseTimer;

    //================================================================================================================//

    // Start is called before the first frame update
    private void Start()
    {
        _cubeTransform = cubeObject.transform;
        _pauseTime = Random.Range(pauseTimeRange.x, pauseTimeRange.y);
        cubeObject.SetActive(Random.value > 0.5f);
    }

    // Update is called once per frame
    private void Update()
    {

        if (_pauseTimer >= _pauseTime)
        {
            cubeObject.SetActive(!cubeObject.activeInHierarchy);
            _pauseTime = Random.Range(pauseTimeRange.x, pauseTimeRange.y);
            _pauseTimer = 0f;
        }
        else
            _pauseTimer += Time.deltaTime;
     
        animator.SetIKPosition(AvatarIKGoal.LeftHand, _cubeTransform.position);
    }
    
    //================================================================================================================//

    private void OnAnimatorIK(int layerIndex)
    {
        
    }
    //================================================================================================================//

}
