using System;
using System.Collections.Generic;
using System.Drawing;

public class MeetingRoom2{
    public void Run(){}
    

   /*  public int minMeetingRooms(Point[] intervals) {

    // Check for the base case. If there are no intervals, return 0
    if (intervals.Length == 0) {
      return 0;
    }
    var queue =new Queue<int>(intervals.Length)
    PriorityQueue<Integer> allocator =
        new PriorityQueue<Integer>(
            intervals.length,
            new Comparator<Integer>() {
              public int compare(Integer a, Integer b) {
                return a - b;
              }
            });

    // Sort the intervals by start time
    Arrays.sort(
        intervals,
        new Comparator<Interval>() {
          public int compare(Interval a, Interval b) {
            return a.start - b.start;
          }
        });
     // Add the first meeting
    allocator.add(intervals[0].end);

    // Iterate over remaining intervals
    for (int i = 1; i < intervals.length; i++) {

      // If the room due to free up the earliest is free, assign that room to this meeting.
      if (intervals[i].start >= allocator.peek()) {
        allocator.poll();
      }
    
      // If a new room is to be assigned, then also we add to the heap,
      // If an old room is allocated, then also we have to add to the heap with updated end time.
      allocator.add(intervals[i].end);
    }

    // The size of the heap tells us the minimum rooms required for all the meetings.
    return allocator.size();
  }
} */

/*
1. Use Priority Queue for the meeting end time
2. Looping through the intervals and if start meeting great or equal of first item in queue add it to quee and remove previous one
3. 
 */

 /**
 * Definition for an interval. public class Interval { int start; int end; Interval() { start = 0;
 * end = 0; } Interval(int s, int e) { start = s; end = e; } }
 */

  public int MinMeetingRooms(int[][] intervals) {

    // Check for the base case. If there are no intervals, return 0
    if (intervals.Length == 0) {
      return 0;
    }

    int[] start = new int[intervals.Length];
    int[] end = new int[intervals.Length];

    for (int i = 0; i < intervals.Length; i++) {
      start[i] = intervals[i][0];
      end[i] = intervals[i][1];
    }

    // Sort the intervals by end time
    Array.Sort(end);

    // Sort the intervals by start time
    Array.Sort(start);

    // The two pointers in the algorithm: e_ptr and s_ptr.
    int startPointer = 0, endPointer = 0;

    // Variables to keep track of maximum number of rooms used.
    int usedRooms = 0;

    // Iterate over intervals.
    while (startPointer < intervals.Length) {

      // If there is a meeting that has ended by the time the meeting at `start_pointer` starts
      if (start[startPointer] >= end[endPointer]) {
        usedRooms -= 1;
        endPointer += 1;
      }

      // We do this irrespective of whether a room frees up or not.
      // If a room got free, then this used_rooms += 1 wouldn't have any effect. used_rooms would
      // remain the same in that case. If no room was free, then this would increase used_rooms
      usedRooms += 1;
      startPointer += 1;

    }

    return usedRooms;
  }

}