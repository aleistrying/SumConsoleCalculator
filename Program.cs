using System;

namespace CoreTest_calculator_in_console_
{
    class Program
    {
        //el metodo principal donde todo programa inicia
        static void Main(string[] args)
        {
            while (true)
            {
                //inicia el loop de busqueda de datos del usuario
                CalculateValues(Console.ReadLine());
            }
        }
        /// <summary>
        /// Calcula los valores, es la funcion principal donde deberia agregar todos los otros elementos de PEMDAS(suma,resta,multi,etc...)
        /// </summary>
        /// <param name="inputString"></param>
        static void CalculateValues(string inputString)
        {
            //remplazo el string inicial y le quito los espacios para que sea uniforme el string

            inputString = inputString.Replace(" ", "");

            //variable que se utiliza para guardar el numbero concurrente

            string currentNumber = "";

            //variable para cambiar la longitud de el loop dinamicamente

            int inputStringLenght = inputString.Length;

            //variable que debe contener el resultado final de suma de el numero actual 
            //(tiene E para hacer debbugging si es que tiene un Error)

            string result = "";

            //variable que contiene el numero que le sigue a el numero cual estamos en el momento actual.

            string nextNumber = "";

            ///<EXPLICACION DE LOOP>
            /// primero que todo ponemos como variable "index" para mantener una constancia de que palabra 
            /// vamos en durante el transcurso de la cadena. basicamente lo que estamos haciendo es revisando
            /// cada caracter para ver si el caracter es un numbero o un signo de +. si es un numero, lo guarda
            /// si es un signo, agarra el numero elegido, y lo suma con el siguiente numero que le sigue en la
            /// cadena de caracteres. y luego de haberlo sumado, lo remplaza en el string original en donde se
            /// creo la suma y se repite el mismo proceso denuevo. 
            /// 
            /// Un ejemplo de como funciona el proceso/algoritmo:
            /// 
            /// INPUT: "1+  2 + 4"
            /// se transforma en 2+2+2
            /// luego se busca el numero actual que seria "1"
            /// se elimina la primera parte del string. y queda 2+4
            /// ahora a esa parte se le busca el "siguiente numero" que es 2
            /// se suman el actual con el siguiente, que da 3
            /// ese numero se remplaza en el string original , cambiando de 2+2+2 a 3+4
            /// 
            /// luego de eso, ese string se vuelve el nuevo string que se le esta buscando la suma, y se vuelve a 
            /// realizar el mismo proceso.
            ///</EXPLICACION DE LOOP>
            for (int index = 0; index < inputStringLenght; index++)
            {
                if (int.TryParse(inputString[index].ToString(), out int output))
                {
                    currentNumber += inputString[index];
                }
                else if(inputString[index] == '+')
                {
                    inputString = inputString.Remove(0, index+1);
                    nextNumber = SearchForNextNumber(inputString);
                    result = Sum(currentNumber, nextNumber);
                    Console.WriteLine(int.Parse(result));

                    inputString = inputString.TrimStart(nextNumber.ToCharArray());
                    inputString = inputString.Insert(0, result);
                    index = -1;
                    currentNumber = "";
                    inputStringLenght = inputString.Length;
                }

            }
            Console.WriteLine("Resultado de suma: {0}",int.Parse(result));
        }
        static string SearchForNextNumber(string inputString)
        {
            string numberStr = "";
            for (int index = 0; index < inputString.Length; index++)
            {
                if (int.TryParse(inputString[index].ToString(), out int output))
                {
                    numberStr += inputString[index];
                }
                else
                {
                    break;
                }
            }
                return numberStr;
        }
        static string Sum(string str1, string str2)
        {
            int.TryParse(str1,out int result1);
            int.TryParse(str2, out int result2);
            return (result1 + result2).ToString();
        }
    }
}
