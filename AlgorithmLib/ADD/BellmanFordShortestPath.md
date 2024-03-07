# Algorithm Description Document

Author: Seth Linares

Date: 12/11/23

## 1. Name
Bellman Ford Shortest Path

## 2. Abstract
The Bellman Ford algorithm computes the shortest paths from a single source vertex to all other vertices in a weighted graph, capable of handling negative weights.

## 3. Methodology
The Bellman-Ford algorithm is designed to find the shortest paths from a single source vertex to all other vertices in a weighted graph, which may have negative weight edges. Unlike Dijkstra's algorithm, Bellman-Ford can handle graphs with negative cycles and is capable of detecting negative cycles which would otherwise cause the algorithm to run indefinitely. The algorithm works by iteratively relaxing the edges of the graph. It maintains a table of minimum distances from the source to each vertex and updates these distances based on the edge weights. If, after V-1 iterations (where V is the number of vertices), the distances can still be reduced, the graph contains a negative weight cycle and the algorithm will return an error. Otherwise, the algorithm will return the minimum distances from the source to each vertex. The algorithm is often used in routing protocols like BGP (Border Gateway Protocol) and in various optimization problems.

## 4. Pseudocode

```
SHORTEST-PATH(graph, startVertex)
    distance = new List<int>(filled with INF for graph.Size())
    pred = new List<int>(filled with INF for graph.Size())

    distance[startVertex] = 0

    contains_negative_cycle = false

    for i = 0 to graph.Size() - 1
        changesMade = false
        for u = 0 to graph.Size() - 1
            for each edge (u, v, weight) in graph.Edges(u)
                if distance[u] + weight < distance[v]
                    if i == graph.Size() - 1
                        cycle = FIND-NEGATIVE-WEIGHT-CYCLE(graph, v, pred)
                        contains_negative_cycle = true
                    changesMade = true
                    distance[v] = distance[u] + weight
                    pred[v] = u
        if not changesMade
            break

    if contains_negative_cycle
        return (new List<int>(), new List<int>())

    return (distance, pred)

NEGATIVE-WEIGHT-CYCLE(graph, vertex, pred)
    visited = new List<bool>(filled with false for graph.Size())
    x = vertex
    while not visited[x]
        visited[x] = true
        x = pred[x]

    v = pred[x]
    cycle = new List<int> with x
    while v != x
        Insert v at the beginning of cycle
        v = pred[v]

    return cycle

```

## 5. Inputs & Outputs

Inputs:
* graph: a weighted graph with V vertices and E edges

* startVertex: the vertex from which to compute the shortest paths

Outputs:

* distance: a list of the minimum distances from the start vertex to each vertex in the graph. Returns an empty list if the graph contains a negative weight cycle.

* pred: a list of the predecessors of each vertex in the shortest paths. Returns an empty list if the graph contains a negative weight cycle.


## 6. Analysis Results

* Worst Case: $O(V*E)$

* Best Case: $\Omega(V*E)$
