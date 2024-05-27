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
            // 새 MeshCollider를 생성합니다.
            MeshCollider meshCollider = box.gameObject.AddComponent<MeshCollider>();
            meshCollider.convex = true;

            // 필요한 경우 메시를 할당합니다.
            MeshFilter meshFilter = box.gameObject.GetComponent<MeshFilter>();
            if (meshFilter != null)
            {
                meshCollider.sharedMesh = meshFilter.sharedMesh;
            }
            // BoxCollider를 제거합니다.
            Destroy(box);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
