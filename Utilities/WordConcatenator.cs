namespace SixLetterWord.Utilities
{
    public class WordConcatenator
    {
        private readonly HashSet<string> _words;

        public WordConcatenator(IEnumerable<string> words)
        {
            _words = new HashSet<string>(words.Where(w => w.Length <= 6));
        }

        public List<string> FindCombinations(int maxLength = 6)
        {
            var results = new List<string>();
            var wordList = _words.ToList();

            foreach (var combination in GenerateCombinations(wordList, maxLength))
            {
                string combined = string.Concat(combination);
                if (combined.Length == maxLength && _words.Contains(combined))
                {
                    results.Add($"{string.Join("+", combination)}={combined}");
                }
            }

            return results;
        }

        private IEnumerable<List<string>> GenerateCombinations(List<string> words, int maxLength)
        {
            for (int r = 2; r <= words.Count; r++)
            {
                foreach (var combo in CombinationsRecursive(words, r, maxLength))
                {
                    yield return combo;
                }
            }
        }

        private IEnumerable<List<string>> CombinationsRecursive(List<string> words, int length, int maxLen, List<string> current = null, int start = 0)
        {
            current ??= [];

            if (length == 0)
            {
                if (current.Sum(w => w.Length) <= maxLen)
                    yield return new List<string>(current);
                yield break;
            }

            for (int i = start; i < words.Count; i++)
            {
                current.Add(words[i]);
                if (current.Sum(w => w.Length) <= maxLen)
                {
                    foreach (var combo in CombinationsRecursive(words, length - 1, maxLen, current, i + 1))
                        yield return combo;
                }
                current.RemoveAt(current.Count - 1);
            }
        }
    }
}
