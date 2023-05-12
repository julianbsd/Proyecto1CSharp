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
        int num_teslas = 0;

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
                case 1:
                    if (num_teslas < MAX_TESLAS)
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

                        teslas[num_teslas] = auto;
                        num_teslas++;
                        Console.WriteLine("El Tesla se dio de alta exitosamente.\n");
                    }
                    else
                    {
                        Console.WriteLine("No se pueden agregar mas Teslas.\n");
                    }
                    break;

                case 2:
                    Console.Write("Ingrese el duenio del Tesla que desea eliminar: ");
                    string autoAEliminar = Console.ReadLine() ?? "";
                    bool encontrado = false;
                    for (int auto = 0; auto < num_teslas; auto++)
                    {
                        if (teslas[auto].duenio == autoAEliminar)
                        {
                            for (int numAuto = auto; numAuto < num_teslas - 1; numAuto++)
                            {
                                teslas[numAuto] = teslas[numAuto + 1];
                            }
                            num_teslas--;
                            encontrado = true;
                            Console.WriteLine("El Tesla se eliminó exitosamente.\n");
                            break;
                        }
                    }
                    if (!encontrado)
                    {
                        Console.WriteLine("El Tesla no se encontró.\n");
                    }
                    break;

                case 3:
                    Console.WriteLine("Lista de Teslas que tuvieron service:");
                    bool serviceEncontrado = false;

                    // Si hay algun auto que tuvo service muestra los datos
                    for (int auto = 0; auto < num_teslas; auto++)
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
            }

                //case 4:
                //    for (int auto = 0; auto < num_teslas - 1; auto++)
                //    {
                //        for (int numAuto = auto + 1; numAuto < num_teslas; numAuto++)
                //        {
                //            if (teslas[auto].anio > teslas[numAuto].anio)
                //            {
                //                Tesla temp = teslas[auto];
                //                teslas[auto] = teslas[numAuto];
                //                teslas[numAuto] = temp;
                //            }
                //        }
                //    }
                //    Console.WriteLine("La lista de Teslas se ordenó por año.");
                //    break;

            //    case 5:
            //        int max_ano = -1;
            //        int index_max_ano = -1;
            //        for (int i = 0; i < num_teslas; i++)
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

            //        Console.WriteLine();

            //    case 6:
            //        Console.WriteLine("Hasta luego!");
            //        return;

            //    default:
            //        Console.WriteLine("Opcion invalida.");
            //        break;
            //}
        }
    }
}