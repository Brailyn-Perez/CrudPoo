using CrudCoches.Controllers;
using CrudCoches.Models;

internal class Program
{
    private static void Main(string[] args)
    {
        var CAutomoviles = new AutomovilesController();
        var MAutomoviles = new AutomovilesModel();

        Console.WriteLine("Bienvenido al sistema de coches B.P\n" +
            "Que desea hacer?\n" +
            "1)Ver coches\n" +
            "2)Editar coches\n" +
            "3)Eliminar coches\n" +
            "4)Agregar Coches\n");
        
        string resp =  Console.ReadLine();
        Console.Clear();


        switch (resp)
        {
            case "1":
                foreach (var ListaMostrar in CAutomoviles.GetAutomoviles())
                {
                    Console.WriteLine
                        (
                        $"ID: {ListaMostrar.id}\n" +
                        $"Nombre: {ListaMostrar.nombre}\n" +
                        $"Marca: {ListaMostrar.marca}\n" +
                        $"Color: {ListaMostrar.color}\n" +
                        $"Placa: {ListaMostrar.placa}\n" +
                        $"Precio: {ListaMostrar.precio}\n" +
                        $"___________________________________________________\n"
                        );
                }
            break;

            case "2":
                Console.WriteLine("id a editar");
                int id = int.Parse( Console.ReadLine() );
                Console.WriteLine("color");
                string color = Console.ReadLine();
                Console.WriteLine("precio");
                string precio =  Console.ReadLine();


                CAutomoviles.EditAutomoviles(new AutomovilesModel
                {
                    id = id,
                    color = color,
                    precio = precio
                });
            break;

            case "3":
                Console.WriteLine("id a Eliminar");
                int idDelete = int.Parse(Console.ReadLine());
                CAutomoviles.DeleteAutmoviles(idDelete);
                break;

            case "4":
                Console.WriteLine("Ingresar nuevo automovil");
                Console.WriteLine("Nombre del automovil");
                string Snombre = Console.ReadLine();
                Console.WriteLine("Marca del automovil");
                string Smarca = Console.ReadLine();
                Console.WriteLine("Color del automovil");
                string Scolor = Console.ReadLine();
                Console.WriteLine("Placa del automovil");
                string Splaca = Console.ReadLine();
                Console.WriteLine("Precio del automovil");
                string Sprecio = Console.ReadLine();

                CAutomoviles.SetAutomoviles(new AutomovilesModel
                {
                    nombre = Snombre,
                    marca = Smarca,
                    color = Scolor,
                    placa = Splaca,
                    precio = Sprecio
                });
                break;
        }









        Console.ReadKey();
    }
}