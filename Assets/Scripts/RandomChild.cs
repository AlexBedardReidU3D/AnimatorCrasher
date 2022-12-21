using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomChild : RandomElement
{
    private Transform m_Attached;
    
    // Start is called before the first frame update
    public void SetAttachment(in Transform attachTransform)
    {
        m_Attached = attachTransform;
        transform.SetParent(m_Attached, false);
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (m_Attached == null)
            return;
        
        transform.position = m_Attached.TransformPoint(Random.Range(-10, 10) * Vector3.one);
    }
}
