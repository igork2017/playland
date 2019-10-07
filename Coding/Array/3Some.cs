using System;
using System.Collections.Generic;

public class To3Some{
    public void Run(){
        var test = new int[]{-1, 0, 1, 2, -1, -4};
        var test2 = new int[]{0,0,0};
        var result=Get3Some(test2);
        foreach(var t in result){
            Console.WriteLine("new list: ");
            foreach (var m in t)
                Console.WriteLine(m);
        }  
    }
    public IList<IList<int>> Get3Some(int[] nums){
        var s=0;
        var result=new List<IList<int>>();
        if(nums.Length<3) return result;
        
        var triplet=new List<int>();
        if(nums.Length==3){
           var a = nums[0];
           var b = nums[1];
           var c = nums[2];    
            if((a+b+c)==0) {
                result.Add(GetTriplet(nums[0], nums[1], nums[2]));
               return result;
            }
            else {
                return result;
            }
        }

        Array.Sort(nums);
        for(int i=0; i<nums.Length-3;i++){
            if(i>0 && nums[i]==nums[i-1]) continue;
            int r=nums.Length-1;
            int l=i+1;
            while(l<r){
                s=nums[i]+nums[l]+nums[r];
                if(s==0 && !isTripleExists(nums[i], nums[l], nums[r], triplet)){  
                    triplet=GetTriplet(nums[i], nums[l], nums[r]);                   
                    result.Add(triplet);
                    l++;
                    r--;
                }
                if(s>0){
                    r--;
                }
                if(s<0){
                    l++;
                }
            }
        }
        return result;
    }
    
    private bool isTripleExists(int ivalue, int lvalue, int rvalue, List<int> triplet){
        if(triplet.Count==3 && ivalue==triplet[0] && lvalue==triplet[1] && rvalue==triplet[2]) return true;
        return false;
    }

    private List<int> GetTriplet(int ivalue, int lvalue, int rvalue){
        var triplet=new List<int>();                   
        triplet.Add(ivalue);
        triplet.Add(lvalue);
        triplet.Add(rvalue);
        return triplet;
    }
}
