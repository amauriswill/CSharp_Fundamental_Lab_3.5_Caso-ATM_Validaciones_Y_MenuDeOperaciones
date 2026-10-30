using System.Text;

ConfigurarConsola();

string cliente = "Ana Pérez";
string numeroCuenta = "100245";
bool cuentaActiva = true;
decimal saldo = 10000.00m;

MostrarInformacionCuenta(cliente, numeroCuenta, cuentaActiva, saldo);
MostrarMenu();

Console.Write("Seleccione una opción: ");
string entradaOpcion = Console.ReadLine() ?? string.Empty;

static void ConfigurarConsola()
{
    Console.OutputEncoding = Encoding.UTF8;
    Console.InputEncoding = Encoding.UTF8;
}

static void MostrarInformacionCuenta(string cliente, string cuenta, bool activa, decimal saldo)
{
    Console.WriteLine("========================================");
    Console.WriteLine("        SISTEMA DE CAJERO (ATM)         ");
    Console.WriteLine("========================================");
    Console.WriteLine($"Cliente: {cliente}");
    Console.WriteLine($"Cuenta:  {cuenta}");
    Console.WriteLine($"Estado:  {(activa ? "Activa" : "Inactiva")}");
    Console.WriteLine($"Saldo:   RD${saldo:N2}");
    Console.WriteLine("========================================");
    Console.WriteLine();
}

static void MostrarMenu()
{
    Console.WriteLine("MENÚ DE OPERACIONES");
    Console.WriteLine("1. Consultar saldo");
    Console.WriteLine("2. Depositar");
    Console.WriteLine("3. Retirar");
    Console.WriteLine("4. Salir");
    Console.WriteLine("========================================");
}
