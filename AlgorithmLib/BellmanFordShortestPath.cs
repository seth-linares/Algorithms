namespace AlgorithmLib;

public static class BellmanFordShortestPath
{
    public static (List<int>, List<int>) ShortestPath(Graph g, int startVertex) {
        List<int> distance = new List<int>();
        List<int> pred = new List<int>();
      


        for(int i = 0; i < g.Size(); i++) { // Initialize the distance and pred lists
            distance.Add(Graph.INF);
            pred.Add(Graph.INF);
        }

        distance[startVertex] = 0; // distance of start vertex needs to be 0

        bool contains_negative_cycle = false; // create bool var to hold information on presence of negative cycle

        for(int i = 0; i < g.Size(); i++) { // This is the outer loop and will serve to repeat the relaxation for each edge n times (nth time is used for cycle detection)
            bool changesMade = false; // keep track of if changes are happening in the loops, can break early if not
            
            for(int u = 0; u < g.Size(); u++) // go through every edge and relax them
                foreach(Edge e in g.Edges(u)) {

                    if(distance[u] + e.Weight < distance[e.DestId]) { // elaxation, will check for cycles inside but will also set new pred and distance values
                        if(i == g.Size() - 1) {
                            var cycle = find_negative_weight_cycle(g, e.DestId, pred);
                            contains_negative_cycle = true; // negaive cycle found - set to true

                        }

                        changesMade = true;
                        distance[e.DestId] = distance[u] + e.Weight;
                        pred[e.DestId] = u;
                    }
                }

            if(!changesMade) { // optimization to return early if no changes being made
                break;
            }

        }

        if(contains_negative_cycle) {
            return(new List<int>(), new List<int>()); // return empty lists if a negative cycle was found
        }


        return(distance, pred); // if no negative cycles return the distances and predecessors 

        



}

    public static List<int> find_negative_weight_cycle(Graph g, int vertex, List<int> pred) {
        List<bool> visited = new List<bool>(new bool[g.Size()]); // create list full of 'false' of size g.Size()
        int x = vertex; // create variable to hold the original vertex
        
        while(!visited[x]) { // go through and check to see if a vertex has already been visited, meaning a cycle exists
            visited[x] = true; 
            x = pred[x];
        }

        int v = pred[x];
        List<int> cycle = new List<int>{x}; //start cycle with the first vertex detected as part of the cycle

        while(v != x) {  // go through and append all of the connected vertices in the cycle to the cycle list
            cycle.Insert(0, v);  // Insert at the beginning of the list
            v = pred[v]; 
        }
        return cycle;
    }

}





