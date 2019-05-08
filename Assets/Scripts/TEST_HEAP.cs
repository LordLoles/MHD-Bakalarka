using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEST_HEAP : MonoBehaviour {

	// Use this for initialization
	void Start () {

        //Debug.Log(Time.differenceBetweenTimesMinCloser(new Time(22,0), new Time(2,0)));

        /*
        List<int> path = new List<int> { 1,2,3,4,5 };
        foreach (int a in path)
            Debug.Log(a);
        path.Reverse();
        foreach (int a in path)
            Debug.Log(a);*/

        //Debug.Log("1 comb".Remove("1 comb".Length - 5));
        //Debug.Log("fds1s comb".Remove("fds1s comb".Length - 5));

        /*
        Time t1 = new Time(0, 5);
        Time t2 = new Time(0, 6);
        Time t3 = new Time(0, 6);
        Time t4 = new Time(0, 1);
        Time t5 = new Time(0, 10);
        Debug.Log(t1.CompareTo(t2)); // (0, 5) (0, 6) = -1
        Debug.Log(t2.CompareTo(t1)); // (0, 6) (0, 5) = 1
        Debug.Log(t2.CompareTo(t3)); // (0, 6) (0, 6) = 0


        Debug.Log(t1.isBetween(t4, t2));
        Debug.Log(t4.isBetween(t4, t2));
        Debug.Log(t2.isBetween(t4, t2));
        Debug.Log(t5.isBetween(t4, t2));*/

        /*
        GraphCreator gc = new GraphCreator(Application.dataPath + "/Data/" + "Bratislava" + "/", "zastavky", "linky");
        Graph graph = gc.getGraph();
        Time start = new Time(16, 10);
        gc.makeGraph(start);
        Dijkstra dijkstra = new Dijkstra(graph, new PathMaker(graph), gc);
        dijkstra.shortestPathsAmount(start, "Zoo", "Patronka", 3);

        List<Vertex> targets = new List<Vertex>(graph.allStops["Patronka"]);
        targets.Sort(new DijkstrasComparator());

        Debug.Log("fin");*/

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
