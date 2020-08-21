using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Linq;

namespace _04___Merge_Intervals
{
    class Program
    {
        static void Main(string[] args)
        {
            //arr1=[[1, 3], [5, 6], [7, 9]], arr2=[[2, 3], [5, 7]]
            int[][] A = new int[3][];
            A[0] = new int[] { 1, 3 };
            A[1] = new int[] { 5, 6 };
            A[2] = new int[] { 7, 9 };

            int[][] B = new int[2][];
            B[0] = new int[] { 2, 3 };
            B[1] = new int[] { 5, 7 };
            var test = IntervalIntersection(A, B);
        }

        //Merge Intervals (medium) https://leetcode.com/problems/merge-intervals/
        public static int[][] Merge(int[][] intervals)
        {
            if (intervals.Length == 0)
            {
                return intervals;
            }
            intervals.OrderBy(i => i[0]);
            List<List<int>> listOfLists = new List<List<int>>();
            var start = intervals[0][0];
            var end = intervals[0][1];
            for (int i = 1; i < intervals.Length; i++)
            {
                var currStart = intervals[i][0];
                var currEnd = intervals[i][1];
                if (currStart <= end)
                {
                    end = Math.Max(end, currEnd);
                }
                else
                {
                    listOfLists.Add(new List<int>() { start, end });
                    start = currStart;
                    end = currEnd;
                }
            }
            listOfLists.Add(new List<int>() { start, end });
            int[][] arrays = listOfLists.Select(a => a.ToArray()).ToArray();
            return arrays;
        }
        //Insert Interval (medium) https://leetcode.com/problems/insert-interval/
        //Notes: a more efficient solution exist;
        public static int[][] Insert(int[][] intervals, int[] newInterval)
        {
            var ins = intervals.Append(new int[2] { newInterval[0], newInterval[1] });
            var newIntervals = ins.OrderBy(i => i[0]).ToArray();
            var start = newIntervals[0][0];
            var end = newIntervals[0][1];
            List<List<int>> listOfIntervals = new List<List<int>>();
            for (int i = 1; i < newIntervals.Length; i++)
            {
                var currStart = newIntervals[i][0];
                var currEnd = newIntervals[i][1];
                if (currStart <= end)
                {
                    end = Math.Max(end, currEnd);
                }
                else
                {
                    listOfIntervals.Add(new List<int>() { start, end });
                    start = currStart;
                    end = currEnd;
                }
            }
            listOfIntervals.Add(new List<int>() { start, end });
            int[][] arrays = listOfIntervals.Select(a => a.ToArray()).ToArray();
            return arrays;
        }

        //Intervals Intersection (medium)https://leetcode.com/problems/interval-list-intersections/
        //Notes: solution is not right
        public static int[][] IntervalIntersection(int[][] A, int[][] B)
        {
            List<List<int>> intersections = new List<List<int>>();
            var AStart = A[0][0];
            var AEnd = A[0][1];
            var BStart = B[0][0];
            var BEnd = B[0][1];
            int start = 0;
            int end = 0;
            if (BStart <= AEnd)
            {
                start = Math.Min(AStart, BStart);
                end = Math.Max(AEnd, BEnd);
                intersections.Add(new List<int>() { start, end });
            }
            int a = 1;
            int b = 1;
            while (a < A.Length && b < B.Length)
            {
                var aStart = A[a][0];
                var aEnd = A[a][1];
                var bStart = B[b][0];
                var bEnd = B[b][1];
                if (bStart <= aEnd)
                {
                    start = Math.Min(aStart, BStart);
                    end = Math.Max(aEnd, BEnd);
                    intersections.Add(new List<int>() { start, end });
                }
                a++;
                b++;
            }
            var arrays = intersections.Select(a => a.ToArray()).ToArray();
            return arrays;
        }

        //Conflicting Appointments (medium) https://leetcode.com/problems/meeting-rooms/
        public static bool CanAttendMeetings(int[][] intervals)
        {
            var ins = intervals.OrderBy(i => i[0]).ToArray();
            var start = intervals[0][0];
            var end = intervals[0][1];
            for (int i = 1; i < ins.Length; i++)
            {
                var currStart = intervals[i][0];
                var currEnd = intervals[i][1];
                if (currStart <= end)
                {
                    return false;
                }
                else
                {
                    start = currStart;
                    end = currEnd;
                }
            }
            return true;
        }

        //Minimum Meeting Rooms (hard) https://leetcode.com/problems/meeting-rooms-ii/
        public static int MinMeetingRooms(int[][] intervals)
        {
            var ins = intervals.OrderBy(i => i[0]).ToArray();
            var start = intervals[0][0];
            var end = intervals[0][1];
            int rooms = 1;
            for (int i = 1; i < ins.Length; i++)
            {
                var currStart = intervals[i][0];
                var currEnd = intervals[i][1];
                if (currStart <= end)
                {
                    end = Math.Max(end, currEnd);
                    rooms++;
                }
                else
                {
                    start = currStart;
                    end = currEnd;
                    rooms--;
                }
            }
            return rooms;
        }
    }
}
