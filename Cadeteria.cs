using System.Runtime.CompilerServices;
using System.IO; // ESTO ME SIRVE PARA LEER ARCHIVOS Y PROCESARLOS
using System.Linq; 
public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadetes;
    private List<Pedidos> listadoPedidos; //Hago el listado de los pedidos

    
    public List<Cadete> ListadoCadetes { get => listadoCadetes; private set => listadoCadetes = value; }
    public List<Pedidos> ListadoPedidos { get => listadoPedidos; set => listadoPedidos = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }

    //Este constructor lo hice con la lupita
    public Cadeteria(string nombre, string telefono)
    {
        this.Nombre = nombre;
        this.Telefono = telefono;
        this.ListadoCadetes = new List<Cadete>();
        this.ListadoPedidos = new List<Pedidos>();
    }

    public bool AsignarCadeteAPedido(Cadete cadete, Pedidos pedido) //Como ahora los pedidos los trata la Cadeteria, decidí que al pedido se le asigne un Cadete y no al revés.
    {
        if (pedido != null && cadete != null)
        {
            pedido.Cadete = cadete; 
            Console.WriteLine($"El Pedido N° {pedido.Nro} fue asignado al Cadete de ID {cadete.Id} con nombre {cadete.Nombre}");
            return true;
        }
        else
        {
            //Console.WriteLine("No se pudo asignar un cadete al pedido.");
            return false;
        }
    }

    public bool reasignarPedidoCadete(Cadete cadAnt, Cadete cadNuevo, Pedidos pedido)
    {
        if (cadAnt != null && cadNuevo != null && pedido != null)
        {
            pedido.Cadete = cadNuevo;
            Console.WriteLine($"El Pedido N° {pedido.Nro} se reasigno al Cadete de ID {cadNuevo.Id} con nombre {cadNuevo.Nombre}");
            return true;
        }
        else
        {
            //Console.WriteLine("No se pudo reasignar el pedido a otro cadete.");
            return false;
        }
    }

    public bool EliminarCadete (Cadete cadete)
    {
        if (listadoCadetes.Remove(cadete)) // es decir que si se pudo eliminar
        {
            Console.WriteLine($"Cadete {cadete.Nombre} fue eliminado.");
            return true;
        }
        else
        {
            //Console.WriteLine("No se pudo eliminar al cadete.");
            return false;
        }
    }

    public bool AgregarPedido(Pedidos pedido) //Ahora agrego un pedido al listado de pedidos.
    {
        if (pedido != null)
        {
            listadoPedidos.Add(pedido);
            Console.WriteLine($"Pedido {pedido.Nro} agregado a la lista.");
            return true;
        }
        else
        {
            //Console.WriteLine("El pedido no se pudo agregar a la lista.");
            return false;
        }
    }

    public bool EliminarPedido(Pedidos pedido) //En este caso, ahora el método eliminará un pedido de la lista global de pedidos.
    {
        if (listadoPedidos.Remove(pedido))
        {
            Console.WriteLine($"El Pedido N° {pedido.Nro} fue eliminado.");
            return true;
        }
        else
        {
            //Console.WriteLine("No pudo eliminarse el pedido.");
            return false;
        }
    }

    public int JornalACobrar(int idCadete)
    {
        var cadete = ListadoCadetes.FirstOrDefault(c => c.Id == idCadete);
        if(cadete != null)
        {
            int pedidosRealizados = ListadoPedidos.Count(p => p.Cadete != null && p.Cadete.Id == idCadete);
            int total = cadete.GananciaDia(pedidosRealizados);

            return total;
        }
        else
        {
            //Console.WriteLine("No encontramos al cadete para calcular su gananacia.");
            return 0;
        }
    }
    
    public void CargarListaCadete(List<Cadete> cadetes)
    {
        this.listadoCadetes = cadetes;
    }

    public bool CambiarEstadoPedido(int nroPed, Pedidos.Estado nuevoEstado)
    {
        var pedido = listadoPedidos.FirstOrDefault(p => p.Nro == nroPed);

        if (pedido != null)
        {
            pedido.CambiarEstado(nuevoEstado);
            Console.WriteLine($"Estado del Pedido N° {pedido.Nro} actualizado a {nuevoEstado}");
            return true;
        }
        else
        {
            //Console.WriteLine("El Pedido no fue encontrado");
            return false;
        }
    }

    public void MostrarInforme()
    {
        Console.WriteLine("==INFORME DIARIO==");

        int totalPedidos = 0;
        int totalGanancia = 0;

        foreach (var cadete in listadoCadetes)
        {
            int cantPedidos = listadoPedidos.Count(p => p.Cadete != null && p.Cadete.Id == cadete.Id);
            int ganancia = cadete.GananciaDia(cantPedidos);

            Console.WriteLine($"Cadete: {cadete.Nombre}");
            Console.WriteLine($"Cantidad de Pedidos Realizados: {cantPedidos}");
            Console.WriteLine($"Ganancia del Dia: {ganancia}");

            totalPedidos = totalPedidos + cantPedidos;
            totalGanancia = totalGanancia + ganancia;
        }

        Console.WriteLine($"Total de Pedidos: {totalPedidos}");
        Console.WriteLine($"Total Ganado: {totalGanancia}");

        if (totalPedidos > 0)
        {
            float promPedidos = totalPedidos / (float)ListadoPedidos.Count();
            Console.WriteLine($"Promedio de pedidos por cadetes: {promPedidos:F2}");
        }
        else
        {
            Console.WriteLine("No hay pedidos realizados");
        }
        Console.ReadKey();
    }

    
}