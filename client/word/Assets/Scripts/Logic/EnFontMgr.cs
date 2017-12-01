using System;
using System.Collections.Generic;
using UnityEngine;

public class EnFontMgr : MonoSingleton<EnFontMgr>
{
    string[] EnFontArray = {"A","B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P", "Q", "R", "S", "T", "U", "V", "W", "X", "Y", "Z"};

    // Use this for initialization
    void Start()
    {
        
    }


    public List<string> GetData()
    {
        string[] includeObjects = {"C","O","O","L" };
        List<string> tempList = GetEnFont(5, EnFontArray, includeObjects);
#if UNITY_EDITOR
        foreach (var item in tempList)
        {
            print(item);
        }
#endif
        return tempList;
    }

    public List<string> GetEnFont(int count ,string[] totalObjects,string[] includeObjects)
    {
        List<string> tempList = new List<string>();
        string[] excludeArray = GetExcludeObjects(totalObjects, includeObjects);

        if(includeObjects!=null && includeObjects.Length>0)
        {
            tempList.CopyTo(includeObjects);
            tempList = new List<string>(includeObjects);
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

    public string[] GetExcludeObjects(string[] totalObjects, string[] includeObjects)
    {
        List<string> tempList = new List<string>();

        for (int i = 0; i < totalObjects.Length; i++)
        {
            string s1 = totalObjects[i];
            string s2 = string.Empty;
            for (int j = 0; j < includeObjects.Length; j++)
            {
                string jstr = includeObjects[j];
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
