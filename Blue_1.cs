using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_1 : Blue
    {
        private string[] _output;
        public string[] Output => _output;
        public Blue_1(string input) : base(input)
        {
            _output = null;
        }
        public override void Review()
        {
            if (string.IsNullOrEmpty(Input))
            {
                _output = new string[0];
                return;
            }

            string text = Input;
            int count = 0;
            int current = 0;

            //колво строк считаем
            while (current < text.Length)
            {
                int charsLeft = text.Length - current;
                if (charsLeft <= 50)
                {
                    count++;
                    break;
                }

                int next = current + 50;
                int lastSpace = text.LastIndexOf(' ', next, 50);

                if (lastSpace <= current) //если нет пробела берем ровно 50
                {
                    current += 50;
                }
                else //перенос по ласт пробелу
                {
                    current = lastSpace + 1;
                }
                count++;
            }

            //создаем массив из строк по полученному колву
            _output = new string[count];
            current = 0;
            for (int i = 0; i < count; i++)
            {
                int charsLeft= text.Length - current;
                if (charsLeft <= 50) //если меньше 50 то берем всю оставшуюся строку и выходим
                {
                    _output[i] = text.Substring(current);
                    break;
                }

                int next = current + 50;
                int lastSpace = text.LastIndexOf(' ', next, 50);

                if (lastSpace <= current) //нет пробела-берем ровно 50 и сдвигаем текущюю позицию на 50
                {
                    _output[i] = text.Substring(current, 50);
                    current += 50;
                }
                else //если есть до берем с текущего до ласт пробела и сдвигаем текущее за пробел
                {
                    _output[i] = text.Substring(current, lastSpace - current);
                    current = lastSpace + 1;
                }
            }
        }
        public override string ToString()
        {
            return _output.Length == 0 || _output==null ? string.Empty : string.Join(Environment.NewLine, _output);
        }
    }
}