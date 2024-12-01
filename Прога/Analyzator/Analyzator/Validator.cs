using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;

namespace Analyzator
{
    public static class Validator
    {
        public static string OperatorValidator(string source, ref int startPos)
        {
            source = source.ToLower();
            string resStr = ""; //строка вывода результата 

            char cur;

            string one_const = "";
            string two_const = "";

            string main_const = "";

            state tek_sost = state.S;



            // основной цикл
            while (tek_sost != state.Finish && tek_sost != state.E && startPos < source.Length)  
            {

                cur = source[startPos++];
                switch (tek_sost)
                {
                    //FORMAT

                    /*
                    case state.S:
                        {
                            if (cur == ' ')
                            {
                                // Пропускаем пробел
                            }
                            else if (cur == 'f')
                            {
                                tek_sost = state.C1A;
                            }
                            else
                            {
                                throw new ArgumentException($"Ошибка синтаксиса \n\nВведен некорректный символ: {cur}. \n\nОжидалось: F \nВ слове: FORMAT");
                            }
                        }
                        break;
                    case state.C1A:
                        {
                            if (cur == 'o')
                            {
                                tek_sost = state.C1B;
                            }
                            else
                            {
                                throw new ArgumentException($"Ошибка синтаксиса \n\nВведен некорректный символ: {cur}. \n\nОжидалось: O \nВ слове: FORMAT");
                            }
                        }
                        break;
                    case state.C1B:
                        {
                            if (cur == 'r')
                            {
                                tek_sost = state.C1C;
                            }
                            else
                            {
                                throw new ArgumentException($"Ошибка синтаксиса \n\nВведен некорректный символ: {cur}. \n\nОжидалось: R \nВ слове: FORMAT");
                            }
                        }
                        break;
                    case state.C1C:
                        {
                            if (cur == 'm')
                            {
                                tek_sost = state.C1D;
                            }
                            else
                            {
                                throw new ArgumentException($"Ошибка синтаксиса \n\nВведен некорректный символ: {cur}. \n\nОжидалось: M \nВ слове: FORMAT");
                            }
                        }
                        break;
                    case state.C1D:
                        {
                            if (cur == 'a')
                            {
                                tek_sost = state.C1E;
                            }
                            else
                            {
                                throw new ArgumentException($"Ошибка синтаксиса \n\nВведен некорректный символ: {cur}. \n\nОжидалось: A \nВ слове: FORMAT");
                            }
                        }
                        break;
                    case state.C1E:
                        {
                            if (cur == 't')
                            {
                                tek_sost = state.B;
                            }
                            else
                            {
                                throw new ArgumentException($"Ошибка синтаксиса \n\nВведен некорректный символ: {cur}. \n\nОжидалось: T \nВ слове: FORMAT");
                            }
                        }
                        break;
                    */

                    case state.S:
                        {
                            if (cur == ' ')
                            {
                                // Пропускаем пробел
                            }
                            else if (cur == 'f')
                            {
                                cur = source[startPos++];
                                if (cur == 'o') 
                                {
                                    cur = source[startPos++];
                                    if (cur == 'r')
                                    {
                                        cur = source[startPos++];
                                        if (cur == 'm')
                                        {
                                            cur = source[startPos++];
                                            if (cur == 'a')
                                            {
                                                cur = source[startPos++];
                                                if (cur == 't')
                                                {
                                                    tek_sost = state.A; 
                                                }
                                                else
                                                {
                                                    throw new ArgumentException($"Ошибка синтаксиса \n\nВведен некорректный символ: {cur}. \n\nОжидалось: T \nВ слове: FORMAT");
                                                }
                                            }
                                            else
                                            {
                                                throw new ArgumentException($"Ошибка синтаксиса \n\nВведен некорректный символ: {cur}. \n\nОжидалось: A \nВ слове: FORMAT");
                                            }
                                        }
                                        else
                                        {
                                            throw new ArgumentException($"Ошибка синтаксиса \n\nВведен некорректный символ: {cur}. \n\nОжидалось: M \nВ слове: FORMAT");
                                        }
                                    }
                                    else
                                    {
                                        throw new ArgumentException($"Ошибка синтаксиса \n\nВведен некорректный символ: {cur}. \n\nОжидалось: R \nВ слове: FORMAT");
                                    }
                                }
                                else 
                                {
                                    throw new ArgumentException($"Ошибка синтаксиса \n\nВведен некорректный символ: {cur}. \n\nОжидалось: O \nВ слове: FORMAT");
                                }
                            }
                            else
                            {
                                throw new ArgumentException($"Ошибка синтаксиса \n\nВведен некорректный символ: {cur}. \n\nОжидалось: F \nВ слове: FORMAT");
                            }
                        }
                        break; 

                    //обязательный пробел 
                    case state.A:
                        {
                            if (cur == ' ')
                            {
                                tek_sost = state.B;
                            }
                            else
                            {
                                throw new ArgumentException($"Ошибка синтаксиса \n\nВведен некорректный символ: {cur}. \n\nОжидается пробел после 'FORMAT'");
                            }
                        }
                        break;

                    //открывающая круглая скобка + обработка необязательных пробелов 
                    case state.B:
                        {
                            if (cur == ' ')
                            {
                                // Пропускаем пробелы
                            }
                            else if (cur == '(')
                            {
                                tek_sost = state.C;
                            }
                            else
                            {
                                throw new ArgumentException($"Ошибка синтаксиса \n\nВведен некорректный символ: {cur}. \n\nОжидалось: (");
                            }
                        }
                        break;

                    case state.C:
                        {
                            if (cur == ' ')
                            {
                                //пропускаем пробелы
                            }

                            //ввели первую цифру
                            //числоХ
                            else if (cur.IsNumber())
                            {
                                if (cur != '0')
                                {
                                    main_const = "";
                                    while (cur.IsNumber() && startPos < source.Length + 1)
                                    {
                                        main_const += cur;
                                        cur = source[startPos++];

                                    }
                                    cur = source[startPos--];
                                    if (Convert.ToInt32(main_const) > 0 && Convert.ToInt32(main_const) < 257)
                                    {
                                        tek_sost = state.X;
                                    }
                                    else
                                    {
                                        throw new ArgumentException($"Семантическая ошибка \n\nВведенное число не входит в диапазон 1...256");
                                    }
                                    //cur = source[startPos++];
                                }

                                else
                                {
                                    throw new ArgumentException($"Семантическая ошибка \n\nОжидалось 1...9");
                                }
                            }

                            //текст 
                            else if (cur == '\'')
                            {
                                tek_sost = state.T;
                            }

                            //i 
                            else if (cur == 'i')
                            {
                                tek_sost = state.I; 
                            }

                            //f 
                            else if (cur == 'f')
                            {
                                tek_sost = state.F; 
                            }

                            //перевод на новую строку  
                            else if (cur == '/')
                            {
                                tek_sost = state.Enter; 
                            }

                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {cur}. Ознакомьтесь с разделом 'Формат'");
                            }
                        }
                        break;

                        //Х - пробелы/нижние подчёркивания 
                    case state.X:
                        {
                            if (cur == ' ')
                            {
                                // Пропускаем пробелы
                            }
                            else if (cur == 'x')
                            {
                                tek_sost = state.EndElement;
                                for (int i = 0; i < Convert.ToInt32(main_const); i++)
                                {
                                    resStr += "_ ";
                                }
                            }
                            else
                            {
                                // cur = source[startPos--];
                                throw new ArgumentException($"Ошибка синтаксиса \n\nВведен некорректный символ: {cur}. \n\nОжидалось: X");
                                // cur = source[startPos++];
                            }
                        }
                        break;


                        //текст 
                    case state.T:
                        {
                            string checkStr = "";

                            if (cur == ' ')
                            {
                                //пропускаем пробел 
                            }

                            else if (cur.IsLetter())
                            {
                                while (cur.IsLetter() && startPos < source.Length + 1 && cur != '\'' || cur == ' ')
                                {
                                    if (startPos < source.Length)
                                    {
                                        if (cur == ' ')
                                        {
                                            cur = source[startPos++];
                                        }
                                        else
                                        {
                                            checkStr += cur;
                                            cur = source[startPos++];
                                        }
                                    }
                                    else
                                    {
                                        break;
                                    }
                                }

                                if (cur == '\'') 
                                {
                                    tek_sost = state.EndElement;
                                }
                                else 
                                {
                                    throw new ArgumentException($"Ошибка синтаксиса \n\nВведен некорректный символ. \n\nОжидалась закрывающая кавычка \'");
                                }

                                cur = source[startPos--];
                                if (checkStr.Length < 51)
                                {
                                    resStr += checkStr;
                                }
                                else
                                {
                                    throw new ArgumentException($"Семантическая ошибка: \n\n длина текста не может быть более 50 символов");
                                }
                                cur = source[startPos++];
                            }

                            else
                            {
                                throw new ArgumentException($"Ошибка синтаксиса \n\nВведен некорректный символ: {cur}. \n\nОжидался символ Юникода");
                            }

                        }
                        break;

                        //Iчисло 
                    case state.I: 
                        {
                            if (cur == ' ')
                            {
                                //пропускаем пробел 
                            }

                            else if (cur.IsNumber()) //ввели первую цифру 
                            {
                                //ЗАПИСЫВАЕМ КОНСТАНТУ
                                if (cur != '0')
                                {
                                    main_const = "";

                                    while (cur.IsNumber() && startPos < source.Length + 1)
                                    {
                                        main_const += cur;
                                        cur = source[startPos++];
                                    }

                                    if (Convert.ToInt32(main_const) > 0 && Convert.ToInt32(main_const) < 257)
                                    {
                                        resStr += "F";

                                        for (int i = 0; i < Convert.ToInt32(main_const) - 1; i++)
                                        {
                                            resStr += "I";
                                        }

                                        tek_sost = state.EndElement;
                                        if (startPos > 0)
                                        {
                                            startPos -= 1;
                                            cur = source[startPos];
                                        }

                                    }

                                    else
                                    {
                                        cur = source[startPos--];
                                        throw new ArgumentException($"Семантическая ошибка \n\nВведенное число не входит в диапазон 1...256");
                                        cur = source[startPos++];
                                    }
                                }
                                else
                                {
                                    throw new ArgumentException($"Ошибка синтаксиса \n\nВведен некорректный символ: {cur}. \n\nОжидалось: 1...9");
                                }
                            }
                            else
                            {
                                throw new ArgumentException($"Ошибка синтаксиса \n\nВведен некорректный символ: {cur}. \n\nОжидалось: 1...9");
                            }
                        }
                        break;

                        //fчисло.число 
                    case state.F: 
                        {
                            if (cur == ' ')
                            {
                                //пропускаем пробел 
                            }

                            else if (cur.IsNumber()) //ввели первую цифру 
                            {
                                //ЗАПИСЫВАЕМ ПЕРВУЮ КОНСТАНТУ
                                if (cur != '0')
                                {
                                    one_const = "";
                                    two_const = "";

                                    while (cur.IsNumber() && startPos < source.Length + 1)
                                    {
                                        one_const += cur;
                                        cur = source[startPos++];
                                    }

                                    //ЗАПИСЫВАЕМ ВТОРУЮ КОНСТАНТУ
                                    if (Convert.ToInt32(one_const) > 0 && Convert.ToInt32(one_const) < 257)
                                    {
                                        if (cur == '.')
                                        {
                                            if (startPos < source.Length)
                                            {
                                                cur = source[startPos++];
                                            }

                                            while (cur.IsNumber() && startPos < source.Length + 1)
                                            {
                                                two_const += cur;
                                                cur = source[startPos++];
                                            }

                                            if (Convert.ToInt32(two_const) > 0 && Convert.ToInt32(two_const) < 257)
                                            {
                                                if (Convert.ToInt32(one_const) > Convert.ToInt32(two_const) + 2)
                                                {
                                                    resStr += "F";
                                                    int c = Convert.ToInt32(one_const) - 2 - Convert.ToInt32(two_const);
                                                    for (int i = 0; i < c; i++)
                                                    {
                                                        resStr += "I";
                                                    }
                                                    resStr += ".";

                                                    for (int i = 0; i < Convert.ToInt32(two_const); i++)
                                                    {
                                                        resStr += "I";
                                                    }
                                                    tek_sost = state.EndElement;
                                                    if (startPos > 0)
                                                    {
                                                        startPos -= 1;
                                                        cur = source[startPos];
                                                    }
                                                }
                                                else
                                                {
                                                    throw new ArgumentException($"Семантическая ошибка \n\nКонстанта 1 должна быть больше (константа 2 + 2)");
                                                }
                                            }

                                            else
                                            {
                                                throw new ArgumentException($"Семантическая ошибка \n\nВведенное число не входит в диапазон 1...256");
                                            }
                                        }

                                        else
                                        {
                                            throw new ArgumentException($"Ошибка синтаксиса \n\nВведен некорректный символ: {cur}. \n\nОжидалось: '.'");
                                        }
                                    }
                                    else
                                    {
                                        throw new ArgumentException($"Семантическая ошибка \n\nВведенное число не входит в диапазон 1...256");
                                    }
                                }

                                else
                                {
                                    throw new ArgumentException($"Семантическая ошибка \n\nОжидалось 1...9");
                                }
                            }
                            else
                            {
                                throw new ArgumentException($"Ошибка синтаксиса \n\nВведен некорректный символ: {cur}. \n\nОжидалось: 1...9");
                            }
                        }
                        break;



                        //переход на новую строку
                    case state.Enter:
                        {
                            int check = 1;
                            while (cur == '/')
                            {
                                check += 1;
                                cur = source[startPos++];
                            }

                            if (startPos > 0)
                            {
                                startPos -= 1;
                                cur = source[startPos];
                            }

                            if (check < 4)
                            {
                                for (int i = 0; i < check; i++)
                                {
                                    resStr += Environment.NewLine;
                                }
                                tek_sost = state.EndElement;
                            }


                            else
                            {
                                throw new ArgumentException($"Семантическая ошибка \n\n Можно вводить не больше трёх символов '/'");
                            }
                        }
                        break; 

                        //окончание ввода одного элемента
                    case state.EndElement:
                        {
                            if (cur == ' ')
                            {
                                // Пропускаем пробелы
                            }

                            else if (cur == ')')
                            {
                                tek_sost = state.Finish;
                                //end = true;
                            }

                            else if (cur == ',')
                            {
                                tek_sost = state.C;
                            }

                            else { throw new ArgumentException($"Ошибка синтаксиса \n\nВведен некорректный символ: {cur}. \n\nОжидалось: ) или ,"); }
                        }
                        break;
                }
            }

            if (tek_sost == state.Finish)
            {
                return resStr;
            }

            else
            {
                throw new ArgumentException($"Ошибка синтаксиса \n\nВведен некорректный символ. \n\nОжидалось: )");

            }
            return resStr;
        }
    }
}