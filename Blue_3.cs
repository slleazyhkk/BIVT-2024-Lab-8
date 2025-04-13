using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_3 : Blue
    {
        private (char, double)[] _output;

        public (char, double)[] Output
        {
            get
            {
                if (_output == null) return null;
                (char, double)[] copy = new (char, double)[_output.Length];
                Array.Copy(_output,copy, copy.Length);
                return copy;
            }
        }

        public Blue_3(string input) : base(input)
        {
            _output = null;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = null;
                return;
            }

            char[] separators = { ' ', '.', '!', '?', ',', ':', '\"', ';', '–', '(', ')', '[', ']', '{', '}', '/' };
            string[] words = Input.Split(separators, StringSplitOptions.RemoveEmptyEntries);

            int[] letterCounts = new int[char.MaxValue];
            int wordsCounts = 0;

            foreach (string word in words)
            {
                if (word.Length == 0) continue;

                char firstChar = char.ToLower(word[0]);
                if (char.IsLetter(firstChar))
                {
                    letterCounts[firstChar]++;
                    wordsCounts++;
                }
            }

            int uniqueLettersCnt = 0;
            for (int i = 0; i < letterCounts.Length; i++)
            {
                if (letterCounts[i] > 0) uniqueLettersCnt++;
            }

            _output = new (char, double)[uniqueLettersCnt];
            int index = 0;

            for (int i = 0; i < letterCounts.Length; i++)
            {
                if (letterCounts[i] > 0)
                {
                    double result = Math.Round(letterCounts[i] * 100.0 / wordsCounts, 4);
                    _output[index++] = ((char)i, result);
                }
            }

            Array.Sort(_output, (x, y) =>
            {
                int cmp = y.Item2.CompareTo(x.Item2);
                return cmp != 0 ? cmp : x.Item1.CompareTo(y.Item1);
            });
        }

        public override string ToString()
        {
            if (_output == null || _output.Length == 0) return "";

            var str = new StringBuilder();
            foreach (var x in _output)
            {
                str.AppendLine($"{x.Item1} - {x.Item2:F4}");
            }
            return str.ToString();
        }
    }
}
