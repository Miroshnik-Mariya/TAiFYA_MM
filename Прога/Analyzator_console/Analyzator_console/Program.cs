using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Analyzator_console
{
    class Identifikator
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public int Volume { get; set; }

        public Identifikator(string name, string type, int volume)
        {
            Name = name;
            Type = type;
            Volume = volume;
        }
    }

    internal class Program
    {
        enum Type_Reserv
        {
            TYPE, 
            CARDINAL, 
            INTEGER, 
            REAL, 
            CHAR, 
            BOOLEAN,
            ARRAY, 
            OF, 
            TO, 
            POINTER
        }
        enum Alphabet
        {
            a, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z,
            A, B, C, D, E, F, G, H, I, J, K, L, M, N, O, P, Q, R, S, T, U, V, W, X, Y, Z
        }
            
        enum state
        {
            S, // Начало
            C1A, C1B, C1C, C1D, // Ищем TYPE
            C2A, C2B, C2C, C2D, // Идентификатор
            C3A, C3B, // =
            C4A, C4B, C4BA, C4BB, C4BC, C4C, C4CA, C4CB, C4CC, C4CD, C4CE, C4CF, C4CG, C4CH, C4D,// ARRAY, POINTER_TO, Простой тип 
            C5, // [
            C6, C6A, // Константа
            C7, C7A, // ..
            C8, C8A, // Константа
            C9, // ]
            C10, C10A, // , _
            C11, C11A, // OF
            C12, C12A,
            C13, C14, F, E, 
            CProstType, CProstType1, CProstType2, CProstType3, CProstType4, CProstType5, CProstType6,
            CConst
        }
        static void Main(string[] args)
        {
            string source;
            string s1, s2;
            Console.WriteLine("Проверка индентификатора");
            source = Console.ReadLine();
            s2 = source;
            source = source.ToLower();
            var indetifikators = new List<Identifikator>();
            var tekushiy_indetifikator = new Identifikator("example", "char", 1);

            int tek_index = 0;
            char tek_symbol;
            string tek_identifikator = "";
            string first_const = "";
            string second_const = "";
            int tek_volume = 1;
            state tek_sost = state.S;

            while(tek_sost != state.F && tek_sost != state.E && tek_index <= source.Length)
            {
                tek_symbol = source[tek_index++];
                //Console.WriteLine(tek_symbol + " " + tek_sost);
                switch (tek_sost)
                {
                    case state.S:
                        {
                            if (tek_symbol.IsSpace())
                            {
                                // Пропускаем пробел
                            }
                            else if (tek_symbol == 't')
                            {
                                tek_sost = state.C1A;
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: T");
                            }
                        }
                        break;
                    case state.C1A:
                        {
                            if (tek_symbol == 'y')
                            {
                                tek_sost = state.C1B;
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: Y");
                            }
                        }
                        break;
                    case state.C1B:
                        {
                            if (tek_symbol == 'p')
                            {
                                tek_sost = state.C1C;
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: P");
                            }
                        }
                        break;
                    case state.C1C:
                        {
                            if (tek_symbol == 'e')
                            {
                                tek_sost = state.C1D;
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: E");
                            }
                        }
                        break;
                    case state.C1D:
                        {
                            if (tek_symbol == ' ')
                            {
                                tek_sost = state.C2A;
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: ' Пробел '");
                            }
                        }
                        break;
                    case state.C2A:
                        {
                            if (tek_symbol.IsSpace())
                            {
                                // Пропускаем пробел
                            }
                            else if (tek_symbol.IsLetter())
                            {
                                tek_identifikator += tek_symbol;
                                tek_sost = state.C2B;
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: a..z");
                            }
                        }
                        break;
                    case state.C2B:
                        {
                            if (tek_symbol.IsLetter())
                            {
                                tek_identifikator += tek_symbol;
                                if (tek_identifikator.Length > 8)
                                {
                                    throw new ArgumentException($"Идентификатор не может быть длинее 8 символов");
                                }
                                else tek_sost = state.C2B;
                            }
                            else if (tek_symbol.IsNumber() && tek_identifikator != "")
                            {
                                tek_identifikator += tek_symbol;
                            }
                            else if (tek_symbol == ' ')
                            {
                                if /*(indetifikators.Any(item => item.Name == tek_identifikator) || tek_identifikator == "cardinal"
                                    || tek_identifikator == "integer" || tek_identifikator == "real"
                                    || tek_identifikator == "char" || tek_identifikator == "boolean"
                                    || tek_identifikator == "of")*/
                                    (Enum.IsDefined(typeof(Type_Reserv), tek_identifikator.ToUpper()))
                                {
                                    throw new ArgumentException($"Идентификатор не может совпадать с ключевым словом или повторяться");
                                }
                                else
                                {
                                    //indetifikators.Any(item => item.Name == tek_identifikator);
                                    tekushiy_indetifikator.Name = tek_identifikator;
                                    tek_identifikator = "";
                                    tek_sost = state.C3A;
                                }
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: a..z");
                            }
                        }
                        break;
                    case state.C3A:
                        {
                            if (tek_symbol.IsSpace())
                            {
                                // Пропускаем пробел
                            }
                            else if (tek_symbol.IsSign())
                            {
                                //tek_identifikator += tek_symbol;
                                tek_sost = state.C3B;
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: '='");
                            }
                        }
                        break;
                    case state.C3B:
                        {
                            if (tek_symbol.IsSpace())
                            {
                                tek_sost = state.C4A;
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: ' '");
                            }
                        }
                        break;
                    case state.C4A:
                        {
                            if (tek_symbol.IsSpace())
                            {
                                // Пропускаем пробел
                            }
                            else if (tek_symbol == 'a')
                            {
                                tek_identifikator += tek_symbol;
                                tek_sost = state.C4B;
                            }
                            else if (tek_symbol == 'p')
                            {
                                tek_identifikator += tek_symbol;
                                tek_sost = state.C4C;
                            }
                            else if (tek_symbol == 'c' || tek_symbol == 'i'
                                || tek_symbol == 'r' || tek_symbol == 'c'
                                || tek_symbol == 'b')
                            {
                                tek_identifikator += tek_symbol;
                                tek_sost = state.CProstType;
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}.");
                            }
                        }   
                        break;
                    case state.C4B:
                        {
                            if (tek_symbol == 'r')
                            {
                                tek_sost = state.C4BA;
                            }
                            
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: r");
                            }
                        }
                        break;
                    case state.C4BA:
                        {
                            if (tek_symbol == 'r')
                            {
                                tek_sost = state.C4BB;
                            }

                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: r");
                            }
                        }
                        break;
                    case state.C4BB:
                        {
                            if (tek_symbol == 'a')
                            {
                                tek_sost = state.C4BC;
                            }

                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: a");
                            }
                        }
                        break;
                    case state.C4BC:
                        {
                            if (tek_symbol == 'y')
                            {
                                tek_sost = state.C5;
                            }

                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: y");
                            }
                        }
                        break;
                    case state.C4C:
                        {
                            if (tek_symbol == 'o')
                            {
                                tek_sost = state.C4CA;
                            }

                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: o");
                            }
                        }
                        break;
                    case state.C4CA:
                        {
                            if (tek_symbol == 'i')
                            {
                                tek_sost = state.C4CB;
                            }

                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: i");
                            }
                        }
                        break;
                    case state.C4CB:
                        {
                            if (tek_symbol == 'n')
                            {
                                tek_sost = state.C4CC;
                            }

                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: n");
                            }
                        }
                        break;
                    case state.C4CC:
                        {
                            if (tek_symbol == 't')
                            {
                                tek_sost = state.C4CD;
                            }

                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: t");
                            }
                        }
                        break;
                    case state.C4CD:
                        {
                            if (tek_symbol == 'e')
                            {
                                tek_sost = state.C4CE;
                            }

                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: e");
                            }
                        }
                        break;
                    case state.C4CE:
                        {
                            if (tek_symbol == 'r')
                            {
                                tek_sost = state.C4CF;
                            }

                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: r");
                            }
                        }
                        break;
                    case state.C4CF:
                        {
                            if (tek_symbol == ' ')
                            {
                                tek_sost = state.C4CG;
                            }

                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: ' '");
                            }
                        }
                        break;
                    case state.C4CG:
                        {
                            if (tek_symbol == 't')
                            {
                                tek_sost = state.C4CH;
                            }

                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: t");
                            }
                        }
                        break;
                    case state.C4CH:
                        {
                            if (tek_symbol == 'o')
                            {
                                tek_sost = state.C12;
                            }

                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: o");
                            }
                        }
                        break;
                    case state.C5:
                        {
                            if (tek_symbol.IsSpace())
                            {
                                // Пропускаем пробел
                            }
                            else if (tek_symbol == '[')
                            {
                                tek_sost = state.C6;
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: [");
                            }
                        }
                        break;
                    case state.C6:
                        {
                            if (tek_symbol.IsSpace())
                            {
                                // Пропускаем пробел
                            }
                            else if (tek_symbol.IsNumber() && tek_symbol != '0')
                            {
                                first_const += tek_symbol;
                                tek_sost = state.C6A;
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: 1..9");
                            }
                        }
                        break;
                    case state.C6A:
                        {
                            if (tek_symbol.IsNumber())
                            {
                                first_const += tek_symbol;
                            }
                            else if (tek_symbol == ' ')
                            {
                                if (Convert.ToInt32(first_const) > 0 && Convert.ToInt32(first_const) < 257)
                                {
                                    tek_sost = state.C7;
                                }
                                else
                                {
                                    throw new ArgumentException($"Введенная константа не входит в диапазон 1..256");
                                }
                            }
                            else if (tek_symbol == '.')
                            {
                                tek_index--;
                                tek_sost = state.C7;
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: 0..9");
                            }
                        }
                        break;
                    case state.C7:
                        {
                            if (tek_symbol.IsSpace())
                            {
                                // Пропускаем пробел
                            }
                            else if (tek_symbol == '.')
                            {
                                tek_sost = state.C7A;
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: .");
                            }
                        }
                        break;
                    case state.C7A:
                        {
                            if (tek_symbol == '.')
                            {
                                tek_sost = state.C8;
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: .");
                            }
                        }
                        break;
                    case state.C8:
                        {
                            if (tek_symbol.IsSpace())
                            {
                                // Пропускаем пробел
                            }
                            else if (tek_symbol.IsNumber() && tek_symbol != '0')
                            {
                                second_const += tek_symbol;
                                tek_sost = state.C8A;
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: 1..9");
                            }
                        }
                        break;
                    case state.C8A:
                        {
                            if (tek_symbol.IsNumber())
                            {
                                second_const += tek_symbol;
                            }
                            else if (tek_symbol == ' ')
                            {
                                if (Convert.ToInt32(second_const) > 0 && Convert.ToInt32(second_const) < 257
                                    && Convert.ToInt32(first_const) < Convert.ToInt32(second_const))
                                {
                                    tek_sost = state.C9;
                                }
                                else
                                {
                                    throw new ArgumentException($"Введенная константа не входит в диапазон 1..256");
                                }
                            }
                            else if (tek_symbol == ']')
                            {
                                tek_index--;
                                tek_sost = state.C9;
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: 0..9");
                            }
                        }
                        break;
                    case state.C9:
                        {
                            if (tek_symbol.IsSpace())
                            {
                                // Пропускаем пробел
                            }
                            else if (tek_symbol == ']')
                            {
                                tek_volume = tek_volume * (Convert.ToInt32(second_const) - Convert.ToInt32(first_const));
                                second_const = "";
                                first_const = "";
                                tek_sost = state.C10;
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: ]");
                            }
                        }
                        break;
                    case state.C10:
                        {
                            if (tek_symbol == ',')
                            {
                                tek_sost = state.C5;
                            }
                            else if (tek_symbol == ' ')
                            {
                                tek_sost = state.C11;
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: ',' ' '");
                            }
                        }
                        break;
                    case state.C11:
                        {
                            if (tek_symbol.IsSpace())
                            {
                                // Пропускаем пробел
                            }
                            else if (tek_symbol == 'o')
                            {
                                tek_sost = state.C11A;
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: o");
                            }
                        }
                        break;
                    case state.C11A:
                        {
                            if (tek_symbol == 'f')
                            {
                                tek_sost = state.C12;
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: o");
                            }
                        }
                        break;
                    case state.CProstType:
                        {
                            if (tek_identifikator == "c")
                            {
                                if (tek_symbol == 'a')
                                {
                                    tek_identifikator += tek_symbol;
                                    tek_sost = state.CProstType1;
                                }
                                else if (tek_symbol == 'h')
                                {
                                    tek_identifikator += tek_symbol;
                                    tek_sost = state.CProstType1;
                                }
                                else
                                {
                                    throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: a, h");
                                }
                     
                            }
                            else if (tek_identifikator == "i")
                                 {
                                    if (tek_symbol == 'n')
                                    {
                                        tek_identifikator += tek_symbol;
                                        tek_sost = state.CProstType1;
                                    }
                                    else
                                    {
                                        throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: n");
                                    }
                                 }
                            else if (tek_identifikator == "r")
                            {
                                if (tek_symbol == 'e')
                                {
                                    tek_identifikator += tek_symbol;
                                    tek_sost = state.CProstType1;
                                }
                                else
                                {
                                    throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: e");
                                }
                            }
                            else if (tek_identifikator == "b")
                            {
                                if (tek_symbol == 'o')
                                {
                                    tek_identifikator += tek_symbol;
                                    tek_sost = state.CProstType1;
                                }
                                else
                                {
                                    throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: o");
                                }
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}.");
                            }
                        }
                        break;
                    case state.CProstType1:
                        {
                            if (tek_identifikator == "ca")
                            {
                                if (tek_symbol == 'r')
                                {
                                    tek_identifikator += tek_symbol;
                                    tek_sost = state.CProstType2;
                                }
                                else
                                {
                                    throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: r");
                                }
                            }
                            else if (tek_identifikator == "in")
                            {
                                if (tek_symbol == 't')
                                {
                                    tek_identifikator += tek_symbol;
                                    tek_sost = state.CProstType2;
                                }
                                else
                                {
                                    throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: t");
                                }
                            }
                            else if (tek_identifikator == "re")
                            {
                                if (tek_symbol == 'a')
                                {
                                    tek_identifikator += tek_symbol;
                                    tek_sost = state.CProstType2;
                                }
                                else
                                {
                                    throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: a");
                                }
                            }
                            else if (tek_identifikator == "ch")
                            {
                                if (tek_symbol == 'a')
                                {
                                    tek_identifikator += tek_symbol;
                                    tek_sost = state.CProstType2;
                                }
                                else
                                {
                                    throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: a");
                                }
                            }
                            else if (tek_identifikator == "bo")
                            {
                                if (tek_symbol == 'o')
                                {
                                    tek_identifikator += tek_symbol;
                                    tek_sost = state.CProstType2;
                                }
                                else
                                {
                                    throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: o");
                                }
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}.");
                            }
                        }
                        break;
                    case state.CProstType2:
                        {
                            if (tek_identifikator == "car")
                            {
                                if (tek_symbol == 'd')
                                {
                                    tek_identifikator += tek_symbol;
                                    tek_sost = state.CProstType3;
                                }
                                else
                                {
                                    throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: d");
                                }
                            }
                            else if (tek_identifikator == "int")
                            {
                                if (tek_symbol == 'e')
                                {
                                    tek_identifikator += tek_symbol;
                                    tek_sost = state.CProstType3;
                                }
                                else
                                {
                                    throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: e");
                                }
                            }
                            else if (tek_identifikator == "rea")
                            {
                                if (tek_symbol == 'l')
                                {
                                    tek_identifikator += tek_symbol;
                                    tekushiy_indetifikator.Type = tek_identifikator;
                                    tekushiy_indetifikator.Volume = tek_volume * 8;
                                    tek_volume = 1;
                                    tek_identifikator = "";
                                    tek_sost = state.C14;
                                }
                                else
                                {
                                    throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: l");
                                }
                            }
                            else if (tek_identifikator == "cha")
                            {
                                if (tek_symbol == 'r')
                                {
                                    tek_identifikator += tek_symbol;
                                    tekushiy_indetifikator.Type = tek_identifikator;
                                    tekushiy_indetifikator.Volume = tek_volume * 1;
                                    tek_volume = 1;
                                    tek_identifikator = "";
                                    tek_sost = state.C14;
                                }
                                else
                                {
                                    throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: r");
                                }
                            }
                            else if (tek_identifikator == "boo")
                            {
                                if (tek_symbol == 'l')
                                {
                                    tek_identifikator += tek_symbol;
                                    tek_sost = state.CProstType3;
                                }
                                else
                                {
                                    throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: l");
                                }
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}.");
                            }
                        }
                        break;
                    case state.CProstType3:
                        {
                            if (tek_identifikator == "card")
                            {
                                if (tek_symbol == 'i')
                                {
                                    tek_identifikator += tek_symbol;
                                    tek_sost = state.CProstType4;
                                }
                                else
                                {
                                    throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: i");
                                }
                            }
                            else if (tek_identifikator == "inte")
                            {
                                if (tek_symbol == 'g')
                                {
                                    tek_identifikator += tek_symbol;
                                    tek_sost = state.CProstType4;
                                }
                                else
                                {
                                    throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: g");
                                }
                            }
                            else if (tek_identifikator == "bool")
                            {
                                if (tek_symbol == 'e')
                                {
                                    tek_identifikator += tek_symbol;
                                    tek_sost = state.CProstType4;
                                }
                                else
                                {
                                    throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: e");
                                }
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}.");
                            }
                        }
                        break;
                    case state.CProstType4:
                        {
                            if (tek_identifikator == "cardi")
                            {
                                if (tek_symbol == 'n')
                                {
                                    tek_identifikator += tek_symbol;
                                    tek_sost = state.CProstType5;
                                }
                                else
                                {
                                    throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: n");
                                }
                            }
                            else if (tek_identifikator == "integ")
                            {
                                if (tek_symbol == 'e')
                                {
                                    tek_identifikator += tek_symbol;
                                    tek_sost = state.CProstType5;
                                }
                                else
                                {
                                    throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: e");
                                }
                            }
                            else if (tek_identifikator == "boole")
                            {
                                if (tek_symbol == 'a')
                                {
                                    tek_identifikator += tek_symbol;
                                    tek_sost = state.CProstType5;
                                }
                                else
                                {
                                    throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: a");
                                }
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}.");
                            }
                        }
                        break;
                    case state.CProstType5:
                        {
                            if (tek_identifikator == "cardin")
                            {
                                if (tek_symbol == 'a')
                                {
                                    tek_identifikator += tek_symbol;
                                    tek_sost = state.CProstType6;
                                }
                                else
                                {
                                    throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: a");
                                }
                            }
                            else if (tek_identifikator == "intege")
                            {
                                if (tek_symbol == 'r')
                                {
                                    tek_identifikator += tek_symbol;
                                    tekushiy_indetifikator.Type = tek_identifikator;
                                    tekushiy_indetifikator.Volume = tek_volume * 4;
                                    tek_volume = 1;
                                    tek_identifikator = "";
                                    tek_sost = state.C14;
                                }
                                else
                                {
                                    throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: r");
                                }
                            }
                            else if (tek_identifikator == "boolea")
                            {
                                if (tek_symbol == 'n')
                                {
                                    tek_identifikator += tek_symbol;
                                    tekushiy_indetifikator.Type = tek_identifikator;
                                    tekushiy_indetifikator.Volume = tek_volume * 1;
                                    tek_volume = 1;
                                    tek_identifikator = "";
                                    tek_sost = state.C14;
                                }
                                else
                                {
                                    throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: n");
                                }
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}.");
                            }
                        }
                        break;
                    case state.CProstType6:
                        {
                            if (tek_identifikator == "cardina")
                            {
                                if (tek_symbol == 'l')
                                {
                                    tek_identifikator += tek_symbol;
                                    tekushiy_indetifikator.Type = tek_identifikator;
                                    tekushiy_indetifikator.Volume = tek_volume * 2;
                                    tek_volume = 1;
                                    tek_identifikator = "";
                                    tek_sost = state.C14;
                                }
                                else
                                {
                                    throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: a");
                                }
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}.");
                            }
                        }
                        break;
                    case state.C12:
                        {
                            if(tek_symbol == ' ')
                            {
                                tek_sost = state.C12A;
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: ' '");
                            }
                        }
                        break;
                    case state.C12A:
                        {
                            if (tek_symbol == 'c' || tek_symbol == 'i'
                                || tek_symbol == 'r' || tek_symbol == 'c'
                                || tek_symbol == 'b')
                            {
                                tek_identifikator = "";
                                tek_identifikator += tek_symbol;
                                tek_sost = state.CProstType;
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}.");
                            }
                        }
                        break;
                    case state.C13:
                        {
                            if (tek_symbol.IsSpace())
                            {
                                // Пропускаем пробел
                            }
                            else if (tek_symbol == 'c' || tek_symbol == 'i'
                                || tek_symbol == 'r' || tek_symbol == 'c'
                                || tek_symbol == 'b')
                            {
                                tek_identifikator += tek_symbol;
                                tek_sost = state.CProstType;
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}.");
                            }
                        }
                        break;
                    case state.C14:
                        {
                            if (tek_symbol == ',')
                            {
                                indetifikators.Add(tekushiy_indetifikator);
                                //Console.WriteLine($"Name: {tekushiy_indetifikator.Name}, Type: {tekushiy_indetifikator.Type}, Volume: {tekushiy_indetifikator.Volume}");
                                tekushiy_indetifikator = new Identifikator("example", "char", 1);
                                tek_sost = state.C2A;
                            }
                            else if (tek_symbol == ';')
                            {
                                indetifikators.Add(tekushiy_indetifikator);
                                //Console.WriteLine($"Name: {tekushiy_indetifikator.Name}, Type: {tekushiy_indetifikator.Type}, Volume: {tekushiy_indetifikator.Volume}");
                                tek_sost = state.F;
                            }
                            else
                            {
                                throw new ArgumentException($"Введен некорректный символ: {tek_symbol}. Ожидалось: ';'");
                            }
                        }
                        break;
                }
            }

            if (tek_sost != state.F)
            {
                throw new ArgumentNullException(nameof(tek_symbol), "Отсутствует символ окончания строки");
            }

            foreach (Identifikator device in indetifikators)
            {
                Console.WriteLine($"Name: {device.Name}, Type: {device.Type}, Volume: {device.Volume}");
            }

            Console.ReadLine();
        }



        static string GetFirstWord(string sentence)
        {
            // Удаление знаков препинания и лишних пробелов
            string cleanedSentence = sentence.Replace(",", "").Replace(".", "").Trim();

            // Разделение предложения на слова
            string[] words = cleanedSentence.Split(' ');

            // Возвращение первого слова
            return words[0];
        }

        static string GetRestOfSentence(string sentence)
        {
            // Удаление лишних пробелов в начале и конце предложения
            sentence = sentence.Trim();

            // Разделение предложения на слова
            string[] words = sentence.Split(' ');

            // Объединение оставшихся слов в предложение
            string restOfSentence = string.Join(" ", words, 1, words.Length - 1);

            return restOfSentence;
        }
        static bool RightIdentifikator(string identifikator)
        {
            char[] ident_ch = identifikator.ToCharArray();
            if (char.IsLetter(ident_ch[0]))
            {
                for (int i = 0; i < ident_ch.Length; i++)
                {
                    if (i == 8) return false;

                    if (char.IsLetter(ident_ch[i]) || char.IsNumber(ident_ch[i]))
                    {

                    }
                    else return false;
                }
            }
            else return false;
            if (Enum.IsDefined(typeof(Type_Reserv), identifikator.ToUpper())) return false;
            return true;
        }
        static bool RightConst(string constanta)
        {
            char[] ident_ch = constanta.ToCharArray();
            if (char.IsNumber(ident_ch[0]) && ident_ch[0] != '0')
            {
                for (int i = 0; i < ident_ch.Length; i++)
                {
                    if (char.IsNumber(ident_ch[0]))
                    {

                    }
                    else return false;
                }
            }
            else return false;
            int ch = Convert.ToInt32(constanta);
            if (ch < 1 || ch > 256) return false;
            return true;
        }
        static bool RightProstoyType(string prostoy_type)
        {
            if (prostoy_type == "CARDINAL" ||
                prostoy_type == "INTEGER" ||
                prostoy_type == "REAL" ||
                prostoy_type == "CHAR" ||
                prostoy_type == "BOOLEAN") return true;
            return false;
        }
    }

    public static class Extensions
    {
        public static bool IsNumber(this char ch)
        {
            return char.IsDigit(ch);
        }
        public static bool IsLetter(this char ch)
        {
            return char.IsLetter(ch);
        }
        public static bool IsSign(this char ch)
        {
            return ch == '+' || ch == '-' || ch == '=';
        }
        public static bool IsSpace(this char ch)
        {
            return ch == ' ';
        }
        public static bool IsReservedWord(this string str)
        {
            return str == "dcl"
                    || str == "declare"
                    || str == "bin"
                    || str == "fixed"
                    || str == "float"
                    || str == "char";
        }
        public static int ToInt(this string intNumb)
        {
            return int.Parse(intNumb);
        }
    }

}
