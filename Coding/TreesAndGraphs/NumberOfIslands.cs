using System;

public class NumberOfIslands{
    public void Run(){
        var grid= new char[][]{
            new char[]{'1','1','1','1','0'},
            new char[]{'1','1','0','1','0'},
            new char[]{'1','1','0','0','0'},
            new char[]{'0','0','0','0','0'}
        };

        Console.WriteLine(NumIslands(grid));
    }

    public int NumIslands(char[][] grid) {
          if(grid.Length==0) return 0;
          var num=0;
          var r= grid.Length;
          var k= grid[0].Length;
          for(int i=0;i<r;i++){
              for(int j=0;j<k;j++){
                  if(grid[i][j]=='1'){
                      num++;
                      ConvertLandToWater(grid,i,j);
                  }
              }
          }   
        return num;
    }

    void ConvertLandToWater(char[][] grid,int i, int j){
        grid[i][j]='0';
        var r= grid.Length;
         var k= grid[0].Length;
        if (i - 1 >= 0 && grid[i-1][j] == '1') ConvertLandToWater(grid, i - 1, j);
        if (i + 1 < r && grid[i+1][j] == '1') ConvertLandToWater(grid, i + 1, j);
        if (j - 1 >= 0 && grid[i][j-1] == '1') ConvertLandToWater(grid, i, j - 1);
        if (j + 1 < k && grid[i][j+1] == '1') ConvertLandToWater(grid, i, j + 1);
    }
}
