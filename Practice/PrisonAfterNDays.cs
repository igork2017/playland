using System;
using System.Collections.Generic;

public class PrisonAfter {
    public void Run(){
        var cells = new int[]{0,1,0,1,1,0,0,1};
        var N = 7;
        foreach(var t in PrisonAfterNDays(cells,N))
            Console.WriteLine(t);
    }
    public int[] PrisonAfterNDays(int[] cells, int N) {
        var visited=new Dictionary<int,int>();
        var state=0;
        for(int i=0;i<8;i++){
            if(cells[i]>0)
                state^= 1<<i;
        }
        
        while(N>0){
            if(visited.ContainsKey(state)){
                N%=visited[state]-N;
                visited[state]=N;
            }
            else visited.Add(state,N);
            
            if(N>=1){
                N--;
                state=nextDay(state);
            }
        }
        int[] ans = new int[8];
        for (int i = 0; i < 8; ++i) {
            if (((state >> i) & 1) > 0) {
                ans[i] = 1;
            }
        }

        return ans;
    }
    
    public int nextDay(int state) {
        int ans = 0;

        for (int i = 1; i <= 6; ++i) {
            if (((state >> (i-1)) & 1) == ((state >> (i+1)) & 1))             {
                ans ^= 1 << i;
            }
        }

        return ans;
    }
}