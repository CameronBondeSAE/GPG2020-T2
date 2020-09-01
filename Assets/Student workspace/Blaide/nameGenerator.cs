using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class nameGenerator : MonoBehaviour
{
    public List<String> prefixWords = new List<string>();

    public List<String> suffixWords = new List<string>();

    public TextMeshProUGUI tmp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnEnable()
    {
        GenerateName();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GenerateName()
    {
        tmp.text = prefixWords[Random.Range(0, prefixWords.Count)] + " " + suffixWords[Random.Range(0,suffixWords.Count)];  
    }
}
