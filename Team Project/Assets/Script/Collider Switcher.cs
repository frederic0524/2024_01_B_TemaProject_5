using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderSwitcher : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        BoxCollider[] boxColliders = FindObjectsOfType<BoxCollider>();

        foreach (BoxCollider box in boxColliders)
        {
            // �� MeshCollider�� �����մϴ�.
            MeshCollider meshCollider = box.gameObject.AddComponent<MeshCollider>();
            meshCollider.convex = true;

            // �ʿ��� ��� �޽ø� �Ҵ��մϴ�.
            MeshFilter meshFilter = box.gameObject.GetComponent<MeshFilter>();
            if (meshFilter != null)
            {
                meshCollider.sharedMesh = meshFilter.sharedMesh;
            }
            // BoxCollider�� �����մϴ�.
            Destroy(box);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
