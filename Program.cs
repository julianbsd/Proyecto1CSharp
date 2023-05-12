using System;

struct Tesla
{
    public string modelo;
    public int anio;
    public int kilometrajeActual;
    public string color;
    public string duenio;
    public bool tuvoService;
    public int kilometrajeService;
}

class Program
{
    static void Main(string[] args)
    {
        const int MAX_TESLAS = 100;
        Tesla[] teslas = new Tesla[MAX_TESLAS];
        int numTeslas = 0;

        while (true)
        {
            Console.WriteLine("Ingrese la opcion deseada:");
            Console.WriteLine("1 - Dar de alta un Tesla");
            Console.WriteLine("2 - Eliminar un Tesla");
            Console.WriteLine("3 - Mostrar Teslas que tuvieron service");
            Console.WriteLine("4 - Reordenar lista de Tesla por ano");
            Console.WriteLine("5 - Mostrar el Tesla mas nuevo");
            Console.WriteLine("6 - Salir");
            Console.Write("Opcion: ");
            int opcion = int.Parse(Console.ReadLine() ?? "");
            Console.WriteLine();

            switch (opcion)
            {
                // Se le pide al usuario todos los parametros del Tesla y se da de alta. 
                case 1:
                    if (numTeslas < MAX_TESLAS)
                    {
                        Console.Write("Ingrese el modelo del Tesla: ");
                        string modelo = Console.ReadLine() ?? "";
                        Console.Write("Ingrese el anio del Tesla: ");
                        int anio = int.Parse(Console.ReadLine() ?? "");
                        Console.Write("Ingrese el kilometraje actual: ");
                        int kilometrajeActual = int.Parse(Console.ReadLine() ?? "");
                        Console.Write("Ingrese el color del Tesla: ");
                        string color = Console.ReadLine() ?? "";
                        Console.Write("Ingrese el duenio del Tesla: ");
                        string duenio = Console.ReadLine() ?? "";
                        Console.Write("El auto tuvo service? (s/n): ");
                        char tuvoService = char.Parse(Console.ReadLine() ?? "");


                        Tesla auto = new Tesla();
                        auto.modelo = modelo;
                        auto.anio = anio;
                        auto.kilometrajeActual = kilometrajeActual;
                        auto.color = color;
                        auto.duenio = duenio;
                        if (char.ToLower(tuvoService) == 's')
                        {
                            auto.tuvoService = true;
                            Console.Write("Ingrese el kilometraje de service: ");
                            auto.kilometrajeService = int.Parse(Console.ReadLine() ?? "");
                        }
                        else
                            auto.tuvoService = false;

                        teslas[numTeslas] = auto;
                        numTeslas++;
                        Console.WriteLine("El Tesla se dio de alta exitosamente.\n");
                    }
                    else
                    {
                        Console.WriteLine("No se pueden agregar mas Teslas.\n");
                    }
                    break;
                

                // Se le pide al usuario el nombre del dueño del Tesla, recorre el array y si lo encuentra se elimina
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
                            Console.WriteLine("El Tesla se eliminó exitosamente.\n");
                            break;
                        }
                    }
                    if (!encontrado)
                    {
                        Console.WriteLine("El Tesla no se encontró.\n");
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
                                $"Año: {teslas[auto].anio}\n" +
                                $"Dueño: {teslas[auto].duenio}\n" +
                                $"Kilometraje de service: {teslas[auto].kilometrajeService}\n");
                            serviceEncontrado = true;
                        }
                    }

                    if (!serviceEncontrado)
                    {
                        Console.WriteLine("No hay Teslas que tuvieron service.\n");
                    }

                    break;

                // case 4:
                //    for (int auto = 0; auto < numTeslas - 1; auto++)
                //    {
                //        for (int indexAuto = auto + 1; indexAuto < numTeslas; indexAuto++)
                //        {
                //            if (teslas[auto].anio > teslas[indexAuto].anio)
                //            {
                //                Tesla temp = teslas[auto];
                //                teslas[auto] = teslas[indexAuto];
                //                teslas[indexAuto] = temp;
                //            }
                //        }
                //    }
                //    Console.WriteLine("La lista de Teslas se ordenó por año.");
                //    break;

                // case 5:
                //        int maxAnio = -1;
                //        int indexMaxAnio = -1;
                //        for (int auto = 0; auto < numTeslas; auto++)
                //        {
                //            if (anos[i] > max_ano)
                //            {
                //                max_ano = anos[i];
                //                index_max_ano = i;
                //            }
                //        }

                //        if (index_max_ano >= 0)
                //        {
                //            Console.WriteLine("El Tesla mas nuevo es el modelo {0} del año {1}.", modelos[index_max_ano], anos[index_max_ano]);
                //        }
                //        else
                //        {
                //            Console.WriteLine("No hay Tesla dados de alta.");
                //        }

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