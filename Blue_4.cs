using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public class Blue_4 : Blue
    {
        private int _output;

        public int Output => _output;

        public Blue_4(string input) : base(input)
        {
            _output = 0;
        }

        public override void Review()
        {
            if (string.IsNullOrEmpty(Input)) return;

            int currentNumber = 0;
            bool isNegative = false; //отрицательное?
            bool inNumber = false; //внутри числа?

            foreach (char ch in Input)
            {
                if (ch >= '0' && ch <= '9')
                {
                    if (!inNumber)
                    {
                        inNumber = true;
                        currentNumber = 0;
                    }
                    currentNumber = currentNumber * 10 + (ch - '0'); //разряды, "ch-'0'" преобразует символ в число
                }
                else if (ch == '-' && !inNumber)
                {
                    isNegative = true;
                }
                else
                {
                    if (inNumber)
                    {
                        _output += isNegative ? -currentNumber : currentNumber;
                        isNegative = false;
                        inNumber = false;
                    }
                    isNegative = false; //если не цифра
                }
            }

            // Обработка числа в конце строки
            if (inNumber)
            {
                if (isNegative)
                {
                    _output += -currentNumber;  //отрицательное число
                }
                else
                {
                    _output += currentNumber;   //положительное число
                }
            }
        }

        public override string ToString()
        {
            return $"{_output}";
        }
    }
}

