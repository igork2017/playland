using System;
using System.Collections.Generic;

public class CriticalConnections{
    public void Run(){
        Graph g1 = new Graph(5); 
        g1.AddEdge(1, 0); 
        g1.AddEdge(0, 2); 
        g1.AddEdge(2, 1); 
        g1.AddEdge(0, 3); 
        g1.AddEdge(3, 4); 
        g1.Bridge();
    }

    public class Graph{
        private int V;
        private Dictionary<int,IList<int>> adj;
        int time =0 ;

        public Graph(int v){
            V=v;
            adj = new Dictionary<int,IList<int>>();
            for(int i=0; i<v;i++){
                adj[i]=new List<int>();
            }
        }

        public void AddEdge(int v, int w)
        {
            adj[v].Add(w);
            adj[w].Add(v);
        }

        public void BridgeUtil(int u, bool[] visited, int[] disc, int[] low, int[] parent){
            visited[u]=true;
            disc[u]=low[u]=++time;
            foreach(var t in adj[u]){
                int v=t;
                if(!visited[v]){
                    parent[v]=u;
                    BridgeUtil(v,visited,disc,low,parent);

                    low[u]= Math.Min(low[u],low[v]);
                    if(low[v]>disc[u]) Console.WriteLine(u + " " + v);
                }
                else if (v!=parent[u]) low[u] = Math.Min(low[u],disc[v]);
            }
        }

        public void Bridge(){
            var visited = new bool[V];
            var disc=new int[V];
            var low=new int[V];
            var parent=new int[V];

            for(int i=0;i<V;i++){
                parent[i] = Int32.MinValue;
                visited[i] = false;
            }

            for (int i = 0; i < V; i++) 
                if (visited[i] == false) 
                    BridgeUtil(i, visited, disc, low, parent); 
        }

    }
}