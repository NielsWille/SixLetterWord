namespace SixLetterWord.Utilities
{
    public class WordConcatenator
    {
        private readonly HashSet<string> _words;
        private readonly List<string> _wordList;

        public WordConcatenator(IEnumerable<string> words)
        {
            _words = new HashSet<string>(words.Where(w => w.Length <= 6));
            _wordList = _words.ToList();
        }

        public List<string> FindCombinations(int maxLength = 6, int maxWordsInCombination = 3)
        {
            var results = new List<string>();
            var buffer = new List<string>();

            for (int i = 0; i < _wordList.Count; i++)
            {
                Backtrack(i, buffer, 0, maxLength, maxWordsInCombination, results);
            }

            return results;
        }

        private void Backtrack(int index, List<string> currentWords, int currentLength, int maxLength, int maxWords, List<string> results)
        {
            var word = _wordList[index];
            int newLength = currentLength + word.Length;

            if (newLength > maxLength || currentWords.Count + 1 > maxWords)
                return;

            currentWords.Add(word);

            if (newLength == maxLength)
            {
                var combined = string.Concat(currentWords);
                if (_words.Contains(combined))
                {
                    results.Add($"{string.Join("+", currentWords)}={combined}");
                }
            }

            for (int next = index + 1; next < _wordList.Count; next++)
            {
                Backtrack(next, currentWords, newLength, maxLength, maxWords, results);
            }

            currentWords.RemoveAt(currentWords.Count - 1);
        }
    }
}
