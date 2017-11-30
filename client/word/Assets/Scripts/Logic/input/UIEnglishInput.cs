using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEnglishInput : MonoBehaviour {
    [SerializeField]
    GameObject m_dragObject;

    [SerializeField]
    BoxCollider m_box;

	// Use this for initialization
	void Start () 
    {
        UIEventListener.Get(m_dragObject).onDrag = VectorDelegate;

    }

    void VectorDelegate(GameObject go, Vector2 delta)
    {
        Vector2 v2 =UICamera.currentTouch.pos;
        Vector3 v3 = new Vector3(v2.x, v2.y, m_box.transform.localPosition.z);

        Vector3 pos = UICamera.mainCamera.ScreenToWorldPoint(Input.mousePosition);
        Bounds bounds = m_box.bounds;
        if (bounds.Contains(pos))
        {
            Debug.Log("1");
        }
        else
        {
            Debug.Log(string.Format("bounds:", bounds.center));
            Debug.Log(string.Format("pos,x:{0},y:{1},z:{2}", pos.x, pos.y, pos.z));
        }
    }


    // Update is called once per frame
    void Update () {
	
	}
}
