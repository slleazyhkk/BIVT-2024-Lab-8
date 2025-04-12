using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_2 : Blue
    { 
        private string _output;
        private string _sequence;

        public string Output => _output;

        public Blue_2(string input, string sequence) : base(input)
        {
            _sequence = sequence;
            _output = null;
        }
        public override void Review()
        {
            if (string.IsNullOrEmpty(Input) || string.IsNullOrEmpty(_sequence))
            {
                _output = string.Empty;
                return;
            }

            _output = Input;
            int current = 0;

            while (current < _output.Length)
            {
                //п(р)опускаем небуквы
                while (current < _output.Length && !char.IsLetter(_output[current]))
                {
                    current++;
                }

                if (current >= _output.Length) break;

                //начало и конеу слова
                int wordStart = current;
                while (current < _output.Length &&
                      (char.IsLetter(_output[current]) ||
                      _output[current] == '\'' ||
                      _output[current] == '-'))
                {
                    current++;
                }
                int wordEnd = current - 1;

                //проверочка на наличие последовательности
                string word = _output.Substring(wordStart, wordEnd - wordStart + 1);
                if (word.IndexOf(_sequence, StringComparison.OrdinalIgnoreCase) >= 0)
                {
                    //удаляем слово и лишние пробелы
                    _output = _output.Remove(wordStart, wordEnd - wordStart + 1);

                    //удаляем лишний пробел перед или после слова
                    if (wordStart > 0 && char.IsWhiteSpace(_output[wordStart - 1]))
                    {
                        _output = _output.Remove(wordStart - 1, 1);
                        current = wordStart - 1;
                    }
                    else if (wordStart < _output.Length && char.IsWhiteSpace(_output[wordStart]))
                    {
                        _output = _output.Remove(wordStart, 1);
                        current = wordStart;
                    }
                    else
                    {
                        current = wordStart;
                    }
                }
                else
                {
                    current = wordEnd + 1;
                }
            }

            //удаляем двойные пробелы
            string result = "";
            bool wasSpace = false;

            foreach (char c in _output)
            {
                if (char.IsWhiteSpace(c))
                {
                    if (!wasSpace)
                    {
                        result += " ";
                        wasSpace = true;
                    }
                }
                else
                {
                    result += c;
                    wasSpace = false;
                }
            }
            _output = result.Trim();
        }

        public override string ToString()
        {
            return _output.Length == 0 || String.IsNullOrEmpty(_output)? string.Empty : _output;
        }
    }
}
