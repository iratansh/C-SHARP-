using System;
using System.Collections.Generic;

class Program {
    
    static void Main(string[] args) {
        List<int> nums = new List<int>{10, 30, 40, 45, 70, 80, 85, 90, 100};
        List<string> words = new List<string>{"at", "ball", "cat", "dog", "eye", "fish", "good"};
        List<int> unsorted = new List<int>{30, 20, 70, 40, 50, 100, 90};

        Console.WriteLine(linearSearch(nums, 70));
        Console.WriteLine(linearSearch(words, "cat"));
        Console.WriteLine(linearSearch(unsorted, 100));


    }

    static int linearSearch<T>(List<T> list, T item) {
        for (int i = 0; i < list.Count; i++) {
            if (EqualityComparer<T>.Default.Equals(list[i], item)) {
                return i;
            }
        }
        return -1;
    }
        

}

