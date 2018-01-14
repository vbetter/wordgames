using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITalk : MonoBehaviour {

    [SerializeField]
    UITalkItem m_talkLeft;

    [SerializeField]
    UITalkItem m_talkRight;

    bool m_isLeft = false;

	// Use this for initialization
	void Start () {
		
	}

    public void Init(Configrestaurant item)
    {
        string talk = EnFontMgr.Instance.GetEncryptedStringByItem(item);
        Init(talk, item.icon_name, item.isLeft);
    }

    public void Init(string talk,string iconName,bool isLeft)
    {
        
        if(isLeft)
        {
            m_talkLeft.gameObject.SetActive(true);
            m_talkLeft.Init(talk, iconName);
            m_talkRight.gameObject.SetActive(false);
        }
        else
        {
            m_talkLeft.gameObject.SetActive(false);
            m_talkRight.gameObject.SetActive(true);
            m_talkRight.Init(talk, iconName);
        }
    }
}
