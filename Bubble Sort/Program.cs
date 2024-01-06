using System;
using System.Collections.Generic;

class Program {
    static void Main(string[] args) {
        List<int> nums =  new List<int>{10, 70, 30, 100, 40, 45, 90, 80, 85};
        List<string> words = new List<string>{"dog","at", "good", "eye", "cat", "ball", "fish"};

        bubbleSort(nums);
        bubbleSort(words);

        foreach (var num in nums) {
            Console.WriteLine(num);
        } 

        foreach (var el in words) {
            Console.WriteLine(el);
        }
    }

    static void bubbleSort<T>(List<T> list) {
        for (int i = 0; i < list.Count; i++) {
            for (int j = 0; j < list.Count - i - 1; j++) {
                if (Comparer<T>.Default.Compare(list[j], list[j + 1]) > 0) {
                    var temp = list[j];
                    list[j] = list[j + 1];
                    list[j + 1] = temp;
                }
            }
        }
    }
}