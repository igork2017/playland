using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

public class RotateImage{
    public void Run(){
        int N = 4; 
        
        // Test Case 1 
        int [][]mat =  
        { 
           new int[] {1, 2, 3, 4}, 
           new int[] {5, 6, 7, 8}, 
           new int[] {9, 10, 11, 12}, 
           new int[] {13, 14, 15, 16} 
        };  
        int[][]mat1={
           new int[] {1, 2, 3, 4}, 
           new int[] {5, 6, 7, 8}, 
           new int[] {9, 10, 11, 12}, 
           new int[] {13, 14, 15, 16}
        };
        displayMatrix(N, mat); 
        
        Rotate(mat); 
        displayMatrix(N, mat);
        
        Rotate2(mat1);
     
        // Print rotated matrix 
        displayMatrix(N, mat1); 
       
    }
    public void Rotate(int[][] matrix) {
        var N=matrix.GetLength(0);
        for(int i=0;i<N/2;i++){
           for(int j=i;j<N-i-1;j++){
              var temp = matrix[i][j];
              //From left to top
              matrix[i][j] = matrix[N-1-j][i];

              //From bottom to left
              matrix[N-1-j][i]= matrix[N-1-i][N-1-j];

              //From right to bottom 
              matrix[N-1-i][N-1-j]=matrix[j][N-1-i];

              //From top to left
              matrix[j][N-1-i]=temp;
           }
        }

    }

    // Function to print the matrix 
    static void displayMatrix(int N, int[][] mat) 
    { 
        for (int i = 0; i < N; i++) 
        { 
            for (int j = 0; j < N; j++) 
                Console.Write(" " + mat[i][j]); 
                Console.WriteLine(); 
        } 
        Console.WriteLine(); 
    } 

    private void Rotate2(int[][] arr){
        transpose(arr);
        displayMatrix(4, arr);
        reverseColumns(arr);
    }
    private void transpose(int[][] arr) 
    { 
        int R=arr.GetLength(0);
        int C= R;
        for (int i = 0; i < R; i++) 
            for (int j = i; j < C; j++) { 
                int temp = arr[j][i]; 
                arr[j][i] = arr[i][j]; 
                arr[i][j] = temp; 
            } 
    }

    static void reverseColumns(int[][] arr) 
    { 
        int R=arr.GetLength(0);
        int C= R;
        for (int i = 0; i < C; i++) 
            for (int j = 0, k = C - 1;j < k; j++, k--) { 
                int temp = arr[i][j]; 
                arr[i][j] = arr[i][k]; 
                arr[i][k] = temp; 
            } 
    } 
   
}