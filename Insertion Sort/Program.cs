using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        List<int> nums =  new List<int>{10, 70, 30, 100, 40, 45, 90, 80, 85};
        List<string> words = new List<string>{"dog","at", "good", "eye", "cat", "ball", "fish"};

        insertionSort(nums);
        insertionSort(words);

        foreach (var num in nums) {
            Console.WriteLine(num);
        } 

        foreach (var el in words) {
            Console.WriteLine(el);
        }
    }

    static void insertionSort<T>(List<T> list) {
        for (int i = 0; i < list.Count; i++) {
            var currVal = list[i];
            var currPos = i - 1;

            while (currPos  >= 0 && Comparer<T>.Default.Compare(list[currPos], currVal) > 0) {
                list[currPos + 1] = list[currPos];
                currPos -= 1;

            }

            list[currPos + 1] = currVal;
        }

    }
}