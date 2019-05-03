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
            ///

            for (int index = 0; index < inputStringLenght; index++)
            {

                //revisa si el "inputstring[index]" ,que es un caracter, es un numero, y si lo es y se puede sacar,
                //entonces lo agregas como el numero actual.

                if (int.TryParse(inputString[index].ToString(), out int output))
                {
                    //se agrega el caracter(que es un numero por definitivo) a el num actual.

                    currentNumber += inputString[index];
                }

                //revisa si el caracter es envez un signo de suma

                else if(inputString[index] == '+')
                {
                    //remueve la primera parte del string (si tenemos "1+2+4", y estas por el caracter "+", 
                    //esta removiendo "1+", y te deja de resultado "2+4") 
                    //el index+1 esta ahi porque index es igual al +, y queremos que empieze a buscar el
                    //siguiente numero desde el siguiente numero, no desde +

                    inputString = inputString.Remove(0, index+1);

                    //luego en searchfornext, se busca el siguiente numero. es basicamente una repeticion 
                    //del if al inicio, solamente que esta vez, el loop 
                    //rompe cuando encuntra un numero completo en vez de buscar todo.

                    nextNumber = SearchForNextNumber(inputString);

                    //luego el numero actual y el siguiente se suman(utilizo esta funcion que los transforma
                    //a enteros los suma y devuelve un string que se guarda como resultado.

                    result = Sum(currentNumber, nextNumber);

                    //esto solo esta aqui para ver cada paso de la suma, no es necesario para el algoritmo.

                    Console.WriteLine(int.Parse(result));

                    //el inputstring se le removio ya el "1+", y lo sumo con "2" que da "3", pero queda "2+4"
                    //como el inputstring, entonces se le tiene que remover el 2 y remplazarlo por el 3

                    inputString = inputString.TrimStart(nextNumber.ToCharArray());

                    //como se elimina la primera parte de la suma, simplemente se le agrega el resultado en la
                    //ubicacion incial, y queda "3+4"

                    //p.s. si quiero arreglar esto para que sirva en PEMDAS tengo que hacerlo menos hardcoded

                    inputString = inputString.Insert(0, result);

                    //luego de todo esto se reinician las variables. 
                    //como es un loop y cada ronda se le suma 1, pues se pone negativo asi cuando se sume quede en 0

                    index = -1;

                    //ya no existe un numero actual asi que se pone en vacio el string

                    currentNumber = "";

                    //y el nuevo string tiene una longitud que se calcula y se pone como la nueva longitud que hay 
                    //que buscar. esto es para iniciar nuevamente el proceso de busqueda de suma

                    inputStringLenght = inputString.Length;
                }

            }

            //finalmente imprime el resultado que devuelve

            Console.WriteLine("Resultado de suma: {0}",int.Parse(currentNumber));
        }
        /// <summary>
        /// Este metodo busca el siguiente numero en la cadena de caracteres, y regresa ese numero en string
        /// </summary>
        /// <param name="inputString"></param>
        /// <returns></returns>
        static string SearchForNextNumber(string inputString)
        {
            string numberStr = "";
            for (int index = 0; index < inputString.Length; index++)
            {
                //se prueba si este es un numero.

                if (int.TryParse(inputString[index].ToString(), out int output))
                {
                    //se le agrega a la cadena el numero

                    numberStr += inputString[index];
                }
                else
                {
                    //rompe el string una vez que se vea que no es un numero.

                    break;
                }
            }

            //retorna una vez que ya se haya encontrado el numero

                return numberStr;
        }
        /// <summary>
        /// Suma dos numeros que estan en forma de string
        /// </summary>
        /// <param name="str1"></param>
        /// <param name="str2"></param>
        /// <returns></returns>
        static string Sum(string str1, string str2)
        {
            //se transforman strings a ints

            int.TryParse(str1,out int result1);
            int.TryParse(str2, out int result2);

            //se devuelven los datos sumados

            return (result1 + result2).ToString();
        }
    }
}
