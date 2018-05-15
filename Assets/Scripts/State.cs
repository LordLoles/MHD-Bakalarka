using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State {

    internal List<List<Edge>> paths;

    public State(List<List<Edge>> paths)
    {
        this.paths = paths;
    }

    public State()
    {
        paths = new List<List<Edge>>();
    }

}
