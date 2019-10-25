using System;

public class SearchInRotated {

public void Run(){
   var nums =new int[] {4,5,6,7,0,1,2};
   var target = 0;
   Console.WriteLine(Search(nums,target));
}

public int Search(int[] nums, int target) {

    int n = nums.Length;

    if (n == 0)
      return -1;
    if (n == 1)
      return nums[0] == target ? 0 : -1;

    int rotate_index = find_rotate_index(nums, 0, n - 1);

    // if target is the smallest element
    if (nums[rotate_index] == target)
      return rotate_index;
    // if array is not rotated, search in the entire array
    if (rotate_index == 0)
      return search(nums, 0, n - 1, target);
    if (target < nums[0])
      // search in the right side
      return search(nums, rotate_index, n - 1, target);
    // search in the left side
    return search(nums, 0, rotate_index,target);    
}
  public int find_rotate_index(int[] nums, int left, int right) {
    if (nums[left] < nums[right])
      return 0;

    while (left <= right) {
      int pivot = (left + right) / 2;
      if (nums[pivot] > nums[pivot + 1])
        return pivot + 1;
      else {
        if (nums[pivot] < nums[left])
          right = pivot - 1;
        else
          left = pivot + 1;
      }
    }
    return 0;
  }

  public int search(int[] nums, int left, int right, int target) {
    /*
    Binary search
    */
    while (left <= right) {
      int pivot = (left + right) / 2;
      if (nums[pivot] == target)
        return pivot;
      else {
        if (target < nums[pivot])
          right = pivot - 1;
        else
          left = pivot + 1;
      }
    }
    return -1;
  }

 
}