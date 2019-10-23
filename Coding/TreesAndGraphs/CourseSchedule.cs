using System;
using System.Collections.Generic;

public class CourseSchedule{
    public void Run(){
        var numCourses=2;
        var prerequisites=new int[][]{
            new int[]{1,0},
            new int[]{0,1}
        };
       // var result = findOrder(numCourses, prerequisites);
        Console.WriteLine(CanFinish(numCourses,prerequisites));
    }
    public bool CanFinish(int numCourses, int[][] prerequisites) {
        var graph=MakeGraph(numCourses,prerequisites);
        var toposort=new List<int>();
        var onpath= new Dictionary<int, bool>();
        var visited= new Dictionary<int,bool>();
        for(int i=0;i<numCourses;i++){
            if((!visited.ContainsKey(i) || !visited[i]) && dfsSearch(graph, i, onpath,visited,toposort)) return false;
        }
        return true;
    }

    Dictionary<int,List<int>> MakeGraph(int numTasks, int[][] prerequisites){
        var dict=new Dictionary<int,List<int>>();
        foreach(var pre in prerequisites){
            if(dict.ContainsKey(pre[1])){
                dict[pre[1]].Add(pre[0]);
            }
            else{
                dict.Add(pre[1], new List<int>{pre[0]});
            }
        }
        return dict;
    }

    bool dfsSearch(Dictionary<int,List<int>> graph, int node, Dictionary<int,bool> onpath, Dictionary<int,bool> visited, List<int> toposort){
         if(visited.ContainsKey(node) && visited[node]) return false;
        if(onpath.ContainsKey(node)) onpath[node]=true;
        else onpath.Add(node, true);
        if(visited.ContainsKey(node)) visited[node]=true;
        else visited.Add(node, true);
        if(graph.ContainsKey(node))
            foreach(var neigh in graph[node])
                if((onpath.ContainsKey(neigh) && onpath[neigh]) || dfsSearch(graph,neigh,onpath,visited,toposort)) return true;
        if(toposort.Contains(node)) return true;
        toposort.Add(node);
        return onpath[node]=false;
    }

    
    bool dfs(Dictionary<int,List<int>> graph, int node, Dictionary<int,bool> onpath, Dictionary<int,bool> visited, List<int> toposort){
        if(visited.ContainsKey(node) && visited[node]) return false;
        if(onpath.ContainsKey(node)) onpath[node]=true;
        else onpath.Add(node, true);
        if(visited.ContainsKey(node)) visited[node]=true;
        else visited.Add(node, true);
        if(graph.ContainsKey(node))
            foreach(var neigh in graph[node])
                if((onpath.ContainsKey(neigh) && onpath[neigh]) || dfs(graph,neigh,onpath,visited,toposort)) return true;
        toposort.Add(node);
        return onpath[node]=false;
    }

    List<int> findOrder(int numTasks,  int[][] prerequisites){
        var graph=MakeGraph(numTasks,prerequisites);
        var toposort=new List<int>();
        var onpath= new Dictionary<int, bool>();
        var visited= new Dictionary<int,bool>();
        for(int i=0;i<numTasks;i++){
            if((!visited.ContainsKey(i) || !visited[i]) && dfs(graph, i, onpath,visited,toposort)) return new List<int>();
        }
        return toposort;
    }
}