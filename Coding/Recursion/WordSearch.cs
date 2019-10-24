using System;
using System.Collections.Generic;

public class WordSearch{
    int[] dr = new int[] {-1, 1, 0, 0};
    int[] dc = new int[] {0, 0, -1, 1};
    public void Run(){
        var board=new char[][]{
            new char[]{'A','B','C','E'},
            new char[]{'S','F','E','S'},
            new char[]{'A','D','E','E'}
        }; 
        //var board= new char[][]{new char[]{'A'}};
        var word="ABCESEEEFS";
        Console.WriteLine(Exist(board,word));
    }

    public bool Exist(char[][] board, string word) {
        int rlength=board.Length;
        int clength=board[0].Length;
        if(word.Length==0) return false;       
        var wordArray = word.ToCharArray();
        var startLetter=wordArray[0];
        if(rlength==1 && clength==1 && wordArray.Length==1 && board[0][0]==startLetter) return true;
  
        for(int i=0;i<rlength;i++){
            for(int j=0;j<clength;j++){
                if(board[i][j]==startLetter){                   
                    var result = bsf(board,1,wordArray,i,j);
                    if(result) return true;                    
                }
            }
        }
        return false;
    }

    bool bsf(char[][] board,int index, char[] wordArray,int r, int c){
        if(index==wordArray.Length){
            return true;
        }
        var rlength=board.Length;
        var clength=board[0].Length;
        var next=wordArray[index];
        for(int i=0;i<4;i++){
           var nr=r+dr[i];
           var nc=c+dc[i];
           if(0<=nr&&nr<rlength&&0<=nc&&nc<clength && board[nr][nc]==next)
           {      
               var result=bsf(board,index+1,wordArray,nr,nc);
               if(result) return true;
           }
        }        
        return false;
    }

}