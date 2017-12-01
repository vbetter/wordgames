using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMain : UIScene
{
    [SerializeField]
    UIEnFontBox m_UIEnFontBoxClone;

    [SerializeField]
    GameObject m_BoxParent;

    List<UIEnFontBox> m_BoxList;

    List<int> m_operations = new List<int>();
    int m_operationsMax = 5;

    string m_correctAnswer = string.Empty;
    string m_myAnswer = string.Empty;

    int m_curOperationID = 0;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void UpdateUI()
    {
        CreateItems();

        base.UpdateUI();
    }

    void CreateItems()
    {
        List<string> list = EnFontMgr.Instance.GetData();

        if(list!=null && list.Count>0)
        StartCoroutine(Utils.CreateItems<UIEnFontBox>(list.Count, m_UIEnFontBoxClone, m_BoxList, m_BoxParent.transform));
    }

    void SetItems()
    {
        if(m_BoxList!=null && m_BoxList.Count>0)
        {
            for (int i = 0; i < m_BoxList.Count; i++)
            {
                UIEnFontBox item = m_BoxList[i];
            }
        }
    }


    void OnDragStart()
    {

    }

    void OnDragMove()
    {
        /*
        Ray ray = UICamera.currentCamera.ScreenPointToRay(UICamera.currentTouch.pos);


        if (true && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector3 inputPos = Input.GetTouch(0).position;

        }
        */

    }

    void OnDragEnd()
    {

    }

    void OnColliderBox(UIEnFontBox item)
    {
        if (EnableAddOperation(item))
        {
            AddOperation(item);
        }

        if (IsSuccess())
        {
            ClearOperation();
            return;
        }

        if (m_operations.Count > m_operationsMax)
        {
            ClearOperation();
        }
    }

    bool IsSuccess()
    {
        if(string.Equals(m_myAnswer,m_correctAnswer))
        {
            return true;
        }
        return false;
    }

    bool EnableAddOperation(UIEnFontBox item)
    {
        return true;
    }

    void AddOperation(UIEnFontBox item)
    {
        m_operations.Add(item.UID);
        m_myAnswer += item.ItemName;
        m_curOperationID = item.UID;
    }

    void ClearOperation()
    {
        m_operations.Clear();
        m_myAnswer = string.Empty;
        m_curOperationID = 0;
    }

    void ClearItems()
    {
        if (m_BoxList != null && m_BoxList.Count > 0)
        {
            Utils.RemoveItems<UIEnFontBox>(m_BoxList);
        }
    }
}
