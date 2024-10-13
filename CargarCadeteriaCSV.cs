public class CargarDatos
{

    public Cadeteria CargarDatosCadeteria(string nomArchivoCSVCadeteria)
    {
        Cadeteria cadeteria = null;

        string[] lineaCadeteria = File.ReadAllLines(nomArchivoCSVCadeteria);
        string[] primerLinea = lineaCadeteria[0].Split(',');
        string[] dato = lineaCadeteria[1].Split(',');
        cadeteria = new Cadeteria(dato[0], dato[1]); 

        return cadeteria;
    }

    public List<Cadete> CargarDatosCadetes(string nomArchivoCSVCadete)
    {
        List<Cadete> listaCadetes = new List<Cadete>();

        string[] lineaCadete = File.ReadAllLines(nomArchivoCSVCadete);

        foreach(string linea in lineaCadete.Skip(1)) //skip salta un numero especifico de elementos
        {
            string[] dato = linea.Split(',');
            Cadete cadete = new Cadete(
                int.Parse(dato[0]),
                dato[1],
                dato[2],
                dato[3],
                int.Parse(dato[4])
            );

            listaCadetes.Add(cadete);
        }

        return listaCadetes;
    }

}