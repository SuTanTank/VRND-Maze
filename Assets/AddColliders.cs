using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[ExecuteInEditMode]
public class AddColliders : MonoBehaviour
{

    // Use this for initialization
    public GameObject rootObject;
#if UNITY_EDITOR
    void Update()
    {
        if (UnityEditor.EditorApplication.isPlayingOrWillChangePlaymode)
        {
            this.enabled = false;
        }
        else
        {
            //DeleteChildCollider(rootObject);
            AddChildCollider(rootObject);
        }
    }
#endif
    void AddChildCollider(GameObject father)
    {
        foreach (Transform childTransform in father.transform)
        {
            var child = childTransform.gameObject;
            if (child.GetComponent<Renderer>() != null && child.GetComponent<Collider>() == null)
            {
                child.AddComponent<BoxCollider>();
                Debug.Log(child.name);
            }
            else
            {
                AddChildCollider(child);
            }
        }
    }
}
