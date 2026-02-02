// LeetCode 692 - Top K Frequent Words
// Approach: Bucket Sort + Sorting within buckets lex order
//
// Idea:
// 1. Count frequency of each word using a dictionary.
// 2. Create buckets where index = frequency, each bucket stores words with that frequency.
// 3. Iterate buckets from highest frequency to lowest.
// 4. Sort words lexicographically inside each bucket before adding to result.
// 5. Return top k words.
//
// Time Complexity: O(n log n) in worst case due to sorting within buckets
// Space Complexity: O(n)

public class Solution {
    public IList<string> TopKFrequent(string[] words, int k) {

        // Step 1: Count frequency of each word
        Dictionary<string, int> freq = new Dictionary<string, int>();
        foreach (string word in words) {
            if (freq.ContainsKey(word)) {
                freq[word]++;
            } else {
                freq[word] = 1;
            }
        }

        // Step 2: Bucket sort by frequency
        List<string>[] bucket = new List<string>[words.Length + 1];
        foreach (var pair in freq) {
            int count = pair.Value;
            if (bucket[count] == null) {
                bucket[count] = new List<string>();
            }
            bucket[count].Add(pair.Key);
        }

        // Step 3: Collect top k frequent words
        List<string> res = new List<string>();
        for (int i = bucket.Length - 1; i >= 0 && res.Count < k; i--) {
            if (bucket[i] != null) {
                // Sort lexicographically within same frequency
                bucket[i].Sort(StringComparer.Ordinal);
                foreach (string word in bucket[i]) {
                    res.Add(word);
                    if (res.Count == k) {
                        return res;
                    }
                }
            }
        }

        return res;
    }
}
