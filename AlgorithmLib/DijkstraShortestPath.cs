using System;
using System.Collections.Generic;
using AlgorithmLib;

public static class DijkstraShortestPath
{
    public static (List<int>, List<int>) ShortestPath(Graph g, int startVertex) {
        var prio_queue = new PriorityQueue<int>();
        var dist = new List<int>();
        var pred = new List<int>();

        for(int i = 0; i < g.Size(); i++) {
            if(i == startVertex) { // When we find start, set it's distance to 0 and just set pred to INF since there is no pred for the start
                dist.Add(0);
                pred.Add(Graph.INF);
            }

            else { // All other vertices set distances and preds to INF
                dist.Add(Graph.INF);
                pred.Add(Graph.INF);
            }

            prio_queue.Insert(i, dist[i]); // Once we have set the values, add the vertex and its distance to the priority queue
        }

        while(prio_queue.Size() > 0) {
            int u = prio_queue.Dequeue(); // dequeue the lowest prio vertex to use in the next steps

            foreach(Edge e in g.Edges(u)) { // take the dequeued vertex and go through each outgoing edge
                Relax(e, u, dist, pred, prio_queue); // Call the Relax method to relax the edges
            }

        }

        return (dist, pred); // return the distance and predecessor list as these are our results


    } 

    public static void Relax(Edge e, int prev_vertex, List<int> dist, List<int> pred, PriorityQueue<int> prio_queue) { // Decided to make Relax method to adhere to psuedo code
        if(dist[e.DestId] > dist[prev_vertex] + e.Weight) { // if distance at this vertex > previous vertex + weight of the edge
            dist[e.DestId] = dist[prev_vertex] + e.Weight; // set distance to be the new shorter distance
            pred[e.DestId] = prev_vertex; // since we found shorter path, set the predecessor to be the vertex we came from to get the shorter distance
            prio_queue.DecreaseKey(e.DestId, dist[e.DestId]); // Need to updare the priority queue to reflect shorter distance
            

        }

    }
}
