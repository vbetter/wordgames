using System;
using System.Collections.Generic;
using UnityEngine;

public class EnFontMgr : MonoSingleton<EnFontMgr>
{
    string[] EnFontArray = {"A","B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

    public int m_curConfigID = 10000;

    // Use this for initialization
    void Start()
    {
        //Debug.Log(GetAnswerStringByItem(GetNextConfig()));
    }

    public Configrestaurant GetCurConfig()
    {
        return Configrestaurant.GetByKey(m_curConfigID);
    }

    public Configrestaurant GetNextConfig()
    {
        return Configrestaurant.GetByKey(m_curConfigID+1);
    }

    public string GetAnswerStringByItem(Configrestaurant item)
    {
        string str = string.Empty;
        string s = item.talk;
        if(s.Contains("{"))
        {
            int i = s.IndexOf("{") + 1;
            int j = s.IndexOf("}");
            str = s.Substring(i, j - i);
        }

        return str;
    }

    public string GetEncryptedStringByItem(Configrestaurant item)
    {
        
        string s = item.talk;
        if(!s.Contains("{")||!s.Contains("}"))
        {
            return s;
        }
        
        int i = s.IndexOf("{") + 1;
        int j = s.IndexOf("}");

        string str = s.Substring(i, j - i);
        string replaceStr = "";
        for (int k = 0; k < str.Length; k++)
        {
            replaceStr += "?";
        }
        string newStr = s.Replace(str, replaceStr);
        return newStr;
    }

    public List<string> GetData()
    {
        string str = GetAnswerStringByItem(GetNextConfig());
        char[] includeObjects = str.ToCharArray();
        
        List<string> tempList = GetEnFont(9, EnFontArray, includeObjects);
#if UNITY_EDITOR
        foreach (var item in tempList)
        {
            //print(item);
        }
#endif
        return tempList;
    }

    public List<string> GetEnFont(int count ,string[] totalObjects, char[] includeObjects)
    {
        List<string> tempList = new List<string>();
        string[] excludeArray = GetExcludeObjects(totalObjects, includeObjects);

        if(includeObjects!=null && includeObjects.Length>0)
        {
            foreach (var item in includeObjects)
            {
                tempList.Add(item.ToString());
            }
        }


        if(excludeArray!=null && excludeArray.Length>0)
        {
            while (tempList.Count < count)
            {
                int randIndex = UnityEngine.Random.Range(0, excludeArray.Length);
                tempList.Add(excludeArray[randIndex]);
            }
        }

        XiPai(ref tempList);

        return tempList;
    }

    public string[] GetExcludeObjects(string[] totalObjects, char[] includeObjects)
    {
        List<string> tempList = new List<string>();

        for (int i = 0; i < totalObjects.Length; i++)
        {
            string s1 = totalObjects[i];
            string s2 = string.Empty;
            for (int j = 0; j < includeObjects.Length; j++)
            {
                string jstr = includeObjects[j].ToString();
                if(jstr==s1)
                {
                    s2 = string.Empty;
                    break;
                }
                s2 = jstr;
            }
            if(s2!=string.Empty)
            {
                tempList.Add(s1);
            }
        }

        return tempList.ToArray();
    }

    void XiPai(ref List<string> list)
    {
        int i = list.Count;
        int j;
        if (i == 0)
        {
            return;
        }
        while (--i != 0)
        {
            System.Random ran = new System.Random();
            j = ran.Next() % (i + 1);
            string tmp = list[i];
            list[i] = list[j];
            list[j] = tmp;
        }
    }
}
