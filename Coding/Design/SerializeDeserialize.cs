using System;
using System.Collections.Generic;

public class SerializeDeserialize{
    public void Run(){
       var root=new TreeNode(1);
       root.left=new TreeNode(2);
       root.right= new TreeNode(3);
       root.left.left=new TreeNode(4);
       root.left.right=new TreeNode(5);
       root.right.left=new TreeNode(6);
       root.right.right=new TreeNode(7);
       var codec= new Codec();
       var resutl = codec.deserialize(codec.serialize(root));
    }
}
public class Codec {

    // Encodes a tree to a single string.
    public string serialize(TreeNode root) {
        return rserialize(root,"");
    }

    public string rserialize(TreeNode root, string str) {
    // Recursive serialization.
    if (root == null) {
      str += "null,";
    } else {
      str += root.val.ToString() + ",";
      str = rserialize(root.left, str);
      str = rserialize(root.right, str);
    }
    return str;
  }
    // Decodes your encoded data to tree.
    public TreeNode deserialize(string data) {
        string[] data_array = data.Split(",");
        List<String> data_list = new List<string>(data_array);
        return rdeserialize(data_list);
    }

    public TreeNode rdeserialize(List<string> l) {
    // Recursive deserialization.
    if (l[0]=="null") {
        l.RemoveAt(0);
        return null;
    }

    TreeNode root = new TreeNode(Int32.Parse(l[0]));
    l.RemoveAt(0);
    root.left = rdeserialize(l);
    root.right = rdeserialize(l);

    return root;
  }
}