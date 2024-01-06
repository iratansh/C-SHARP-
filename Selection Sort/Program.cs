using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        List<int> nums =  new List<int>{10, 70, 30, 100, 40, 45, 90, 80, 85};
        List<string> words = new List<string>{"dog","at", "good", "eye", "cat", "ball", "fish"};

        selectionSort(nums);
        selectionSort(words);

        foreach (var num in nums) {
            Console.WriteLine(num);
        } 

        foreach (var el in words) {
            Console.WriteLine(el);
        }
    }

    static void selectionSort<T>(List<T> list) {
        for (int i = 0; i < list.Count; i++) {
            int minIndex = i;
            for (int j = i + 1; j <list.Count; j++) {
                if (Comparer<T>.Default.Compare(list[j], list[minIndex]) < 0) {
                    minIndex = j;
                } 
            }
            T temp = list[minIndex];
            list[minIndex] = list[i];
            list[i] = temp;
        }
    }

}