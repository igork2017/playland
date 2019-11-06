using System;
using System.Collections.Generic;
using System.Drawing;
public class NumberOfEquivalentDominos{
    public void Run(){
             var input = new int [][]{
           new int[]{1,2},
           new int []{1,2},
           new int []{1,1},
           new int []{1,2},
           new int []{2,2},
       };

/*         var input = new int [][]{
           new int []{1,2},
           new int []{2,1},
           new int []{3,4},
           new int []{5,6}       
       }; */
       //Console.WriteLine(NumEquivDominoPairs(input));
       var t=new TreeNode(5);
       t.left=new TreeNode(4);
       t.right=new TreeNode(8);
       t.left.left=new TreeNode(11);
       t.right.left=new TreeNode(17);
       t.right.right=new TreeNode(3);
       SufficientSubset(t,22);
    }

    public int NumEquivDominoPairs(int[][] dominoes) {
        if(dominoes.Length==1) return 0;
        var dict=new Dictionary<Point,int>();
       
        for(int i=0;i<dominoes.Length;i++){
            var t=new Point(dominoes[i][0], dominoes[i][1]);
           var min=Math.Min(t.X,t.Y); 
           var max=Math.Max(t.X, t.Y);
           var newT=new Point(min,max);
           if(dict.ContainsKey(newT)){
               dict[newT]++;
           }
           else{
               dict.Add(newT,1);
           }
        }
        var count=0;
        foreach(var val in dict.Values){
            count+=(val * (val-1))/2;
        }
        return count;
    }

     public TreeNode SufficientSubset(TreeNode root, int limit) {
        IsSufficient(root,limit);
        return root;
    }
    
    private void IsSufficient(TreeNode node, int limit){
        if(node==null) return;
        var sum=0;
        if(node.left!=null){
            sum+=node.left.val;
        }
        if(node.right!=null){
           sum+=node.right.val;
        }
            
        if(sum<limit){
             if(node.left!=null && node.left.val<=sum) node.left=null;   
             if(node.right!=null && node.right.val<=sum) node.right=null;
        }
        IsSufficient(node.left,limit);
        IsSufficient(node.right,limit);
           
    }


}