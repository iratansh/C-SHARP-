using System;
using System.Linq;
using System.Collections.Generic;
class Program {
    
    static void Main(string[] args) {
        List<int> nums = new List<int>{10, 30, 40, 45, 70, 80, 85, 90, 100};
        List<string> words = new List<string>{"at", "ball", "cat", "dog", "eye", "fish", "good"};
        List<int> unsorted = new List<int>{30, 20, 70, 40, 50, 100, 90};
        unsorted = unsorted.OrderBy(num => num).ToList(); 

        Console.WriteLine(binarySearch(nums, 70));
        Console.WriteLine(binarySearch(words, "cat"));
        Console.WriteLine(binarySearch(unsorted, 100));


    }

    static int binarySearch<T>(List<T> list, T item) {
        int lowerIndex = 0;
        int upperIndex = list.Count - 1;

        while (lowerIndex <= upperIndex) {
            int middleIndex = (lowerIndex + upperIndex) / 2;
            int comparisonResult = Comparer<T>.Default.Compare(item, list[middleIndex]);

            if (comparisonResult == 0) {
                return middleIndex;
            } else if (comparisonResult < 0) {
                upperIndex = middleIndex - 1;
            } else {
                lowerIndex = middleIndex + 1;
            }
        }
        return -1;
    }
}