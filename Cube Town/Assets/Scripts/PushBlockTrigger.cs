using UnityEngine;
using System.Collections;

public class PushBlockTrigger : MonoBehaviour {
    public GameObject m_Block;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == m_Block)
        {
            m_Block.transform.position = new Vector3(transform.position.x, 0, transform.position.z);
            m_Block.GetComponent<PushBlock>().m_isInPosition = true;
        }
    }
}
