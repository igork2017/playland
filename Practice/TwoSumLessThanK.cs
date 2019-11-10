using System;

public class TwoSumLessThanK2 {
    public int TwoSumLessThanK(int[] A, int K) {
        if(A.Length<2 || K==0) return -1;

        Array.Sort(A);
        var i=0;
        var j=A.Length-1;
        var result=-1;
        while(i<j){
            var candidate=A[i]+A[j];
            if(candidate<K){
                if(result<candidate) result=candidate;
                i++;
            }
            else j--;
        }
        return result;
    }
}