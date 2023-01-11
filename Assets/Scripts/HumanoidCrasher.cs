using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class HumanoidCrasher : MonoBehaviour
{
    [SerializeField]
    private RandomChild prefab;
    private Animator m_Animator;

    private RandomChild attachedRandomChild;

    private bool m_AttachedToBone;

    private float m_parentTimer;
    private float m_parentTime;
    
    private float m_deleteTimer;
    private float m_deleteTime;

    private HumanBodyBones[] bones;
    // Start is called before the first frame update
    private void Start()
    {
        m_Animator = GetComponent<Animator>();
        bones = (HumanBodyBones[]) System.Enum.GetValues(typeof(HumanBodyBones));
        attachedRandomChild = Instantiate(prefab);
        
        
        m_parentTime = Random.Range(0, 2f);
        m_deleteTime = Random.Range(0, 20f);
    }

    private void OnAnimatorIK()
    {
        //----------------------------------------------------------//

        if (m_deleteTimer < m_deleteTime)
        {
            m_deleteTimer += Time.deltaTime;
        }
        else
        {
            GameObject randomElement;
            do
            {
                var randoms = FindObjectsOfType<RandomChild>();
                if(randoms.Length == 0)
                    break;
                
                var index = Random.Range(0, randoms.Length);
                randomElement = randoms[index].gameObject;
                
                Destroy(randomElement);
            } while (randomElement == null);

            m_deleteTime = Random.Range(0, 20f);
            m_deleteTimer = 0f;
        }
        //----------------------------------------------------------//

        if (m_parentTimer < m_parentTime)
        {
            m_parentTimer += Time.deltaTime;
            
            return;
        }

        //----------------------------------------------------------//

        if (attachedRandomChild == null)
        {
            attachedRandomChild = Instantiate(prefab);
        }
        
        //----------------------------------------------------------//

        if (m_AttachedToBone)
        {
            attachedRandomChild.UnParent();
            m_AttachedToBone = false;
        }
        else
        {

            var random = bones[Random.Range(0, (int)HumanBodyBones.LastBone)];
            var boneTransform = m_Animator.GetBoneTransform(random);
            
            attachedRandomChild.SetAttachment(boneTransform);
            m_AttachedToBone = true;
        }

        m_parentTime = Random.Range(0, 2f);
        m_parentTimer = 0f;
    }
}
