# Algorithm Description Document

Author: Seth Linares    

Date: 10/25/23

## 1. Name
Dijkstra Shortest Path

## 2. Abstract
Dijkstra Shortest Path is an algorithm for finding the shortest paths between nodes in a graph, which may represent, for example, road networks or computer networks.

## 3. Methodology
Dijkstra's algorithm begins with a start vertex and assigns it a distance of zero while assigning the rest of the vertices a distance of infinity. It then proceeds to find the shortest path to every other vertex in the graph. The algorithm maintains a priority queue of vertices, prioritized by their distance from the start vertex. The algorithm then iterates through the priority queue, visiting each vertex in order of distance from the start vertex. For each vertex, the algorithm checks each of its neighbors and updates their distance from the start vertex if the path through the current vertex is shorter than the previously known shortest path. When the priority queue is empty, the algorithm finishes and returns the distances and predecessors of each vertex in the shortest path from the start vertex.

## 4. Pseudocode

```
SHORTEST-PATH(graph, start_vertex)
    priority_queue = EMPTY PRIORITY QUEUE
    distance = []
    predecessors = []

    for vertex in graph.vertices
        if vertex == start_vertex
            distance[vertex] = 0
            predecessors[vertex] = NULL
        else
            distance[vertex] = INFINITY
            predecessors[vertex] = NULL

        priority_queue.enqueue(vertex, distance[vertex])

    while priority_queue is not empty
        vertex = priority_queue.dequeue()
        for each edge from vertex
            RELAX(edge_dest, vertex, edge_wt, distance, predecessors, priority_queue)

RETURN (distance, predecessors)

RELAX(edge_dest, vertex, edge_wt, distance, predecessors, priority_queue)
    if distance[edge_dest] > distance[vertex] + edge_wt
        distance[edge_dest] = distance[vertex] + edge_wt
        predecessors[edge_dest] = vertex
        priority_queue.update(edge_dest, distance[edge_dest])
```

## 5. Inputs & Outputs

Inputs:

* graph: A graph object that contains the vertices and edges of the graph

* start_vertex: The vertex from which to find the shortest path to all other vertices


Outputs:

* distance: An array of the distances from the start vertex to each vertex in the graph

* predecessors: An array of the predecessors of each vertex in the shortest path from the start vertex

## 6. Analysis Results

* Worst Case: $O((V + E)*log(V))$

* Best Case: $\Omega((V + E)*log(V))$ 

