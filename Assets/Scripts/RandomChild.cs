using UnityEngine;

public class RandomChild : RandomElement
{
    private static bool _containerCreated;
    private static Transform parentContainerTransform;
    
    private Transform m_Attached;
    
    // Start is called before the first frame update
    public void SetAttachment(in Transform attachTransform)
    {
        m_Attached = attachTransform;
        
        transform.SetParent(m_Attached, false);
    }

    public void UnParent()
    {
        if (_containerCreated == false)
        {
            parentContainerTransform = new GameObject("Container").transform;
            parentContainerTransform.SetSiblingIndex(0);
            _containerCreated = true;
        }

        SetAttachment(parentContainerTransform);
    }

    // Update is called once per frame
    private void LateUpdate()
    {
        if (m_Attached == null)
            return;
        
        transform.position = m_Attached.TransformPoint(Random.Range(-10, 10) * Vector3.one);
    }
}
