using System;
using System.Collections.Generic;
using System.Drawing;
public class Solution17 {
    public void Run(){
        var input=new int[][]{
          //  new int[]{2,1,1},new int[]{1,1,0},new int[]{0,1,1}
         // new int[]{0,2}
         new int[]{1}, new int[]{2}
        };
        var min=OrangesRotting(input);
    }
      public int[][] Directions=new int[][]{
        new int[] {0,1},
        new int[] {1,0},
        new int[] {0,-1},
        new int[] {-1,0}
    };
    public int OrangesRotting(int[][] grid) {
        var n =grid.Length;
      
        var visited=new bool[n,grid[0].Length];
        var rotten=new List<int[]>();
        var fresh=new List<Point>();
        var queue=new Queue<Point>();
        for(int i=0;i<n;i++)
        {
            for(int j=0;j<grid[0].Length;j++){
                var t=grid[i][j];
                if(t==0) visited[i,j]=true;
                if(t==2){
                    visited[i,j]=true;
                    queue.Enqueue(new Point(i,j));
                }
                if(t==1) fresh.Add(new Point(i,j));
                
            }
        }
        if(fresh.Count==0) return 0;
        if(queue.Count==0) return -1;
       
        var minutes=0;
        while(queue.Count>0 && fresh.Count>0){
            var t=queue.Count;
            minutes++;
            for (int l=0;l<t;l++){
               
                var cur=queue.Dequeue();
                for(int b=0;b<Directions.Length;b++){
                   var x=cur.X + Directions[b][0];
                   var y=cur.Y +Directions[b][1];
                   var newVal=new Point(x,y);
                   if(0<=x && x<n && 0<=y && y<grid[0].Length && !visited[x,y] && fresh.Contains(newVal)){
                       visited[x,y]=true;
                       queue.Enqueue(newVal);
                       fresh.Remove(newVal);
                   }
                }
            }
           
        }
        return fresh.Count>0?-1:minutes;
    }

    
}