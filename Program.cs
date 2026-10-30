using System.Globalization;
using System.Text;

ConfigurarConsola();

string cliente = "Amauris WIllmore";
string numeroCuenta = "1003142";
bool cuentaActiva = !args.Contains("--inactiva", StringComparer.OrdinalIgnoreCase);
decimal saldo = 10000.00m;

MostrarInformacionCuenta(cliente, numeroCuenta, cuentaActiva, saldo);
MostrarMenu();

Console.Write("Seleccione una opción: ");
string entradaOpcion = Console.ReadLine()?.Trim() ?? string.Empty;

if (!int.TryParse(entradaOpcion, out int opcion))
{
    MostrarError("Entrada no válida. Debe ingresar un número de opción.");
    return;
}

switch (opcion)
{
    case 1:
        ConsultarSaldo(saldo);
        break;
    case 2:
        ProcesarDeposito(ref saldo, cuentaActiva);
        break;
    case 3:
        ProcesarRetiro(ref saldo, cuentaActiva);
        break;
    case 4:
        MostrarDespedida();
        break;
    default:
        MostrarError("Opción no válida. Seleccione una opción entre 1 y 4.");
        break;
}

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
    Console.WriteLine($"Saldo:   RD${saldo.ToString("N2", CultureInfo.InvariantCulture)}");
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

static void ConsultarSaldo(decimal saldo)
{
    Console.WriteLine();
    Console.WriteLine("----------------------------------------");
    Console.WriteLine("         CONSULTA DE SALDO              ");
    Console.WriteLine("----------------------------------------");
    Console.WriteLine($"Saldo disponible: RD${saldo.ToString("N2", CultureInfo.InvariantCulture)}");
    Console.WriteLine("----------------------------------------");
}

static void ProcesarDeposito(ref decimal saldo, bool cuentaActiva)
{
    Console.WriteLine("\n--- Operación: Depósito ---");

    if (!cuentaActiva)
    {
        MostrarError("Operación rechazada: La cuenta se encuentra inactiva.");
        return;
    }

    if (!LeerMonto("Ingrese el monto a depositar: ", out decimal monto))
    {
        MostrarError("Operación rechazada: El monto ingresado no es un número válido.");
        return;
    }

    if (monto <= 0)
    {
        MostrarError("Operación rechazada: El monto a depositar debe ser mayor que cero.");
        return;
    }

    decimal saldoAnterior = saldo;
    saldo += monto;
    MostrarConfirmacion("Depósito exitoso", monto, saldoAnterior, saldo);
}

static void ProcesarRetiro(ref decimal saldo, bool cuentaActiva)
{
    Console.WriteLine("\n--- Operación: Retiro ---");

    if (!cuentaActiva)
    {
        MostrarError("Operación rechazada: La cuenta se encuentra inactiva.");
        return;
    }

    if (!LeerMonto("Ingrese el monto a retirar: ", out decimal monto))
    {
        MostrarError("Operación rechazada: El monto ingresado no es un número válido.");
        return;
    }

    if (monto <= 0)
    {
        MostrarError("Operación rechazada: El monto a retirar debe ser mayor que cero.");
        return;
    }

    if (monto > saldo)
    {
        MostrarError("Operación rechazada: Fondos insuficientes para realizar el retiro.");
        return;
    }

    decimal saldoAnterior = saldo;
    saldo -= monto;
    MostrarConfirmacion("Retiro exitoso", monto, saldoAnterior, saldo);
}

static bool LeerMonto(string mensaje, out decimal monto)
{
    Console.Write(mensaje);
    string entrada = Console.ReadLine()?.Replace(',', '.').Trim() ?? string.Empty;
    entrada = entrada.Replace("RD$", "", StringComparison.OrdinalIgnoreCase).Replace("$", "").Trim();
    return decimal.TryParse(entrada, NumberStyles.Any, CultureInfo.InvariantCulture, out monto);
}

static void MostrarConfirmacion(string tipo, decimal monto, decimal saldoAnterior, decimal saldoActual)
{
    Console.WriteLine();
    Console.WriteLine("========================================");
    Console.WriteLine($"         {tipo.ToUpper()}               ");
    Console.WriteLine("========================================");
    Console.WriteLine($"Monto:           RD${monto.ToString("N2", CultureInfo.InvariantCulture)}");
    Console.WriteLine($"Saldo Anterior:  RD${saldoAnterior.ToString("N2", CultureInfo.InvariantCulture)}");
    Console.WriteLine($"Saldo Actual:    RD${saldoActual.ToString("N2", CultureInfo.InvariantCulture)}");
    Console.WriteLine("========================================");
}

static void MostrarDespedida()
{
    Console.WriteLine();
    Console.WriteLine("========================================");
    Console.WriteLine("¡Gracias por utilizar el Sistema ATM!");
    Console.WriteLine("========================================");
}

static void MostrarError(string mensaje)
{
    Console.WriteLine();
    Console.WriteLine($"Error: {mensaje}");
}
