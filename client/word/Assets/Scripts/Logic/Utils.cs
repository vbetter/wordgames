using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utils : MonoBehaviour {

    public static void RemoveItems<T>(List<T> list) where T : MonoBehaviour
    {
        if (list != null && list.Count > 0)
        {
            for (int i = list.Count - 1; i >= 0; i--)
            {
                T item = list[i];
                GameObject.Destroy(item.gameObject);
            }
            list.Clear();
        }
    }

    public static IEnumerator CreateItems<T>(int count, T itemClone, List<T> items, Transform paretTransform, System.Action onFinish = null) where T : MonoBehaviour
    {
        for (int i = 0; i < count; i++)
        {
            GameObject go = Instantiate(itemClone.gameObject);
            go.transform.parent = paretTransform;
            go.transform.localPosition = Vector3.zero;
            go.transform.localScale = Vector3.one;
            go.SetActive(true);
            items.Add(go.GetComponent<T>());
        }
        if (onFinish != null)
        {
            onFinish();
        }
        yield return null;
    }
}
