using System;

class Empleado
{
    public string Cedula { get; set; }
    public string Nombre { get; set; }
    public string Direccion { get; set; }
    public string Telefono { get; set; }
    public double Salario { get; set; }

    public Empleado(string cedula, string nombre, string direccion, string telefono, double salario)
    {
        Cedula = cedula;
        Nombre = nombre;
        Direccion = direccion;
        Telefono = telefono;
        Salario = salario;
    }
}

class Menu
{
    private Empleado[] empleados;
    private int cantidadEmpleados;

    public Menu(int capacidad)
    {
        empleados = new Empleado[capacidad];
        cantidadEmpleados = 0;
    }

    public void MostrarMenu()
    {
        Console.WriteLine("Menú Principal:");
        Console.WriteLine("1. Agregar Empleados");
        Console.WriteLine("2. Consultar Empleados");
        Console.WriteLine("3. Modificar Empleados");
        Console.WriteLine("4. Borrar Empleados");
        Console.WriteLine("5. Inicializar Arreglos");
        Console.WriteLine("6. Reportes");
        Console.WriteLine("7. Salir");
    }

    public void AgregarEmpleado()
    {
        Console.WriteLine("Ingrese los datos del empleado:");
        Console.Write("Cédula: ");
        string cedula = Console.ReadLine();
        Console.Write("Nombre: ");
        string nombre = Console.ReadLine();
        Console.Write("Dirección: ");
        string direccion = Console.ReadLine();
        Console.Write("Teléfono: ");
        string telefono = Console.ReadLine();
        Console.Write("Salario: ");
        double salario = Convert.ToDouble(Console.ReadLine());

        if (cantidadEmpleados < empleados.Length)
        {
            empleados[cantidadEmpleados] = new Empleado(cedula, nombre, direccion, telefono, salario);
            cantidadEmpleados++;
            Console.WriteLine("Empleado agregado exitosamente.");
        }
        else
        {
            Console.WriteLine("No se pueden agregar más empleados, se ha alcanzado el limite");
        }
    }

