using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UITalkItem : MonoBehaviour {

    [SerializeField]
    UILabel m_talk;

    [SerializeField]
    UISprite m_icon;

	// Use this for initialization
	void Start () {
		
	}
	
	public void Init(string talk, string iconName)
    {
        m_icon.spriteName = iconName;
        m_talk.text = talk;
    }
}
