using System;
using System.Collections.Generic;
using System.Drawing;

public static class Robot{
    public static void Run(){
        var failedPointList=new List<Point>();
        var row=5;
        var col=5;
        bool[,] matrix=new bool[row,col];
        for(int i=0; i<row;i++){
            for(int j=0;j<col;j++){
                if(i==2 && j==0){
                    matrix[i,j]=false;
                }
                else{
                    matrix[i,j]=true;
                }
            }
        }
        var path = new List<Point>();
        GetPath(matrix,col-1, row-1, path, failedPointList);
        foreach(var p in path){
            Console.WriteLine($"x: {p.X}, y: {p.Y}");
        }            
    }

    public static bool GetPath(bool[,] matrix, int col, int row, List<Point> path, List<Point> fails){
       if(col<0 || row<0 || !matrix[row,col]) return false;
       var p=new Point{X=col, Y=row};
       if(fails.Contains(p)){
           return false;
       }
       bool IsOrigin= (col==0) && (row==0);
       if(IsOrigin || GetPath(matrix, col-1, row, path,fails) || GetPath(matrix, col, row-1, path, fails)){
           path.Add(p);
           return true;
       }
       fails.Add(p);
       return false;
    }
   
}