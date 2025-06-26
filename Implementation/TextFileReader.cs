namespace SixLetterWord.Implementation
{
    public class TextFileReader : ITextFileReader
    {
        private readonly string _path;

        public TextFileReader(string path)
        {
            _path = path;
        }

        public IEnumerable<string> GetWords()
        {
            return File.ReadAllLines(_path);
        }
    }
}
