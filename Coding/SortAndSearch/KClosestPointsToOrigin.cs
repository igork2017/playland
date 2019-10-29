using System;
using System.Collections.Generic;
using System.Drawing;

public class KClosestPoints{
    
    int[][] points;
    Random random=new Random();
    public void Run(){
        var points =new int[][]{
            new int[]{3,3},
            new int[]{5,-1},
            new int[]{-2,4}
        };
        var K = 2;
        var result=KClosest(points,K);
        foreach(var i in result)
            Console.WriteLine("{0},{1}",i[0],i[1]);
    }
    public int[][] KClosest(int[][] points, int K) {
       this.points = points;
        sort(0, points.Length - 1, K);
        var result=new List<int[]>();
        for(int i=0; i<K;i++)
            result.Add(points[i]);
        return result.ToArray();
    }
    
    public int dist(int[] point) {
        return point[0] * point[0] + point[1] * point[1];
    }

    

    public void sort(int i, int j, int K) {
        if (i >= j) return;
        int k = random.Next(i, j);
        swap(i, k);

        int mid = partition(i, j);
        int leftLength = mid - i + 1;
        if (K < leftLength)
            sort(i, mid - 1, K);
        else if (K > leftLength)
            sort(mid + 1, j, K - leftLength);
    }

    public int partition(int i, int j) {
        int oi = i;
        int pivot = dist(i);
        i++;

        while (true) {
            while (i < j && dist(i) < pivot)
                i++;
            while (i <= j && dist(j) > pivot)
                j--;
            if (i >= j) break;
            swap(i, j);
        }
        swap(oi, j);
        return j;
    }

    public int dist(int i) {
        return points[i][0] * points[i][0] + points[i][1] * points[i][1];
    }

    public void swap(int i, int j) {
        int t0 = points[i][0], t1 = points[i][1];
        points[i][0] = points[j][0];
        points[i][1] = points[j][1];
        points[j][0] = t0;
        points[j][1] = t1;
    }

     public int[][] KClosest2(int[][] points, int K) {
        int N = points.Length;
        int[] dists = new int[N];
        for (int i = 0; i < N; ++i)
            dists[i] = dist(points[i]);

        Array.Sort(dists);
        int distK = dists[K-1];

        int[][] ans = new int[K][];
        int t = 0;
        for (int i = 0; i < N; ++i)
            if (dist(points[i]) <= distK)
                ans[t++] = points[i];
        return ans;
    }


}