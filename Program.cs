using System;

namespace ProgramaTeslas
{
    // Estructura con los datos de los Teslas
    struct Tesla
    {
        public string modelo;
        public int anio;
        public int kilometrajeActual;
        public string color;
        public string duenio;
        public bool tuvoService;
    }

    class Program
    {
        static void Main(string[] args)
        {
            const int MAX_TESLAS = 100;
            Tesla[] teslas = new Tesla[MAX_TESLAS];
            int numTeslas = 0;

            // Se asume que el service de todos los Tesla se hace a los 10.000 km
            const int kilometrajeService = 10000;

            while (true)
            {
                // Menu de navegacion
                Console.WriteLine("Ingrese la opcion deseada:");
                Console.WriteLine("1 - Dar de alta un Tesla");
                Console.WriteLine("2 - Eliminar un Tesla");
                Console.WriteLine("3 - Mostrar Teslas que tuvieron service");
                Console.WriteLine("4 - Reordenar lista de Teslas por anio");
                Console.WriteLine("5 - Mostrar el Tesla mas nuevo");
                Console.WriteLine("6 - Salir");
                Console.Write("Opcion: ");
                int opcion = int.Parse(Console.ReadLine() ?? "");
                Console.WriteLine();

                switch (opcion)
                {
                    // Se le pide al usuario todas las propiedades del Tesla y se da de alta. 
                    case 1:
                        if (numTeslas < MAX_TESLAS)
                        {
                            Console.Write("Ingrese el modelo del Tesla: ");
                            string modelo = Console.ReadLine() ?? ""; // Se le da un valor default a las variables con ReadLines para evitar las warnings de posible null
                            Console.Write("Ingrese el anio del Tesla: ");
                            int anio = int.Parse(Console.ReadLine() ?? "");
                            Console.Write("Ingrese el kilometraje actual: ");
                            int kilometrajeActual = int.Parse(Console.ReadLine() ?? "");
                            Console.Write("Ingrese el color del Tesla: ");
                            string color = Console.ReadLine() ?? "";
                            Console.Write("Ingrese el duenio del Tesla: ");
                            string duenio = Console.ReadLine() ?? "";
                            //Console.Write("El auto tuvo service? (s/n): ");
                            //char tuvoService = char.Parse(Console.ReadLine() ?? "");


                            Tesla auto = new Tesla();
                            auto.modelo = modelo;
                            auto.anio = anio;
                            auto.kilometrajeActual = kilometrajeActual;
                            auto.color = color;
                            auto.duenio = duenio;

                            // Se compara el kilometraje actual con el kilometraje de service, y se 
                            if (auto.kilometrajeActual >= kilometrajeService)
                            {
                                auto.tuvoService = true;
                            }
                            else
                            {
                                auto.tuvoService = false;
                            }
                            //if (char.ToLower(tuvoService) == 's')
                            //{
                            //    auto.tuvoService = true;
                            //    Console.Write("Ingrese el kilometraje de service: ");
                            //    auto.kilometrajeService = int.Parse(Console.ReadLine() ?? "");
                            //}
                            //else
                            //    auto.tuvoService = false;

                            teslas[numTeslas] = auto;
                            numTeslas++;
                            Console.WriteLine("El Tesla se dio de alta exitosamente.\n");
                        }
                        else
                        {
                            Console.WriteLine("No se pueden agregar mas Teslas.\n");
                        }
                        break;


                    // Se le pide al usuario el nombre del duenio del Tesla, recorre el array y si lo encuentra se elimina
                    case 2:
                        Console.Write("Ingrese el duenio del Tesla que desea eliminar: ");
                        string duenioTesla = Console.ReadLine() ?? "";

                        bool encontrado = false;

                        for (int auto = 0; auto < numTeslas; auto++)
                        {
                            if (teslas[auto].duenio == duenioTesla)
                            {
                                // Se reorganiza el array para eliminar el Tesla encontrado
                                for (int indexAuto = auto; indexAuto < numTeslas - 1; indexAuto++)
                                {
                                    teslas[indexAuto] = teslas[indexAuto + 1];
                                }
                                encontrado = true;
                                numTeslas--;
                                Console.WriteLine("El Tesla se elimino exitosamente.\n");
                                break;
                            }
                        }
                        if (!encontrado)
                        {
                            Console.WriteLine("El Tesla no se encontro.\n");
                        }
                        break;


                    // Busca si hay algun auto que tuvo service y muestra los datos
                    case 3:
                        Console.WriteLine("Lista de Teslas que tuvieron service:");

                        bool serviceEncontrado = false;

                        for (int auto = 0; auto < numTeslas; auto++)
                        {
                            if (teslas[auto].tuvoService)
                            {
                                Console.WriteLine($"Modelo: {teslas[auto].modelo}\n" +
                                    $"Anio: {teslas[auto].anio}\n" +
                                    $"Dueño: {teslas[auto].duenio}\n" +
                                    $"Kilometraje actual: {teslas[auto].kilometrajeActual}\n");
                                serviceEncontrado = true;
                            }
                        }

                        if (!serviceEncontrado)
                        {
                            Console.WriteLine("No hay Teslas que tuvieron service.\n");
                        }

                        break;


                    // Reordena la lista por anio del mas viejo al mas nuevo
                    case 4:
                        for (int auto = 0; auto < numTeslas - 1; auto++)
                        {
                            for (int indexAuto = auto + 1; indexAuto < numTeslas; indexAuto++)
                            {
                                if (teslas[auto].anio > teslas[indexAuto].anio)
                                {
                                    Tesla temp = teslas[auto];
                                    teslas[auto] = teslas[indexAuto];
                                    teslas[indexAuto] = temp;
                                }
                            }
                        }
                        Console.WriteLine("La lista de Teslas se ordeno por anio.\n");
                        break;


                    // Busca el Tesla con el anio mayor en el array y lo muestra
                    case 5:
                        int maxAnio = -1;
                        int indexMaxAnio = -1;

                        for (int auto = 0; auto < numTeslas; auto++)
                        {
                            if (teslas[auto].anio > maxAnio)
                            {
                                maxAnio = teslas[auto].anio;
                                indexMaxAnio = auto;
                            }
                        }

                        if (indexMaxAnio > 0)
                        {
                            Console.WriteLine($"El Tesla mas nuevo es el modelo {teslas[indexMaxAnio].modelo} " +
                                $"del anio {teslas[indexMaxAnio].anio}.\n" +
                                $"Duenio: {teslas[indexMaxAnio].duenio}\n");
                        }
                        else
                        {
                            Console.WriteLine("No hay Teslas dados de alta.\n");
                        }
                        break;

                    case 6:
                        Console.WriteLine("Hasta luego!\n");
                        return;

                    default:
                        Console.WriteLine("Opcion invalida.\n");
                        break;
                }
            }
        }
    }
}
