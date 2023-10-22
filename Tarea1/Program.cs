using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido a la tienda de camisas Vasquez");
        Console.WriteLine("Ingrese la cantidad de camisas que quiere comprar: ");
        int cantidad = int.Parse(Console.ReadLine());

        double precio = 50; // Precio de costo de una camisa

        if (cantidad == 1)
        {
            // Si se lleva una camisa, se aplica el precio de costo
            Console.WriteLine("El precio final es: $" + precio);
        }
        else if (cantidad >= 2 && cantidad <= 5)
        {
            // Si se lleva la cantidad entre 2 y 5 camisas, se aplica un descuento del 15%
            double descuento = precio * 0.15;
            double precioTotal = (precio * cantidad) - descuento;
            Console.WriteLine("El precio final con descuento es: $" + precioTotal);
        }
        else if (cantidad > 5)
        {
            // Si se lleva más de 5 camisas, se aplica un descuento del 20%
            double descuento = precio * 0.20;
            double precioTotal = (precio * cantidad) - descuento;
            Console.WriteLine("El precio final con descuento es: $" + precioTotal);
        }
        else
        {
            Console.WriteLine("Cantidad incorrecta. Por favor ingrese un número correcto.");
        }
    }
}


