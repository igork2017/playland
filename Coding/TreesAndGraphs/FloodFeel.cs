using System;
using System.Collections.Generic;

public class FoodFeel{
    int[] dr = new int[] {-1, 1, 0, 0};
    int[] dc = new int[] {0, 0, -1, 1};
    public void Run(){
         var input= new int[][]{
            new int[]{1,1,1},
            new int[]{1,1,0},
            new int[]{1,0,1}
        };
        var result = FloodFill(input, 0,0,3);
        foreach(var r in result){
            Console.WriteLine("{0} {1} {2}",r[0],r[1],r[2]);
        }
    }

    public int[][] FloodFill(int[][] image, int sr, int sc, int newColor) {
        dfs(image,sr,sc,newColor);
        return image;
    } 

    public void dfs(int[][] image, int sr, int sc, int newColor){
        if(image[sr][sc]==newColor) return;
        var oldColor=image[sr][sc];
        var rLength=image.Length;
        var cLength=image[0].Length;
        
        var visited= new List<int[]>();
        image[sr][sc]=newColor;
        var startPoint=new int[]{sr,sc};
        visited.Add(startPoint);

        var stack=new Stack<int[]>();
        stack.Push(startPoint);
        while(stack.Count>0){
            var cur=stack.Pop();
            for(int i=0; i<4;i++){
                var nr=cur[0] + dr[i];
                var nc=cur[1] + dc[i];
                var newPoint=new int[]{nr,nc};
                if(0<=nr&& nr<rLength && 0<=nc && nc<cLength && !visited.Contains(newPoint) && image[nr][nc]==oldColor){
                    image[nr][nc]=newColor;
                    visited.Add(newPoint);
                    stack.Push(newPoint);
                }
            }
        }
    }
}