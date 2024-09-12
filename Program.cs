class Program
{

    Cadeteria cadeteria = new Cadeteria("Cadeteria1", "123123445232", new List<Cadete>());

    static void Main()
    {

        int esc = 1;

        while (esc != 0)
        {
            Console.WriteLine("=====SERVICIO DE CADETERIA=====");
            Console.WriteLine("1 - DAR DE ALTA PEDIDO");
            Console.WriteLine("2 - ASIGNAR PEDIDO A UN CADETE");
            Console.WriteLine("3 - CAMBIAR ESTADO DE UN PEDIDO");
            Console.WriteLine("4 - REASIGNAR PEDIDO A OTRO CADETE");
            Console.WriteLine("5 - MOSTRAR INFORME");
            Console.WriteLine("6 - SALIR");

            switch (Console.ReadLine())
            {
                case "1":
                    //DarDeAltaPedido(cadeteria);
                    break;
                case "2":
                    //AsignarPedidoACadete(cadeteria);
                    break;
                case "3":
                   //CambiarEstadoPedido(cadeteria);
                    break;
                case "4":
                    //ReasignarPedido(cadeteria);
                    break;
                case "5":
                    //MostrarInforme(cadeteria);
                    break;
                case "6":
                    esc = 0;
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }



    }
    
}