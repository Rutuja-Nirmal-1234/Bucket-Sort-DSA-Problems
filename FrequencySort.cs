// LeetCode 451 - Sort Characters By Frequency
// Approach: Bucket Sort based on character frequencies
//
// Idea:
// 1. Count frequency of each character using a dictionary.
// 2. Use buckets where index = frequency, each bucket contains characters with that frequency.
// 3. Iterate buckets from highest frequency to lowest, build the result string.
//
// Time Complexity: O(n)
// Space Complexity: O(n)

public class Solution {
    public string FrequencySort(string s) {
        Dictionary<char, int> freq = new Dictionary<char, int>();

        // Step 1: Count frequency of each character
        foreach (char ch in s) {
            if (freq.ContainsKey(ch)) {
                freq[ch]++;
            } else {
                freq[ch] = 1;
            }
        }

        // Step 2: Bucket sort based on frequencies
        List<char>[] bucket = new List<char>[s.Length + 1];
        foreach (var pair in freq) {
            int count = pair.Value;
            if (bucket[count] == null) {
                bucket[count] = new List<char>();
            }
            bucket[count].Add(pair.Key);
        }

        // Step 3: Build the result string from buckets
        StringBuilder sb = new StringBuilder();
        for (int i = bucket.Length - 1; i >= 0; i--) {
            if (bucket[i] != null) {
                foreach (char ch in bucket[i]) {
                    sb.Append(new string(ch, i));
                }
            }
        }
        return sb.ToString();
    }
}
