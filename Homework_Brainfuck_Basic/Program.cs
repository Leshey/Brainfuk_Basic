using System.Collections;

namespace SecondLesson;

public static class Program
{
    private static char[] _memory;
    private static int _current = 0;
    public static void Main()
    {
        _memory = new char[30000];

        string program =
           "++++++++++[>+++++++>++++++++++>+++>+<<<<-]>++.>+.+++++++..+++.>++.<<+++++++++++++++.>.+++.------.--------.>+.>.";

        for (int i = 0; i < program.Length; i++) 
        {
            if (program[i] == '+')
            {
                AddCharValue();
            }
            else if (program[i] == '-')
            {
                DecreaseCharValue();
            }
            else if (program[i] == '>')
            {
                MoveToNextCell();
            }
            else if (program[i] == '<')
            {
                MoveToPreviosCell();
            }
            else if (program[i] == '.')
            {
                PrintValueFromCurrentCell();
            }
            else if (program[i] == ',')
            {
                GetValueAndSaveItInCurrentCell();
            }
            else if (program[i] == '[') 
            {
                if (_memory[_current] == 0) 
                {
                    int bracketCounter = 0;
                    i++;
                    while (program[i] != ']' || bracketCounter != 0) 
                    {
                        if (program[i] == '[') 
                        {
                            bracketCounter++;
                            i++;
                        }
                        if (program[i] == ']') 
                        {
                            bracketCounter--;
                            i++;
                        }
                        i++;
                    }
                }
            }
            else if (program[i] == ']') 
            {
                if (_memory[_current] != 0) 
                {
                    int bracketCounter = 0;
                    i--;
                    while (program[i] != '[' || bracketCounter != 0)
                    {
                        if (program[i] == ']')
                        {
                            bracketCounter++;
                            i--;
                        }
                        if (program[i] == '[')
                        {
                            bracketCounter--;
                            i--;
                        }
                        i--;
                    }
                }
            }
        }
    }

   
    
    public static void AddCharValue()
    {
        _memory[_current]++;
    }

    public static void DecreaseCharValue() 
    {
        _memory[_current]--;
    }

    public static void MoveToNextCell() 
    {
        _current++;
    }

    public static void MoveToPreviosCell() 
    {
        _current--;
    }

    public static void PrintValueFromCurrentCell() 
    {
        Console.Write(_memory[_current]);
    }

    public static void GetValueAndSaveItInCurrentCell() 
    {
        char userInput = Convert.ToChar(Console.Read());
        _memory[_current] = userInput;
    }

}