    public void ConsultarEmpleados()
    {
        Console.WriteLine("Ingrese el número de cédula del empleado que desea consultar:");
        string cedula = Console.ReadLine();
        bool encontrado = false;

        foreach (var empleado in empleados)
        {
            if (empleado != null && empleado.Cedula == cedula)
            {
                Console.WriteLine("Información del empleado:");
                Console.WriteLine($"Cédula: {empleado.Cedula}");
                Console.WriteLine($"Nombre: {empleado.Nombre}");
                Console.WriteLine($"Dirección: {empleado.Direccion}");
                Console.WriteLine($"Teléfono: {empleado.Telefono}");
                Console.WriteLine($"Salario: {empleado.Salario:C}");
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }

    public void ModificarEmpleado()
    {
        Console.WriteLine("Ingrese el número de cédula del empleado que desea modificar:");
        string cedula = Console.ReadLine();
        bool encontrado = false;

        for (int i = 0; i < cantidadEmpleados; i++)
        {
            if (empleados[i] != null && empleados[i].Cedula == cedula)
            {
                Console.WriteLine("Ingrese los nuevos datos del empleado:");
                Console.Write("Nombre: ");
                empleados[i].Nombre = Console.ReadLine();
                Console.Write("Dirección: ");
                empleados[i].Direccion = Console.ReadLine();
                Console.Write("Teléfono: ");
                empleados[i].Telefono = Console.ReadLine();
                Console.Write("Salario: ");
                empleados[i].Salario = Convert.ToDouble(Console.ReadLine());
                Console.WriteLine("Empleado modificado con éxito.");
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }

    public void BorrarEmpleado()
    {
        Console.WriteLine("Ingrese el número de cédula del empleado que desea borrar:");
        string cedula = Console.ReadLine;
        bool encontrado = false;

        for (int i = 0; i < cantidadEmpleados; i++)
        {
            if (empleados[i] != null && empleados[i].Cedula == cedula)
            {
                // Mover el último empleado en la lista a la posición actual y disminuir la cantidad de empleados
                empleados[i] = empleados[cantidadEmpleados - 1];
                empleados[cantidadEmpleados - 1] = null;
                cantidadEmpleados--;
                Console.WriteLine("Empleado eliminado exitosamente.");
                encontrado = true;
                break;
            }
        }

        if (!encontrado)
        {
            Console.WriteLine("Empleado no encontrado.");
        }
    }

    public void InicializarArreglos()
    {
        empleados = new Empleado[empleados.Length];
        cantidadEmpleados = 0;
        Console.WriteLine("Arreglos inicializados con éxito.");
    }

    public void Reportes()
    {
        bool salir = false;
        while (!salir)
        {
            Console.WriteLine("Menú de Reportes:");
            Console.WriteLine("1. Consultar empleados con número de cédula");
            Console.WriteLine("2. Listar todos los empleados ordenados por nombre");
            Console.WriteLine("3. Calcular y mostrar el promedio de los salarios");
            Console.WriteLine("4. Calcular y mostrar el salario más alto y el más bajo");
            Console.WriteLine("5. Volver al Menú Principal");
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    Console.WriteLine("Ingrese el número de cédula del empleado que desea consultar:");
                    string cedula = Console.ReadLine();
                    foreach (var empleado in empleados)
                    {
                        if (empleado != null && empleado.Cedula == cedula)
                        {
                            Console.WriteLine("Información del empleado:");
                            Console.WriteLine($"Cédula: {empleado.Cedula}");
                            Console.WriteLine($"Nombre: {empleado.Nombre}");
                            Console.WriteLine($"Dirección: {empleado.Direccion}");
                            Console.WriteLine($"Teléfono: {empleado.Telefono}");
                            Console.WriteLine($"Salario: {empleado.Salario:C}");
                            break;
                        }
                    }
                    break;
                case 2:
                    ListarEmpleadosOrdenadosPorNombre();
                    break;
                case 3:
                    CalcularPromedioSalarios();
                    break;
                case 4:
                    CalcularSalarioMaximoMinimo();
                    break;
                case 5:
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    break;
            }
        }
    }

    private void ListarEmpleadosOrdenadosPorNombre()
    {
        Array.Sort(empleados, 0, cantidadEmpleados, new Comparison<Empleado>((x, y) => string.Compare(x.Nombre, y.Nombre)));
        Console.WriteLine("Empleados ordenados por nombre:");
        for (int i = 0; i < cantidadEmpleados; i++)
        {
            Console.WriteLine($"Nombre: {empleados[i].Nombre}, Cédula: {empleados[i].Cedula}");
        }
    }

    private void CalcularPromedioSalarios()
    {
        double totalSalarios = 0;
        foreach (var empleado in empleados)
        {
            if (empleado != null)
            {
                totalSalarios += empleado.Salario;
            }
        }
        double promedio = totalSalarios / cantidadEmpleados;
        Console.WriteLine($"El promedio de los salarios es: {promedio:C}");
    }

    private void CalcularSalarioMaximoMinimo()
    {
        double salarioMaximo = double.MinValue;
        double salarioMinimo = double.MaxValue;
        foreach (var empleado in empleados)
        {
            if (empleado != null)
            {
                if (empleado.Salario > salarioMaximo)
                {
                    salarioMaximo = empleado.Salario;
                }
                if (empleado.Salario < salarioMinimo)
                {
                    salarioMinimo = empleado.Salario;
                }
            }
        }
        Console.WriteLine($"Salario más alto: {salarioMaximo:C}");
        Console.WriteLine($"Salario más bajo: {salarioMinimo:C}");
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Bienvenido al Sistema de Recursos Humanos");

        Console.Write("Ingrese la cantidad máxima de empleados que puede manejar el sistema: ");
        int capacidadMaxima = Convert.ToInt32(Console.ReadLine());
        Menu menu = new Menu(capacidadMaxima);

        bool salir = false;
        while (!salir)
        {
            menu.MostrarMenu();
            int opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    menu.AgregarEmpleado();
                    break;
                case 2:
                    menu.ConsultarEmpleados();
                    break;
                case 3:
                    menu.ModificarEmpleado();
                    break;
                case 4:
                    menu.BorrarEmpleado();
                    break;
                case 5:
                    menu.InicializarArreglos();
                    break;
                case 6:
                    menu.Reportes();
                    break;
                case 7:
                    salir = true;
                    break;
                default:
                    Console.WriteLine("Opción invalida. vuelva a intentar.");
                    break;
            }
        }

        Console.WriteLine("Gracias por utilizar el Sistema de Recursos Humanos.");
    }
}


