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

    public void Init(string talk,string iconName,bool isLeft)
    {
        if(m_talkLeft)
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
