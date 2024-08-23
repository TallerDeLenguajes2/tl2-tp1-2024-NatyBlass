# TP 1 TALLER 2

### ● ¿Cuál de estas relaciones considera que se realiza por composición y cuál por agregación?
    Las relaciones que se realizan por composición son:
            Pedido-Cliente
            Cadete-Cadeteria
    Las que se realizan por agregación:
            Cadete-Pedido

### ● ¿Qué métodos considera que debería tener la clase Cadetería y la clase Cadete?
    A la clase Cadeteria podríamos agregarle los métodos:
        AsignarPedido(Cadete cadete, Pedido pedido);
        ReasignarPedido(Cadete cadeteActual, Cadete nuevoCadete, Pedido pedido);

    A la clase Cadete le podría agregar los siguientes métodos:
        VerPedidos();
        AgregarPedido(Pedido pedido);
        Remover Pedido(Pedido pedido);
        

### ● Teniendo en cuenta los principios de abstracción y ocultamiento, que atributos, propiedades y métodos deberían ser públicos y cuáles privados.
    Los campos de las clases Cadeteria, Cadete, Cliente, Pedido, sus campos deberían ser privados con propiedades públicas de get y set.
    Los métodos deben ser públicos.

### ● ¿Cómo diseñaría los constructores de cada una de las clases?
    Para utilizar los constructores en cada clase, diseñaría uno que recibe los datos y otro que sea por defecto.
    Por ejemplo, para la clase Cliente:
    
    **El que recibe los datos**
    
    public DatosCliente(string nombre, string direccion, string telefono, string refDireccion)
    {
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        RefDireccion = refDireccion;
    }
    
    **El constructor por defecto**
    
    public DatosCliente() 
    {
        Nombre = "Desconocido";
        Direccion = "Sin dirección";
        Telefono = "Sin teléfono";
        RefDireccion = "Sin referencia";
    }

    En el caso de la clase Pedidos:

    **El que recibe los datos**

    public Pedidos(int nro, string observacion, Estado estado, DatosCliente cliente)
    {
        Nro = nro;
        Observacion = observacion;
        EstadoPedido = estado;
        Cliente = cliente;
    }

    **El constructor por defecto**

    public Pedidos()
    {
        Nro = 0;
        Observacion = "No hay observacion";
        EstadoPedido = Estado.Preparacion;
        cliente = new DatosCliente(); 
    }

    De la misma forma para las otras clases.


### ● ¿Se le ocurre otra forma que podría haberse realizado el diseño de clases?

