// LeetCode 1636 - Sort Array by Increasing Frequency
// Approach: Bucket sort by frequency + custom sorting inside buckets
//
// Idea:
// 1. Count frequency of each number using dictionary.
// 2. Create buckets indexed by frequency; each bucket stores numbers with that frequency.
// 3. Iterate buckets from lowest frequency to highest.
// 4. Inside each bucket, sort numbers in descending order.
// 5. Fill result array by repeating each number frequency times.
//
// Time Complexity: O(n log n) due to sorting inside buckets
// Space Complexity: O(n)

public class Solution {
    public int[] FrequencySort(int[] nums) {
        // Step 1: Frequency map
        Dictionary<int, int> freq = new Dictionary<int, int>();
        foreach (int num in nums) {
            if (freq.ContainsKey(num)) {
                freq[num]++;
            } else {
                freq[num] = 1;
            }
        }

        // Step 2: Bucket by frequency
        List<int>[] bucket = new List<int>[nums.Length + 1];
        foreach (var pair in freq) {
            int frequency = pair.Value;
            if (bucket[frequency] == null) {
                bucket[frequency] = new List<int>();
            }
            bucket[frequency].Add(pair.Key);
        }

        // Step 3: Build result array
        int[] arr = new int[nums.Length];
        int idx = 0;
        // Iterate from smallest frequency to largest
        for (int i = 0; i < bucket.Length; i++) {
            if (bucket[i] != null) {
                // Sort numbers in descending order inside the bucket
                bucket[i].Sort((a, b) => b - a);

                foreach (int num in bucket[i]) {
                    for (int count = 0; count < i; count++) {
                        arr[idx++] = num;
                    }
                }
            }
        }
        return arr;
    }
}
