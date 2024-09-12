class Program
{

    static void Main()
    {

    Cadeteria miCadeteria = new Cadeteria("Cadeteria Natalia", "4205467", new List<Cadete>());

        int esc = 1;

        while (esc != 0)
        {
            Console.WriteLine("=====SERVICIO DE CADETERIA=====");
            Console.WriteLine("1 - AGREGAR NUEVO CADETE");
            Console.WriteLine("2 - ASIGNAR PEDIDO A UN CADETE");
            Console.WriteLine("3 - CAMBIAR ESTADO DE UN PEDIDO");
            Console.WriteLine("4 - REASIGNAR PEDIDO A OTRO CADETE");
            Console.WriteLine("5 - ELIMINAR PEDIDO");
            Console.WriteLine("6 - DAR DE ALTA PEDIDO");
            Console.WriteLine("7 - MOSTRAR INFORME");
            Console.WriteLine("8 - SALIR");

            switch (Console.ReadLine())
            {
                case "1":
                    miCadeteria.AgregarCadete();
                    break;
                case "2":
                    AsignandoPedido(miCadeteria);
                    break;
                case "3":
                    CambiarEstadoPedido(miCadeteria);
                    break;
                case "4":
                    ReasignarPedido(miCadeteria);
                    break;
                case "5":
                    EliminarPedido(miCadeteria);
                    break;
                case "6":
                    DarDeAltaPedido(miCadeteria);
                    break;
                case "7":
                    
                    break;
                case "8":
                    esc = 0;
                    break;
                default:
                    Console.WriteLine("Opción no válida");
                    break;
            }
        }

        static void AsignandoPedido(Cadeteria miCadeteria)
        {
            Console.WriteLine("===ASIGNAR PEDIDO A CADETE===");
            Console.WriteLine("==ID DEL CADETE==");
            int idCadete = int.Parse(Console.ReadLine());

            Cadete cad = miCadeteria.ListadoCadetes1.Find(c => c.Id == idCadete); //El método Find me permite buscar y me devuelve el primer elemento de una lista que cumple con la condicion que establezco en este caso que el id ingresado sea igual al del cadete

            if(cad != null)
            {
                Console.WriteLine("==ID DEL PEDIDO==");
                int idPedido = int.Parse(Console.ReadLine());

                Pedidos pedido = miCadeteria.ListaDePedidos.Find(p => p.Nro == idPedido);
                miCadeteria.AsignarPedidoACadete(cad, pedido);
            }
            else
            {
                Console.WriteLine("===ERROR | CADETE NO ENCONTRADO===");
            }
        }

        static void CambiarEstadoPedido(Cadeteria miCadeteria)
        {
            Console.WriteLine("===CAMBIAR ESTADO DEL PEDIDO===");
            Console.WriteLine("==ID DEL PEDIDO==");
            int idPedido = int.Parse(Console.ReadLine());
            
            Pedidos pedido = miCadeteria.ListaDePedidos.Find(p => p.Nro == idPedido);

            if (pedido != null)
            {
                Console.WriteLine("===SELECCIONE EL NUEVO ESTADO DEL PEDIDO===");
                Console.WriteLine("1 - Preparacion");
                Console.WriteLine("2 - EnCamino");
                Console.WriteLine("3 - Entregado");

                int opc = int.Parse(Console.ReadLine());

                Pedidos.Estado nuevoEstado = (Pedidos.Estado)opc - 1;

                miCadeteria.CambiarEstadoDelPedido(pedido, nuevoEstado);
            }
            else
            {
                Console.WriteLine("===ERROR | PEDIDO NO ENCONTRADO===");
            }
        }

        static void ReasignarPedido(Cadeteria miCadeteria)
        {
            Console.WriteLine("===REASIGNAR PEDIDO A OTRO CADETE===");
            Console.WriteLine("ID DEL CADETE ORIGINAL");
            int idCad = int.Parse(Console.ReadLine());

            Cadete cadeteOriginal = miCadeteria.ListadoCadetes1.Find(c => c.Id == idCad);

            if (cadeteOriginal != null)
            {
                Console.WriteLine("===ID DEL CADETE A ASIGNAR===");
                int idCadDest= int.Parse(Console.ReadLine());

                Cadete cadeteDestino = miCadeteria.ListadoCadetes1.Find(c => c.Id == idCadDest);

                if (cadeteDestino != null)
                {
                    Console.Write("==ID DEL PEDIDO==");
                    int idPedido = int.Parse(Console.ReadLine());

                    Pedidos pedido = miCadeteria.ListaDePedidos.Find(p => p.Nro == idPedido);
                    miCadeteria.ReasignarPedido(cadeteOriginal, cadeteDestino, pedido);
                }
                else
                {
                    Console.WriteLine("===ERROR | CADETE DESTINO NO ENCONTRADO===");
                }
            }
            else
            {
                Console.WriteLine("===ERROR | CADETE ORIGINAL NO ENCONTRADO===");
            }
        }

        static void EliminarPedido(Cadeteria miCadeteria)
        {
            Console.WriteLine("=== ELIMINAR PEDIDO ===");
            Console.Write("==ID DEL CADETE==");
            int idCadete = int.Parse(Console.ReadLine());

            Cadete cadete = miCadeteria.ListadoCadetes1.Find(c => c.Id == idCadete);

            if (cadete != null)
            {
                Console.Write("==ID DEL PEDIDO==");
                int idPedido = int.Parse(Console.ReadLine());

                Pedidos pedido = miCadeteria.ListaDePedidos.Find(p => p.Nro == idPedido);
                miCadeteria.EliminarPedido(cadete, pedido);
            }
            else
            {
                Console.WriteLine("===ERROR | CADETE NO ENCONTRADO===");
            }
        }

        static void DarDeAltaPedido(Cadeteria cadeteria)
        {
            Console.WriteLine("===DAR DE ALTA UN NUEVO PEDIDO===");
            Console.Write("==NOMBRE DEL CLIENTE==");
            string nombreCliente = Console.ReadLine();

            Console.Write("==DIRECCION DEL CLIENTE==");
            string direccion = Console.ReadLine();

            Console.Write("==TELEFONO DEL CLIENTE==");
            string telefono = Console.ReadLine();

            Console.Write("==REFERENCIA DE LA DIRECCION DEL CLIENTE==");
            string refDireccion = Console.ReadLine();

            Console.Write("==OBSERVACIONES==");
            string observaciones = Console.ReadLine();

            cadeteria.DarDeAltaPedido(nombreCliente, direccion, telefono, refDireccion, observaciones);
        }

    }
    
}