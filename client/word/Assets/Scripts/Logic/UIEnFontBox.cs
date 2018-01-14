using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIEnFontBox : UIBaseBox {

    public int UID;
    public string ItemName = string.Empty;

    [SerializeField]
    BoxCollider m_boxCollider;

    bool m_isChoose = false;
    public bool IsChoose
    {
        set
        {
            m_bgIcon.gameObject.SetActive(value);
            m_isChoose = value;
        }
        get
        {
            return m_isChoose;
        }
    }

    public Bounds bounds
    {
        get
        {
            return m_boxCollider.bounds;
        }
    }

    [SerializeField]
    UILabel m_LabelFont;
    [SerializeField]
    UISprite m_bgIcon;

    // Use this for initialization
    void Start () {
		
	}
	
	public void Init(int uid,string itemName)
    {
        ItemName = itemName;
        UID = uid;
        m_LabelFont.text = ItemName;
        IsChoose = false;
    }

    public void Clear()
    {
        IsChoose = false;
    }
}
