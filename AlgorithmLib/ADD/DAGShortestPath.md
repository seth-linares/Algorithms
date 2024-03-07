# Algorithm Description Document

Author: Seth Linares    

Date: 10/15/2023

## 1. Name
Directed Acyclic Graph (DAG) Shortest Path

## 2. Abstract
The Shortest Path algorithm finds the shortest path along a DAG from a given vertex to all other vertices in a graph.

## 3. Methodology
The Shortest Path algorithm uses a topological sort to first order the vertices in a Directed Acyclic Graph (DAG). The topological sort is done by first finding the number of incoming edges (in-degree) for each vertex in the graph. The algorithm then iterates through the vertices again, but this time finding which vertices have an in-degree of 0. If a vertex has an in-degree of 0, then it is added to a queue and the in-degree of its neighbors is decremented. This process is repeated until all vertices have been removed from the graph and added to the topological order. The algorithm then iterates through the vertices in topological order, relaxing the edges of each vertex. By relaxing the edges, the algorithm finds the shortest path from the start vertex to each vertex in the graph by considering the shortest path to the current vertex's neighbors. Once all vertices have been relaxed, the algorithm returns the shortest path from the start vertex as well as the total distance that it took to complete the path.

## 4. Pseudocode

```
SHORTEST-PATH(graph, start_vertex)
    topological_order = TOPOLOGICAL-SORT(graph)
    distance = []
    predecessors = []
    
    for vertex in graph.vertices
        if vertex == start_vertex
            distance[vertex] = 0
            predecessors[vertex] = NULL
        else
            distance[vertex] = INFINITY
            predecessors[vertex] = INFINITY

    for vertex in topological_order
        for each edge from vertex
            RELAX(vertex, neighbor, edge_wt, distance, predecessors)

RETURN (distance, predecessors)

RELAX(vertex, neighbor, edge_wt, distance, predecessors)
    if distance[neighbor] > distance[vertex] + edge_wt AND distance[vertex] != INFINITY
        distance[neighbor] = distance[vertex] + edge_wt
        predecessors[neighbor] = vertex


TOPOLOGICAL-SORT(graph)

    indegree = ARRAY OF SIZE graph.Size, INITIALIZE ALL VALUES TO 0
    

    for each vertex in graph:
        for each edge from vertex:
            indegree[edge_id] = indegree[edge_id] + 1

    next = EMPTY QUEUE


    for i = 0 to graph.Size:
        if indegree[i] == 0:
            ENQUEUE i to next

    topological_order = EMPTY LIST


    while next IS NOT EMPTY:
        vertex_u = DEQUEUE from next
        APPEND vertex_u to topological_order


        for each edge from vertex_u:
            indegree[edge_id]--
            if indegree[edge_id] == 0:
                ENQUEUE edge_id to next


    RETURN topological_order



```

## 5. Inputs & Outputs

Inputs:

* graph: A graph object that contains the vertices and edges of the graph

* start_vertex: The vertex that the algorithm will find the shortest path from


Outputs:

* distance: An array that contains the distance from the start vertex to each vertex in the graph

* predecessors: An array that contains the predecessor of each vertex in the graph

## 6. Analysis Results

* Worst Case: $O(V + E)$

* Best Case: $\Omega(V + E)$

