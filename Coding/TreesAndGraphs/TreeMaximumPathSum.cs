using System;

public class TreeMaximumSum{
    public void Run(){

    }
    public int Max_sum = Int32.MinValue;
    
    public int maxPathSum(TreeNode root) {
        MaxGain(root);
        return Max_sum;
    }

    public int MaxGain(TreeNode node) {
        if (node == null) return 0;

        var left_gain = Math.Max(MaxGain(node.left), 0);
        var right_gain = Math.Max(MaxGain(node.right), 0);

        int price_newpath = node.val + left_gain + right_gain;
        Max_sum = Math.Max(Max_sum, price_newpath);

        return node.val + Math.Max(left_gain, right_gain);
    }

}