using System.Runtime.CompilerServices;
using System.IO; // ESTO ME SIRVE PARA LEER ARCHIVOS Y PROCESARLOS
using System.Linq; 
public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> ListadoCadetes;

    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }
    public List<Cadete> ListadoCadetes1 { get => ListadoCadetes; set => ListadoCadetes = value; }


    //Este constructor lo hice con la lupita
    public Cadeteria(string nombre, string telefono, List<Cadete> listadoCadetes)
    {
        this.nombre = nombre;
        this.telefono = telefono;
        ListadoCadetes = listadoCadetes;
    }

    private List<Pedidos> listaPedidos = new List<Pedidos>();

    public void AsignarPedidoACadete(Cadete cadete, Pedidos pedido)
    {

        if (cadete == null)
        {
            Console.WriteLine("===ERROR | CADETE NO ENCONTRADO===");
            return;
        }
        else
        {
            if (pedido == null)
            {
                Console.WriteLine("===ERROR | PEDIDO NO ENCONTRADO===");
            return;
            }
        }

        cadete.AgregarPedido(pedido);
        Console.WriteLine("===PEDIDO ASIGNADO EXITOSAMENTE===");

    }

    public void CambiarEstadoDelPedido(Pedidos pedido, Pedidos.Estado nuevoEstado)
    {
        if (pedido == null)
        {
            Console.WriteLine("===ERROR | PEDIDO NO ENCONTRADO===");
            return;
        }

        pedido.EstadoPedido = nuevoEstado;
        Console.WriteLine($"===EL ESTADO DEL PEDIDO {pedido.Nro} HA SIDO CAMBIADO A {nuevoEstado} ===");

    }

    public void ReasignarPedido(Cadete cadeteOriginal, Cadete cadeteDestino, Pedidos pedido)
    {
        cadeteOriginal.RemoverPedido(pedido);
        cadeteDestino.AgregarPedido(pedido);
    }

    public void EliminarPedido(Cadete cadete, Pedidos pedido)
    {
        cadete.ListadoPedidos.Remove(pedido);
        listaPedidos.Remove(pedido);
        Console.WriteLine("===PEDIDO ELIMINADO EXITOSAMENTE===");
    }

    public void DarDeAltaPedido(string nombreCliente, string direccion, string telefono, string refDireccion, string obs)
    { 
        DatosCliente nuevoCliente = new DatosCliente(nombreCliente, direccion, telefono, refDireccion);
        Pedidos nuevoPedido = new Pedidos(listaPedidos.Count + 1, obs, Pedidos.Estado.Preparacion, nuevoCliente);
        listaPedidos.Add(nuevoPedido);

        Console.WriteLine("===PEDIDO CREADO EXITOSAMENTE===");
    }

    public List<Pedidos> ListaDePedidos {get => listaPedidos;}



}