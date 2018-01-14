using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIMain : UIScene
{
    [SerializeField]
    UIEnFontBox m_UIEnFontBoxClone=null;
    [SerializeField]
    UITalk m_UITalkClone;

    [SerializeField]
    UIGrid m_grid;

    [SerializeField]
    GameObject m_BoxParent;

    List<UIEnFontBox> m_BoxList = new List<UIEnFontBox>();
    List<UITalk> m_talkList = new List<UITalk>();

    List<int> m_operations = new List<int>();
    int m_operationsMax = 5;

    string m_correctAnswer = string.Empty;
    string m_myAnswer = string.Empty;

    int m_curOperationID = 0;

    [SerializeField]
    GameObject m_dragObject;

    List<string> m_fontsList;

    [SerializeField]
    UILabel m_myInputLabel;

    [SerializeField]
    UITalk m_talk;

    Configrestaurant m_curConfig = null;

    // Use this for initialization
    void Start ()
    {
        UIEventListener.Get(m_dragObject).onDrag = OnDragEvent;
        UIEventListener.Get(m_dragObject).onDragOut = onDragOutEvent;
        UpdateUI();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void UpdateUI()
    {
        m_curConfig = EnFontMgr.Instance.GetCurConfig();

        m_myInputLabel.text = "";
        m_talk.Init(m_curConfig);

        CreateItems();
        CreateTalks();

        base.UpdateUI();
    }

    void CreateTalks()
    {
        StartCoroutine(Utils.CreateItems<UITalk>(2, m_talk, m_talkList, m_grid.transform, SetTalkItems));
    }
    void SetTalkItems()
    {
        m_grid.Reposition();

        m_talkList[0].Init(m_curConfig);
        m_talkList[1].Init(EnFontMgr.Instance.GetNextConfig());

    }

    void CreateItems()
    {
        m_fontsList = EnFontMgr.Instance.GetData();

        if(m_fontsList != null && m_fontsList.Count>0)
        StartCoroutine(Utils.CreateItems<UIEnFontBox>(m_fontsList.Count, m_UIEnFontBoxClone, m_BoxList, m_BoxParent.transform, SetItems));
    }


    void SetItems()
    {
        if(m_BoxList!=null && m_BoxList.Count>0)
        {
            for (int i = 0; i < m_BoxList.Count; i++)
            {
                UIEnFontBox item = m_BoxList[i];
                int row = i / 3;
                int column = i % 3;
                Vector3 pos = new Vector3((1 - row) * 164, (column + 1) * (-120)-60, 0);
                item.transform.localPosition = pos;
                item.Init(i, m_fontsList[i]);
            }
        }
    }

    void onDragOutEvent(GameObject go)
    {
        if (IsSuccess())
        {
            SetSuccess();
        }
        else
        {
            ClearOperation();
        }

    }

    void OnDragEvent(GameObject go, Vector2 delta)
    {
        Vector3 pos = UICamera.mainCamera.ScreenToWorldPoint(Input.mousePosition);
        
        foreach (var item in m_BoxList)
        {
            Bounds bounds = item.bounds;
            if (bounds.Contains(pos))
            {
                //Debug.Log("item:"+ item.ItemName);
                if(!item.IsChoose)
                {
                    item.IsChoose = true;
                    CheckStatus(item);
                }
            }
            else
            {
                //Debug.Log(string.Format("bounds:", bounds.center));
                //Debug.Log(string.Format("pos,x:{0},y:{1},z:{2}", pos.x, pos.y, pos.z));
            }
        }
    }

    void CheckStatus(UIEnFontBox item = null)
    {
        if (item!=null && EnableAddOperation(item))
        {
            AddOperation(item);
        }

        if (IsSuccess())
        {
            SetSuccess();
            return;
        }

        if (m_operations.Count > m_operationsMax)
        {
            ClearOperation();
        }
    }

    void SetSuccess()
    {
        Debug.Log("SetSuccess");
        ClearOperation();
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
        m_myInputLabel.text = m_myAnswer;
    }

    void ClearOperation()
    {
        m_operations.Clear();
        m_myAnswer = string.Empty;
        m_curOperationID = 0;
        m_myInputLabel.text = "";

        foreach (var item in m_BoxList)
        {
            item.Clear();
        }
    }

    void ClearItems()
    {
        if (m_BoxList != null && m_BoxList.Count > 0)
        {
            Utils.RemoveItems<UIEnFontBox>(m_BoxList);
        }
    }
}
