public class Program
{

    static List<Pedidos> pedidosPend = new List<Pedidos>();

    static void Main(string [] args)
    {

        CargarDatos cargaDeDatos= new CargarDatos();
        Cadeteria cadeteria = cargaDeDatos.CargarDatosCadeteria("assets/Cadeteria.csv"); // .../.../.../assets/Cadeteria.csv -RUTA PARA DEBUGUEAR-
        List<Cadete> listaCadetes = cargaDeDatos.CargarDatosCadetes("assets/Cadetes.csv"); // .../.../.../assets/Cadetes.csv -RUTA PARA DEBUGUEAR-
        cadeteria.CargarListaCadete(listaCadetes);

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

        pedidosPend.Add(pedido);

        Console.WriteLine("El Pedido fue creado y dado de alta.");
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

            var pedAAsignar = pedidosPend.FirstOrDefault(p => p.Nro == nroPed);

            if (pedAAsignar == null)
            {
                Console.WriteLine("=El pedido no existe=");
                Console.ReadKey();
                return;
            }
            else
            {
                Console.WriteLine("Cadetes para Asignar Pedido: ");
                foreach(var cadete in cadeteria.ListadoCadetes)
                {
                    Console.WriteLine("=============================");
                    Console.WriteLine($"ID del Cadete: {cadete.Id}");
                    Console.WriteLine($"Nombre Cadete: {cadete.Nombre}");
                }

                Console.WriteLine("Ingrese el ID del Cadete al que desea Asignarle el pedido: ");
                int idCadete = int.Parse(Console.ReadLine());
                
                var cadAAsignar = cadeteria.ListadoCadetes.FirstOrDefault(c => c.Id == idCadete);

                if(cadAAsignar != null)
                {
                    cadeteria.AsignarPedido(cadAAsignar, pedAAsignar);
                    pedidosPend.Remove(pedAAsignar);
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

        Console.WriteLine("Ingrese el Estado al que desa cambiar: ");
        Pedidos.Estado nuevoEstado = (Pedidos.Estado)int.Parse(Console.ReadLine());

        foreach(var cadete in cadeteria.ListadoCadetes)
        {
            var pedido = cadete.ListadoPedidos.FirstOrDefault(p => p.Nro == numPedido);
            if (pedido != null)
            {
                pedido.CambiarEstadoDelPedido(nuevoEstado);
                Console.WriteLine("El Estado del pedido ha sido actualizado.");
                return;
            }
            else
            {
                Console.WriteLine("Pedido No Encontrado.");
            }
        }

        Console.WriteLine("Presione cualquier tecla para continuar.");
        Console.ReadKey();
    }

    static void ReasignarPedido(Cadeteria cadeteria)
    {
        Console.WriteLine("==REASIGNAR PEDIDO A OTRO CADETE==");

        Console.WriteLine("Ingrese el numero de pedido que desea reasignar: ");
        int pedAReasignar = int.Parse(Console.ReadLine());

        Console.WriteLine("Listado de Cadetes disponibles");
        foreach(var cadete in cadeteria.ListadoCadetes)
        {
            Console.WriteLine("=============================");
            Console.WriteLine($"ID del Cadete: {cadete.Id}");
            Console.WriteLine($"Nombre Cadete: {cadete.Nombre}");
        }

        Console.WriteLine("Ingrese el ID del cadete al que desea Asignarle el pedido: ");
        int idNuevoCadete = int.Parse(Console.ReadLine());

        Cadete cadeteAnterior = cadeteria.ListadoCadetes.FirstOrDefault(c => c.ListadoPedidos.Any(p => p.Nro == pedAReasignar));

        var nuevoCadete = cadeteria.ListadoCadetes.FirstOrDefault(c => c.Id == idNuevoCadete);
        
        if (nuevoCadete != null && cadeteAnterior != null)
        {
            var pedido = cadeteAnterior.ListadoPedidos.FirstOrDefault(p => p.Nro == pedAReasignar);

            if (pedido != null)
            {
                cadeteria.reasignarPedidoCadete(cadeteAnterior, nuevoCadete, pedido);
                Console.WriteLine("Pedido reasignado correctamente.");
                return;
            }
            else
            {
                Console.WriteLine("No se encontró el pedido que desea reasignar.");
            }
        }
        else
        {
            Console.WriteLine("No se encontro al Cadete.");
        }
            
        Console.ReadKey();
    }

    static void MostrarInforme(Cadeteria cadeteria)
    {
        Console.WriteLine("==INFORME DIARIO==");

        var infCadetes = cadeteria.ListadoCadetes.Select(c => new{
            Cadete = c,
            CantidadPedidos = c.ListadoPedidos.Count,
            TotalGanado = c.GananciaDia()
        }).ToList();

        int totalPedidos = 0;
        int totalGanancia = 0;

        foreach (var infCadete in infCadetes)
        {
            Console.WriteLine($"Cadete: {infCadete.Cadete.Nombre}");
            Console.WriteLine($"Cantidad de Pedidos Realizados: {infCadete.CantidadPedidos}");
            Console.WriteLine($"Ganancia del Dia: {infCadete.TotalGanado}");

            totalPedidos = totalPedidos + infCadete.CantidadPedidos;
            totalGanancia = totalGanancia + infCadete.TotalGanado;
        }

        float promPedidos = totalPedidos / (int)infCadetes.Count();

        Console.WriteLine($"Total de Pedidos: {totalPedidos}");
        Console.WriteLine($"Total Ganado: {totalGanancia}");
        Console.WriteLine($"Promedio de pedidos por cadetes: {promPedidos}");

        Console.ReadKey();
    }
}