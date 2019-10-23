using System;
using System.Collections.Generic;
using System.Linq;

public class CutOffTrees{
    int[] dr = new int[] {-1, 1, 0, 0};
    int[] dc = new int[] {0, 0, -1, 1};
    public void Run(){
        var input= new List<IList<int>>{
            new List<int>{1,2,3},
            new List<int>{0,0,0},
            new List<int>{7,6,5}
        };

        Console.WriteLine(CutOffTree(input));
    }
    public int CutOffTree(IList<IList<int>> forest) {
       var R=forest.Count;
       var C=forest[0].Count;
       var trees=new List<IList<int>>();
       for(int r=0;r<R;r++){
           for(int c=0;c<C;c++){
               if(forest[r][c]>1)
                 trees.Add(new List<int>{forest[r][c],r,c});
           }
       }
       var treesSorted= trees.OrderBy(t=>t[0]).ToList();
       var total_steps=0;
       var sr=0;
       var sc=0;
       for(int i=0;i<treesSorted.Count;i++){
           var tr=treesSorted[i][1];
           var tc=treesSorted[i][2];
          
           var steps=bfs(forest,sr,sc, tr,tc);
           if(steps==-1) return -1;
           forest[tr][tc]=1;
           total_steps+=steps;
           sr=tr;
           sc=tc;
       }
       return total_steps;
    }

    public int bfs(IList<IList<int>> forest, int r, int c,int tr, int tc){
        var R=forest.Count;
        var C=forest[0].Count;
        var queue=new Queue<int[]>();
        queue.Enqueue(new int[]{r,c,0});
        var visited=new bool[R, C];
        visited[r,c]=true;
        while(queue.Count>0){
            var cur= queue.Dequeue();
            if(cur[0]==tr && cur[1]==tc) return cur[2];
            for (int di = 0; di < 4; di++) {
            int nr = cur[0] + dr[di];
            int nc = cur[1] + dc[di];
                if (0 <= nr && nr < R && 0 <= nc && nc < C && !visited[nr,nc] && forest[nr][nc] > 0) {
                    visited[nr,nc] = true;
                    queue.Enqueue(new int[]{nr, nc, cur[2]+1});
                }
            }
        }
        return -1;
    }   

}