using System;

public static class MagicIndex{
    public static void Run(){
        int[] intArray= new int[]{-2, -1, 0,1, 4, 9};
        Classic(intArray);
        Modern(intArray, 0, 7);
    }

    private static void Classic(int[] intArray){        
        for(int i=0; i<intArray.Length;i++){
            if(intArray[i]==i){
                Console.WriteLine(intArray[i]);
            }
        }
    }

    private static void Modern(int[] intArray, int start, int end){
        if(end<start) Console.WriteLine(-1);
        int middle=(int) (end+start)/2;
        if(intArray[middle]==middle) Console.WriteLine(intArray[middle]);
        if(intArray[middle]>middle) Modern(intArray, start, middle-1);
        if(intArray[middle]<middle) Modern(intArray,middle+1, end);

    }
}