using System.Collections;

namespace AlgorithmLib;

public static class DAGTopologicalSort
{

    // There will be many comments as this graph stuff gets complicated. I am using them to work through the ideas. Sorry in advance. 
    public static List<int> Sort(Graph g) {
        int[] indegree = new int[g.Size()]; // C# initializes each to default(int) which is 0 anyways

        for(int i = 0; i < g.Size(); i++) { // for loop length = to # vertices
            foreach(Edge e in g.Edges(i)) { // use a for each loop to go through each edge at each vertex `i`
                indegree[e.DestId]++; 
                // Okay, so we go through every edge connected to the vertex `i` and when we encounter an edge destination, we say "hey at the index corresponding to this dest in our 
                // list `indegree`, make sure to incrememnt it so that we know that a vertex is pointing to it!

                // The loop allows us to go through every V and then every time we encounter a vertex it connects to, we add 1 to it's index in the indegree list! :D

            }
        }

        var next = new Queue<int>(); // Need a queue to store the vertices with in-degree 0. Will help us dequeue and enqueue. 
        // I think you wanted us to use a stack, but queue works too and it's not a big deal I don't think. 

        // Anyways, queues use FIFO so essentially this allows us to sort as the first ones with in-degree 0 will be at the back ready to dequeue and the last ones will be at the front. 

        for(int i = 0; i < g.Size(); i++) {
            if(indegree[i].Equals(0)) { // check the in-degrees and see if they equal 0. If so we enqueue them into `next`
                next.Enqueue(i);

            }   
        }

        var topological_order = new List<int>();
        while(next.Count > 0) {

            int vertex_u = next.Dequeue(); // store the vertex u by dequeuing it, so that we can reference it later
            topological_order.Add(vertex_u); // Add the vertex u to the list of sorted vertices

            foreach(Edge e in g.Edges(vertex_u)) { // Now this is where we through every vertex connected to u and decrement their connections as it is now "gone".
                indegree[e.DestId]--;
                if(indegree[e.DestId] == 0) { // if after decrementing v's in-degree it becomes 0, add it to the queue for later
                    next.Enqueue(e.DestId);
                }
            }

        }

        return topological_order;
    } 
}