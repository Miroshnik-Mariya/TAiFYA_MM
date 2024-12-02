namespace Analyzator
{
    enum state
    {
        S, // Начало
        //C1A, C1B, C1C, C1D, C1E, // Ищем FORMAT
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
       

        text1, 
        text2, 
        text3, 
        
    }
}
