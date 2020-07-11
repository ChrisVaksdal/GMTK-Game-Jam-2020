using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundLayerGenerator : MonoBehaviour
{
    public GameObject target;                   // The background will center on this GameObject.
    public GameObject backgroundLayerElement;   // The background will be made from this.
    public int size = 3;                        // Number of background quads per side.
    public float parralax = 2f;                 // Higher number --> Slower movement relative to target.
    

    private List<GameObject> layerElements = new List<GameObject>();




    void Start()
    {
        /* Instantiate all background elements for this layer. */
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                layerElements.Add(Object.Instantiate(backgroundLayerElement, this.transform.position, Quaternion.Euler(90,0,0), this.transform));
            }
        }
    }


    void Update()
    {
        /* Iterate over all background layer elements and update them. */
        for (int i = 0; i < size; i++)
        {
            for (int j = 0; j < size; j++)
            {
                /* Get background layer element. */
                GameObject gameObject = layerElements[i*size+j];

                MeshRenderer meshRenderer = gameObject.GetComponent<MeshRenderer>();
                Material material = meshRenderer.material;


                /* Offset texture to simulate movement. */
                Vector2 offset = material.mainTextureOffset;

                offset.x = target.transform.position.x / gameObject.transform.localScale.x / parralax;
                offset.y = target.transform.position.z / gameObject.transform.localScale.y / parralax;

                material.mainTextureOffset = offset;


                /* Reposition background element at target. */
                Vector3 newPos = target.transform.position;

                newPos.y = this.transform.position.y;
                newPos.x += ((float)i-((float)size / 2)) * meshRenderer.bounds.size.x + (meshRenderer.bounds.size.x/2);
                newPos.z += ((float)j-((float)size / 2)) * meshRenderer.bounds.size.z + (meshRenderer.bounds.size.z/2);

                gameObject.transform.position = newPos;
            }
        }
    }
}