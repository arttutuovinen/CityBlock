using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetPivot : MonoBehaviour
{
    [SerializeField] Transform pivot;
    void UpdatePivots()
    {
        var renderers = gameObject.GetComponentsInChildren<Renderer>();
        foreach (Renderer renderer in renderers)
        {
            var mats = renderer.materials;
            foreach (Material mat in mats)
            {
                mat.SetVector("_Position", pivot.position);
            }
        }
    }
    void Start()
    {
        UpdatePivots();
    }
    void Update()
    {
        if (Application.platform == RuntimePlatform.WindowsEditor) // only run in editor 
            UpdatePivots();
    }
}
