using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

public class RotateImege{
    public void Run(){

    }
    public void Rotate(int[][] matrix) {
        var length=matrix[0].Length;
        var processedItems=new List<Tuple<int,int>>();
        for(int i=0;i<length;i++){
           for(int j=0;j<length;j++){
               newmatrix[i,j] = matrix[i][length-1 -j];
           }
        }

    }
}