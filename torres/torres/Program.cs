using System;
using System.Collections.Generic;

class TowersOfHanoi
{
    static Stack<int> source = new Stack<int>();
    static Stack<int> auxiliary = new Stack<int>();
    static Stack<int> destination = new Stack<int>();

    static void Main(string[] args)
    {
        Console.Write("Ingrese el número de discos: ");
        int numDisks = int.Parse(Console.ReadLine());

        // Inicializar la torre de origen con discos
        for (int i = numDisks; i >= 1; i--)
        {
            source.Push(i);
        }

        // Resolver las Torres de Hanoi
        SolveHanoi(numDisks, source, destination, auxiliary);

        Console.WriteLine("Movimientos completados. La torre destino contiene:");
        foreach (var disk in destination)
        {
            Console.WriteLine(disk);
        }
    }

    static void SolveHanoi(int n, Stack<int> source, Stack<int> destination, Stack<int> auxiliary)
    {
        if (n == 1)
        {
            MoveDisk(source, destination);
            return;
        }

        // Mover n-1 discos de la fuente al auxiliar
        SolveHanoi(n - 1, source, auxiliary, destination);

        // Mover el disco más grande a la torre destino
        MoveDisk(source, destination);

        // Mover los n-1 discos desde el auxiliar al destino
        SolveHanoi(n - 1, auxiliary, destination, source);
    }

    static void MoveDisk(Stack<int> source, Stack<int> destination)
    {
        if (source.Count > 0)
        {
            int disk = source.Pop();
            destination.Push(disk);
            Console.WriteLine($"Movido disco {disk} de {GetTowerName(source)} a {GetTowerName(destination)}");
        }
    }

    static string GetTowerName(Stack<int> tower)
    {
        if (tower == source) return "Fuente";
        if (tower == destination) return "Destino";
        return "Auxiliar";
    }
}
