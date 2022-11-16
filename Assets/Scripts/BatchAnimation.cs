using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BatchAnimation : MonoBehaviour
{
    [SerializeField]
    private GameObject spherePrefab;
    
    [SerializeField, Min(1)]
    private int widthCount;
    [SerializeField, Min(1)]
    private int heightCount;

    [SerializeField]
    private bool useRandomDelete = true;
    [SerializeField, Min(0f)]
    private float randomDeleteDelayMin;
    [SerializeField, Min(0f)]
    private float randomDeleteDelayMax;

    private float m_FixedUpdateTime, m_FixedUpdateTimer;
    private float m_UpdateTime, m_UpdateTimer;
    private float m_LateUpdateTime, m_LateUpdateTimer;

    //================================================================================================================//

    // Start is called before the first frame update
    private void Start()
    {
        SpawnElements();
        
        m_FixedUpdateTimer = Random.Range(randomDeleteDelayMin, randomDeleteDelayMax);
        m_UpdateTimer = Random.Range(randomDeleteDelayMin, randomDeleteDelayMax);
        m_LateUpdateTimer = Random.Range(randomDeleteDelayMin, randomDeleteDelayMax);
    }

    private void FixedUpdate()
    {
        if (useRandomDelete == false)
            return;

        if (m_FixedUpdateTime < m_FixedUpdateTimer)
        {
            m_FixedUpdateTime += Time.fixedDeltaTime;
            return;
        }

        m_FixedUpdateTimer = Random.Range(randomDeleteDelayMin, randomDeleteDelayMax);
        m_FixedUpdateTime = 0f;
        
        DeleteRandomElement();
    }

    private void Update()
    {
        if (useRandomDelete == false)
            return;
        
        if (m_UpdateTime < m_UpdateTimer)
        {
            m_UpdateTime += Time.fixedDeltaTime;
            return;
        }

        m_UpdateTimer = Random.Range(randomDeleteDelayMin, randomDeleteDelayMax);
        m_UpdateTime = 0f;
        
        DeleteRandomElement();
    }

    private void LateUpdate()
    {
        if (useRandomDelete == false)
            return;
        
        if (m_LateUpdateTime < m_LateUpdateTimer)
        {
            m_LateUpdateTime += Time.fixedDeltaTime;
            return;
        }

        m_LateUpdateTimer = Random.Range(randomDeleteDelayMin, randomDeleteDelayMax);
        m_LateUpdateTime = 0f;
        
        DeleteRandomElement();
    }


    private void SpawnElements()
    {
        var offset = new Vector3(widthCount * 1.2f, 0f, heightCount * 1.2f) / 2f;
        
        for (var y = 0; y < heightCount; y++)
        {
            for (var x = 0; x < widthCount; x++)
            {
                var position = new Vector3(x * 1.2f, 0f, y * 1.2f);
                var empty = new GameObject($"Pos_[{x}][{y}]").transform;
                empty.position = position - offset;
                
                Instantiate(spherePrefab, empty, false);
            }     
        }
        
    }
    
    //================================================================================================================//

    private static void DeleteRandomElement()
    {
        var options = FindObjectsOfType<RandomElement>();

        var randomIndex = Random.Range(0, options.Length);
        
        Destroy(options[randomIndex].gameObject);
    }
}
