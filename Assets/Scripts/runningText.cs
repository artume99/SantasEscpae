using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class runningText : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI textMesh;
    public float scrollSpeed=30.0f;

    // Start is called before the first frame update
    void Start()
    {
        textMesh = GetComponent<TextMeshProUGUI>();    
    }

    // Update is called once per frame
    void Update()
    {
        // textMesh.offset += new Vector2(0,scrollSpeed* Time.deltaTime);
    }
}
