using System;
using System.Linq;
using System.Collections.Generic;

public class Maze2{
    int[][] dirs=new int[][]{
        new int []{0,1},
        new int []{0,-1},
        new int []{-1,0},
        new int []{1,0}
    };
    public void Run(){
/*          var input= new int[][]{
            new int[]{0,0,1,0,0},
            new int[]{0,0,0,0,0},
            new int[]{0,0,0,1,0},
            new int[]{1,1,0,1,1},
            new int[]{0,0,0,0,0}
        };
        var start=new int[]{0,4};
        var destination = new int[]{4,4}; */
         var input= new int[][]{
            new int[]{0,0,1,0,0}
        };
        var start=new int[]{0,1};
        var destination = new int[]{0,3};
        
        Console.WriteLine(ShortestDistance(input,start,destination));
    }
    public int ShortestDistance(int[][] maze, int[] start, int[] destination) {
        int[][] distance = new int[maze.Length][];
        for(int i=0;i<distance.Length;i++){
            distance[i] = Enumerable.Repeat(Int32.MaxValue,maze[0].Length).ToArray();            
        }

        distance[start[0]][start[1]] = 0;
        
        var queue = new Queue<int[]>();
        queue.Enqueue(start);
        while (queue.Count>0) {
            int[] s = queue.Dequeue();
            foreach (var dir in dirs) {
                int x = s[0] + dir[0];
                int y = s[1] + dir[1];
                int count = 0;
                while (x >= 0 && y >= 0 && x < maze.Length && y < maze[0].Length && maze[x][y] == 0) {
                    x += dir[0];
                    y += dir[1];
                    count++;
                }
                if (distance[s[0]][s[1]] + count < distance[x - dir[0]][y - dir[1]]) {
                    distance[x - dir[0]][y - dir[1]] = distance[s[0]][s[1]] + count;
                    queue.Enqueue(new int[] {x - dir[0], y - dir[1]});
                }
            }
        }
        return distance[destination[0]][destination[1]] == Int32.MaxValue ? -1 : distance[destination[0]][destination[1]];
    }
}