using System.Runtime.CompilerServices;
using System.IO; // ESTO ME SIRVE PARA LEER ARCHIVOS Y PROCESARLOS
using System.Linq; 
public class Cadeteria
{
    private string nombre;
    private string telefono;
    private List<Cadete> listadoCadetes = new List<Cadete>();
    
    public List<Cadete> ListadoCadetes { get => listadoCadetes; private set => listadoCadetes = value; }
    public string Nombre { get => nombre; set => nombre = value; }
    public string Telefono { get => telefono; set => telefono = value; }

    //Este constructor lo hice con la lupita
    public Cadeteria(string nombre, string telefono)
    {
        this.Nombre = nombre;
        this.Telefono = telefono;
        this.ListadoCadetes = new List<Cadete>();
    }

    public void AsignarPedido(Cadete cadete, Pedidos pedido)
    {
        cadete.agregarPedido(pedido);
    }

    public void EliminarCadete(Cadete cadete)
    {
        ListadoCadetes.Remove(cadete);
    }

    public void AgregarCadete(Cadete cadete)
    {
        ListadoCadetes.Add(cadete);
    }

    public void EliminarPedido(Pedidos pedido)
    {
        foreach(var cadete in listadoCadetes)
        {
            cadete.eliminarPedido(pedido);
        }
    }

    public void reasignarPedidoCadete(Cadete cadAnt, Cadete cadNuevo, Pedidos pedido)
    {
        cadAnt.eliminarPedido(pedido);
        cadNuevo.agregarPedido(pedido);
    }
    
    public void CargarListaCadete(List<Cadete> cadetes)
    {
        this.listadoCadetes = cadetes;
    }

    
}