// LeetCode 347 - Top K Frequent Elements
// Approach: Bucket Sort based on frequencies
//
// Idea:
// 1. Count frequencies using a dictionary.
// 2. Create buckets where index = frequency, and each bucket holds numbers with that frequency.
// 3. Traverse buckets from high to low frequency to collect top k frequent elements.
//
// Time Complexity: O(n) average
// Space Complexity: O(n)

public class Solution {
    public int[] TopKFrequent(int[] nums, int k) {
        Dictionary<int, int> freq = new Dictionary<int, int>();

        // Step 1: Frequency count
        foreach (int num in nums) {
            if (freq.ContainsKey(num)) {
                freq[num]++;
            } else {
                freq[num] = 1;
            }
        }

        // Step 2: Bucket sort by frequency
        List<int>[] bucket = new List<int>[nums.Length + 1];
        foreach (var pair in freq) {
            int count = pair.Value;
            if (bucket[count] == null) {
                bucket[count] = new List<int>();
            }
            bucket[count].Add(pair.Key);
        }

        // Step 3: Collect top k frequent elements from buckets
        List<int> res = new List<int>();
        for (int i = bucket.Length - 1; i >= 0 && res.Count < k; i--) {
            if (bucket[i] != null) {
                foreach (int num in bucket[i]) {
                    res.Add(num);
                    if (res.Count == k) {
                        return res.ToArray();
                    }
                }
            }
        }

        return res.ToArray();
    }
}
