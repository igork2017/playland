using System;
using System.Collections.Generic;
using System.Drawing;

public class MergeInterval{
    public Dictionary<Point, List<Point>> graph;
    public Dictionary<int,List<Point>> nodesInComp;
    private List<Point> visited;
    public void Run(){
        var input = new int[][]{
            new int[]{1,3},
             new int[]{2,6},
             new int[]{8,10},
             new int[]{15,18},
        };

        var result = Merge(input);
    }
    public int[][] Merge(int[][] intervals) {
        Array.Sort(intervals, new MySorter());
        var merged = new List<int[]>();       
        var count=0;
        foreach(var interval in intervals){
            if(count==0 || merged[count-1][1]<interval[0]){
                merged.Add(interval);
                count++;
            }
            else{
                merged[count-1][1]=Math.Max(merged[count-1][1],interval[1]);
            }
           
        }
        return merged.ToArray();
    }

    private bool overlap(Point a, Point b){
        return a.X<=b.Y && b.X<=a.Y;
    }

    private void buildGraph(List<Point> intervals){
        graph=new Dictionary<Point, List<Point>>();
        foreach(var interval in intervals){
            graph.Add(interval, new List<Point>());
        }

        foreach(var interval1 in intervals){
            foreach(var interval2 in intervals){
                if(overlap(interval1, interval2)){
                    graph[interval1].Add(interval2);
                    graph[interval2].Add(interval1);
                }
            }
        }
    }

    private Point mergeNodes(List<Point> nodes){
        int minStart=nodes[0].X;
        foreach(var node in nodes){
            minStart=Math.Min(minStart,node.X);
        }

        var maxEnd=nodes[0].Y;
        foreach(var node in nodes){
            maxEnd=Math.Max(maxEnd, node.Y);
        }

        return new Point(minStart, maxEnd);
    }

    private void markComponentDFS(Point start, int comNumber){
        var stack= new Stack<Point>();
        stack.Push(start);
        while(stack.Count>0){
            var node = stack.Pop();
            if(!visited.Contains(node)){
                visited.Add(node);
                if(!nodesInComp.ContainsKey(comNumber)){
                    nodesInComp.Add(comNumber, new List<Point>());
                }
                nodesInComp[comNumber].Add(node);

                foreach(var child in graph[node]){
                    stack.Push(child);
                }
            }
        }
    }

    public void buildComponents(List<Point> intervals){
        nodesInComp = new Dictionary<int, List<Point>>();
        visited = new List<Point>();
        int compNumber=0;

        foreach(var interval in intervals){
            if(!visited.Contains(interval)){
                markComponentDFS(interval, compNumber);
                compNumber++;
            }
        }
    }

    public List<Point> merge(List<Point> intervals) {
        buildGraph(intervals);
        buildComponents(intervals);

        // for each component, merge all intervals into one interval.
        List<Point> merged = new List<Point>();
        for (int comp = 0; comp < nodesInComp.Count; comp++) {
            merged.Add(mergeNodes(nodesInComp[comp]));
        }

        return merged;
    }

    class  MySorter: IComparer<int[]>{
        int IComparer<int[]>.Compare(int[] a, int[] b){
            return a[0] < b[0]?-1:a[0]==b[0]?0:1;
        }
    }
   
}


