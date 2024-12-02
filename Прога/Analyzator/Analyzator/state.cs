namespace Analyzator
{
    enum state
    {
        S, // Начало
        C1A, C1B, C1C, C1D, C1E, // Ищем FORMAT
        A, 
        B, 
        C, 
        X, 
        T, 
        I, 
        F, F1, F2, 
        Enter, 
        E, 
        Finish,
        EndElement,

        C2A, C2B, C2C, C2D,

        int1, 
        int2, 
        int3, 

        text1, 
        text2, 
        text3, 
        text31,
        text32,
        text4,


        /*


        C2A, C2B, C2C, C2D, // Пробелы и скобки
        CX, //ввод пробелов 
        CT, //ввод текста 
        CI, //число со знаком
        CF, //число со знаком и дробной частью
        CEnter, //переход на новую строку = enter 
        CEl, // конец ввода одного элемента 
        Finish, //окончание работы программы 
        E //вывод исключения 
        */
    }
}
