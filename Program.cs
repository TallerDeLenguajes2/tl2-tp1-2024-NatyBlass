public class Program
{
    static List<Pedidos> pedidosPend = new List<Pedidos>();

    static void Main(string [] args)
    {

        Console.WriteLine("Que Archivos desea usar para cargar los Datos?");
        Console.WriteLine("1 - CSV");
        Console.WriteLine("2 - JSON");
        int opcionCarga = int.Parse(Console.ReadLine());

        AccesoADatos accesoDatos;
        Cadeteria cadeteria;
        List<Cadete> listaCadetes = null;

        switch (opcionCarga)
        {

            case 1: 
                accesoDatos = new AccesoCSV();
                cadeteria = accesoDatos.CargarDatosCadeteria("assets/Cadeteria.csv"); // .../.../.../assets/Cadeteria.csv -RUTA PARA DEBUGUEAR-
                listaCadetes = accesoDatos.CargarDatosCadetes("assets/Cadetes.csv"); // .../.../.../assets/Cadetes.csv -RUTA PARA DEBUGUEAR-     
                cadeteria.CargarListaCadete(listaCadetes);
                break;

            case 2:
                accesoDatos = new AccesoJson();
                cadeteria = accesoDatos.CargarDatosCadeteria("assets/cadeteria.json");
                listaCadetes = accesoDatos.CargarDatosCadetes("assets/cadetes.json");
                cadeteria.CargarListaCadete(listaCadetes);
                break;
            default:
            Console.WriteLine("Opcion Incorrecta");
                return;
        }

        int salir = 1;

        while(salir != 0)
        {
            Console.WriteLine("--GESTION DE PEDIDOS--");
            Console.WriteLine("1 - Dar de Alta Pedido");
            Console.WriteLine("2 - Asignar Pedido a Cadete");
            Console.WriteLine("3 - Cambiar Estado del Pedido");
            Console.WriteLine("4 - Reasignar Pedido a Nuevo Cadete");
            Console.WriteLine("5 - Mostrar Informe de Cadeteria");
            Console.WriteLine("6 - Salir");

            Console.WriteLine("Ingrese su opcion: ");
            int opc = int.Parse(Console.ReadLine());

            switch(opc)
            {
                case 1:
                    DarDeAltaPedido();
                    break;
                case 2:
                    AsignarPedido(cadeteria);
                    break;
                case 3: 
                    CambiarEstadoPedido(cadeteria);
                    break;
                case 4: 
                    ReasignarPedido(cadeteria);
                    break;
                case 5:
                    MostrarInforme(cadeteria);
                    break;
                case 6: 
                    salir = 0;
                    break;
                default:
                    Console.WriteLine("Opcion ingresada desconocida");
                    break; 
            }
        }
    }

    static void DarDeAltaPedido()
    {
        Console.WriteLine("==DADA DE ALTA DE PEDIDOS==");

        Console.WriteLine("Ingrese el numero del pedido: ");
        int numPedido = int.Parse(Console.ReadLine());
        
        Console.Write("Ingrese las observaciones del pedido: ");
        string obs = Console.ReadLine();
        
        Console.Write("Ingrese el nombre del cliente: ");
        string nombreCliente = Console.ReadLine();
        
        Console.Write("Ingrese la direccion del cliente: ");
        string direccionCliente = Console.ReadLine();
        
        Console.Write("Ingrese el telefono del cliente: ");
        string telefonoCliente = Console.ReadLine();
        
        Console.Write("Ingrese los datos de referencia de la direccion del cliente: ");
        string datosReferencia = Console.ReadLine();

        DatosCliente cliente = new DatosCliente(nombreCliente,direccionCliente, telefonoCliente, datosReferencia);
        Pedidos pedido = new Pedidos(numPedido, obs, cliente, Pedidos.Estado.Preparacion);

        if (pedidosPend != null)
        {
            pedidosPend.Add(pedido);
            Console.WriteLine("El Pedido fue creado y dado de alta.");
        }
        else
        {
            Console.WriteLine("El pedido no fue creado correctamente.");
        }
    }

    static void AsignarPedido(Cadeteria cadeteria)
    {
        Console.WriteLine("==ASIGNAR PEDIDO A CADETE==");

        if (!pedidosPend.Any())
        {
            Console.WriteLine("No hay pedidos Pendientes");
            Console.ReadKey();
            return;
        }
        else
        {
            Console.WriteLine("Pedidos Pendientes: ");
            foreach(var pedidos in pedidosPend)
            {
                Console.WriteLine("=============================");
                Console.WriteLine($"N° de Pedido: {pedidos.Nro}");
                Console.WriteLine($"Cliente: {pedidos.Cliente.Nombre}");
            }

            Console.WriteLine("Ingrese el numero de pedido que desea asignar: ");
            int nroPed = int.Parse(Console.ReadLine());

            Pedidos pedAAsignar = pedidosPend.FirstOrDefault(p => p.Nro == nroPed);

            if (pedAAsignar == null)
            {
                Console.WriteLine("=El pedido no existe=");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("Cadetes Disponibles: ");
                foreach(var cadete in cadeteria.ListadoCadetes)
                {
                    Console.WriteLine("=============================");
                    Console.WriteLine($"ID del Cadete: {cadete.Id}");
                    Console.WriteLine($"Nombre Cadete: {cadete.Nombre}");
                }

                Console.WriteLine("Ingrese el ID del Cadete al que desea Asignarle el pedido: ");
                int idCadete = int.Parse(Console.ReadLine());
                
                Cadete cadAAsignar = cadeteria.ListadoCadetes.FirstOrDefault(c => c.Id == idCadete);

                if(cadAAsignar != null)
                {
                    cadeteria.AsignarCadeteAPedido(cadAAsignar, pedAAsignar);
                    pedidosPend.Remove(pedAAsignar);
                    cadeteria.AgregarPedido(pedAAsignar);

                    Console.WriteLine("El pedido a sido asignado a un cadete.");
                }
                else
                {
                    Console.WriteLine("No se encontro un cadete con el ID ingresado.");
                }
            }
        }

        Console.WriteLine("==ASIGNACION DE PEDIDO TERMINADA==");
    }

    static void CambiarEstadoPedido(Cadeteria cadeteria)
    {
        Console.WriteLine("==CAMBIAR ESTADO DE PEDIDO==");

        Console.WriteLine("Ingresar el numero de pedido: ");
        int numPedido = int.Parse(Console.ReadLine());

        Console.WriteLine("Estados Disponibles: ");
        foreach(var estadoDisp in Enum.GetValues(typeof(Pedidos.Estado)))
        {
            Console.WriteLine($"{(int)estadoDisp} - {estadoDisp}");
        }

        Console.WriteLine("Ingrese el Estado al que desea cambiar: ");
        Pedidos.Estado nuevoEstado = (Pedidos.Estado)int.Parse(Console.ReadLine());

        cadeteria.CambiarEstadoPedido(numPedido, nuevoEstado);
        Console.WriteLine("Presione cualquier tecla para continuar.");
        Console.ReadKey();
    }

    static void ReasignarPedido(Cadeteria cadeteria)
    {
        Console.WriteLine("==REASIGNAR PEDIDO A OTRO CADETE==");

        Console.WriteLine("Ingrese el numero de pedido que desea reasignar: ");
        int numPedido = int.Parse(Console.ReadLine());

        Pedidos pedAReasignar = cadeteria.ListadoPedidos.FirstOrDefault(p => p.Nro == numPedido);
        if (pedAReasignar == null || pedAReasignar.Cadete == null)
        {
            Console.WriteLine("El pedido no existe o no tiene un cadete asignado.");
            return;
        }

        Cadete cadAnterior = pedAReasignar.Cadete;

        Console.WriteLine("Listado de Cadetes disponibles");
        foreach(var cadete in cadeteria.ListadoCadetes)
        {
            Console.WriteLine("=============================");
            Console.WriteLine($"ID del Cadete: {cadete.Id}");
            Console.WriteLine($"Nombre Cadete: {cadete.Nombre}");
        }

        Console.WriteLine("Ingrese el ID del cadete al que desea Asignarle el pedido: ");
        int idNuevoCadete = int.Parse(Console.ReadLine());

        Cadete nuevoCadete = cadeteria.ListadoCadetes.FirstOrDefault(c => c.Id == idNuevoCadete);
        
        if (nuevoCadete != null)
        {
            cadeteria.reasignarPedidoCadete(cadAnterior, nuevoCadete, pedAReasignar);
            Console.WriteLine("Pedido reasignado correctamente.");
        }
        else
        {
            Console.WriteLine("No se encontro al Cadete.");
        }
            
        Console.ReadKey();
    }

    static void MostrarInforme(Cadeteria cadeteria)
    {
        cadeteria.MostrarInforme();
    }

}