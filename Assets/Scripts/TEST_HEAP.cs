using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_HEAP : MonoBehaviour {

	// Use this for initialization
	void Start () {

        Time t1 = new Time(0, 5);
        Time t2 = new Time(0, 6);
        Time t3 = new Time(0, 6);
        Debug.Log(t1.CompareTo(t2));
        Debug.Log(t2.CompareTo(t1));
        Debug.Log(t2.CompareTo(t3));

        /*
        Dictionary<Vertex, Vertex> d = new Dictionary<Vertex, Vertex>();
        Vertex v = new Vertex("a", new Time(4, 20));
        d.Add(v, v);
        Vertex v2 = new Vertex("a", new Time(4, 20));
        Debug.Log(d.ContainsKey(v));
        Debug.Log(d.ContainsKey(v2));*/


        /*
        HashSet<Vertex> h = new HashSet<Vertex>();
        Vertex v = new Vertex("a", new Time(4, 21));
        Vertex v2 = new Vertex("a", new Time(4, 20));
        h.Add(v);
        h.Add(v2);

        List<Vertex> l = new List<Vertex>(h);
        Debug.Log(l.Count);
        foreach (Vertex v3 in l) Debug.Log(v3.name + " " + v3.time.ToString());
        l.Sort(new VertecesComparator());
        foreach (Vertex v3 in l) Debug.Log(v3.name + " " + v3.time.ToString());*/

        /*
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
        */
    }
}
