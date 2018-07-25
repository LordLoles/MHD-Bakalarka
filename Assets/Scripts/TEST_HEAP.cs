using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using C5;
using System;

public class TEST_HEAP : MonoBehaviour {

	// Use this for initialization
	void Start () {

        MinHeap<int> h = new MinHeap<int>(Comparer<int>.Default);
        h.Add(0);
        Debug.Log(h.Count());
        h.Add(2);
        h.Add(0);
        Debug.Log(h.Count());
        h.Add(0);
        Debug.Log(h.Count());

        Debug.Log(h.PopMin());
        Debug.Log(h.PopMin());

        Debug.Log("asd");

        h.Add(0);
        Debug.Log(h.Count());
        h.Add(2);
        h.Add(0);
        Debug.Log(h.Count());
        h.Add(0);
        Debug.Log(h.Count());

        Debug.Log(h.PopMin());
        Debug.Log(h.PopMin());

        Debug.Log("asdasd");

        h.Add(0);
        Debug.Log(h.Count());
        h.Add(2);
        h.Add(0);
        Debug.Log(h.Count());
        h.Add(0);
        Debug.Log(h.Count());

        Debug.Log(h.PopMin());
        Debug.Log(h.PopMin());

    }
}
