using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathsMemory {

    Stack<State> states;
    PathShowing pathShowing;

    public PathsMemory(PathShowing ps)
    {
        pathShowing = ps;
        states = new Stack<State>();
    }

    public void memorize(State state)
    {
        states.Push(state);
    }

    public State getLastState()
    {
        return states.Pop();
    }

    public int numberOfStates()
    {
        return states.Count;
    }

}
