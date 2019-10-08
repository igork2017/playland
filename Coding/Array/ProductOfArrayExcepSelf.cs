using System;

public class ProductOfArray{
    public void Run(){
        var input = new int[]{1,2,3,4};
        foreach(var t in ProductExceptSelf(input)){
            Console.WriteLine(t);
        }
    }
    public int[] ProductExceptSelf(int[] nums) {
        var length=nums.Length;
        var result = new int[length];
        result[0]=1;
        for(int i=1; i<length;i++){
            result[i]=result[i-1] * nums[i-1];
        }

        int R=1;
        for(int j=length-1;j>=0;j--){
           result[j] = R * result[j];
           R=R * nums[j];
        }
        
        return result;
    }
}