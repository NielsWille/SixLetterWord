using SixLetterWord;
using SixLetterWord.Implementation;
using SixLetterWord.Utilities;

class Program
{
    static void Main()
    {
        ITextFileReader textFileReader = new TextFileReader("input.txt");
        var combiner = new WordConcatenator(textFileReader.GetWords());
        var results = combiner.FindCombinations();

        foreach (var result in results)
        {
            Console.WriteLine(result);
        }
    }
}