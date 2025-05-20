using System;

public class Class1
{
	public Class1()
	{
    private int[,] distancias;
    private int[,] caminos;
    private List<CVertice> nodos;

    public int[,] Distancias => distancias;
    public int[,] Caminos => caminos;

    public Floyd_Warshall(List<CVertice> nodos, int[,] matriz)
    {
        this.nodos = nodos;
        int n = nodos.Count;
        distancias = new int[n, n];
        caminos = new int[n, n];

        // Inicializar matrices
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                if (i == j)
                {
                    distancias[i, j] = 0;
                    caminos[i, j] = -1;
                }
                else if (matriz[i, j] != 0) // hay arista
                {
                    distancias[i, j] = matriz[i, j];
                    caminos[i, j] = -1;
                }
                else
                {
                    distancias[i, j] = int.MaxValue / 2;
                    caminos[i, j] = -1;
                }
            }
        }

        Ejecutar();
    }

    public void Ejecutar()
    {
        int n = nodos.Count;

        for (int k = 0; k < n; k++)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (distancias[i, k] + distancias[k, j] < distancias[i, j])
                    {
                        distancias[i, j] = distancias[i, k] + distancias[k, j];
                        caminos[i, j] = k;
                    }
                }
            }
        }
    }

    public List<CVertice> ObtenerRuta(int origenValor, int destinoValor)
    {

        int origen = origenValor;
        int destino = destinoValor;
        List<CVertice> ruta = new List<CVertice>();

        if (origen == -1 || destino == -1 || distancias[origen, destino] == int.MaxValue / 2)
            return ruta;

        ConstruirRuta(origen, destino, ruta);
        return ruta;
    }

    private void ConstruirRuta(int origen, int destino, List<CVertice> ruta)
    {
        if (distancias[origen, destino] >= int.MaxValue / 2)
        {
            // No hay camino entre origen y destino
            ruta.Clear();
            return;
        }

        int intermedio = caminos[origen, destino];

        if (intermedio == -1)
        {
            // Camino directo, sin intermedios
            ruta.Add(nodos[origen]);
            if (origen != destino)
                ruta.Add(nodos[destino]);
        }
        else
        {
            //ruta.Add(nodos[intermedio]);
            // Hay un nodo intermedio, se construye recursivamente
            ConstruirRuta(origen, intermedio, ruta);
            ruta.RemoveAt(ruta.Count - 1); // Evita duplicar el nodo intermedio
            ConstruirRuta(intermedio, destino, ruta);

        }
    }



    public int ObtenerDistancia(int origenValor, int destinoValor)
    {

        return distancias[origenValor, destinoValor];
    }
}

public List<CVertice> ObtenerEstacionamientosCercanos(int origenValor, int cantidad = 5)
        {
            List<CVertice> estacionamientosCercanos = new List<CVertice>();
            List<(int indice, int distancia)> distanciasConIndices = new List<(int, int)>();

            // Recopilar distancias desde el nodo de origen a todos los demás nodos
            for (int i = 0; i < nodos.Count; i++)
            {
                if (i != origenValor && distancias[origenValor, i] < int.MaxValue / 2)
                {
                    // Verificar si hay espacios disponibles en el nodo
                    CVfila fila = (CVfila)nodos[i];
                    if (fila.getHayDisponible())
                    {
                        distanciasConIndices.Add((i, distancias[origenValor, i]));
                    }
                }
            }

            // Ordenar por distancia
            distanciasConIndices = distanciasConIndices.OrderBy(x => x.distancia).ToList();

            // Obtener los primeros 'cantidad' estacionamientos más cercanos
            for (int i = 0; i < Math.Min(cantidad, distanciasConIndices.Count); i++)
            {
                estacionamientosCercanos.Add(nodos[distanciasConIndices[i].indice]);
            }

            return estacionamientosCercanos;
        }

    }
}
