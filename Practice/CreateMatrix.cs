using System;
using System.Collections.Generic;
public class Solution16 {
    public void Run(){
        var input=4;
        GenerateMatrix(input);
    }
    public int[][] Directions=new int[][]{
        new int[] {0,1},
        new int[] {1,0},
        new int[] {0,-1},
        new int[] {-1,0}
    };
    public int[][] GenerateMatrix(int n) {
        var s=new int[n][];
        var visited=new bool[n,n];       
        s[0]=new int[n];
        s[0][0]=1;
        if(n==1) return s;
        visited[0,0]=true;
        GenerateIt(s, visited, 0, 1, 2, 0);
        return s;
    }

    private void GenerateIt(int[][] s, bool[,] visited, int x , int y, int val, int index){
        var n=s.Length;
        if(s[x]==null) s[x]=new int[n];        
        if(visited[x,y]) return;
        s[x][y]=val;
        visited[x,y]=true;
       
        var nextX=x+Directions[index][0];
        var nextY=y+Directions[index][1];
       
        if(nextX>=0 && nextX<n && nextY>=0 && nextY<n && !visited[nextX,nextY]){
           GenerateIt(s,visited,nextX,nextY,val+1,index);           
        }
        else{
             if(index==Directions.Length-1) index=0;
             else index++;
            nextX=x+Directions[index][0];
            nextY=y+Directions[index][1];
            GenerateIt(s,visited,nextX,nextY,val+1,index);
        }       

    }
}