using System;
using System.Collections.Generic;
using System.Linq;

namespace ExamenProgramacionII
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            int opcion = 0;
            int idCliente = 0;
            string cedula = "";
            string nombre = "";
            string apellido = "";
            string numeroTelefonico = "";
            string correo = "";
            string direccion = "";
            List<Cliente> listaClientes = new List<Cliente>();

            // MENU
            void Menu()
            {
                Console.Write("======================== MENU CLIENTES ========================\n1- Crear Cliente\n2- Buscar Cliente\n3- Actualizar Cliente\n4- Borrar Cliente \n5- Buscar Todos\n6- Salir \nDigite la operacion que desea realizar: ");
                int.TryParse(Console.ReadLine(), out opcion);
            }

            Menu(); // Muestra el menú al inicio

            while (opcion != 6)
            {
                switch (opcion)
                {
                    case 1:
                        idCliente++;
                        Console.Write("Ingresar cedula del cliente: ");
                        cedula = Console.ReadLine();

                        Console.Write("Ingresar nombre del cliente: ");
                        nombre = Console.ReadLine();

                        Console.Write("Ingresar apellido del cliente: ");
                        apellido = Console.ReadLine();

                        Console.Write("Ingresar numero del cliente: ");
                        numeroTelefonico = Console.ReadLine();

                        Console.Write("Ingresar correo del cliente: ");
                        correo = Console.ReadLine();

                        Console.Write("Ingresar direccion del cliente: ");
                        direccion = Console.ReadLine();

                        Cliente nuevoCliente = new Cliente(
                            idCliente: idCliente,
                            cedula: cedula,
                            nombre: nombre,
                            apellido: apellido,
                            numeroTelefonico: numeroTelefonico,
                            correo: correo,
                            direccion: direccion
                        );

                        Cliente.Crear(listaClientes, nuevoCliente);
                        Console.WriteLine("Cliente creado exitosamente.\n");
                        break;

                    case 2:
                        Console.Write("Ingresa el id del cliente a buscar: ");
                        int idbusqueda = 0;
                        int.TryParse(Console.ReadLine(), out idbusqueda);

                        Cliente clienteEncontrado = Cliente.Buscar(listaClientes, idbusqueda);
                        if (clienteEncontrado != null)
                        {
                            Console.WriteLine("Cliente encontrado:");
                            Console.WriteLine(clienteEncontrado);
                        }
                        else
                        {
                            Console.WriteLine("Cliente no encontrado.");
                        }
                        break;

                    case 3:
                        Console.Write("Ingresar id del cliente a actualizar: ");
                        int idActualizar = 0;
                        int.TryParse(Console.ReadLine(), out idActualizar);

                        Console.Write("Ingresar cedula del cliente: ");
                        cedula = Console.ReadLine();

                        Console.Write("Ingresar nombre del cliente: ");
                        nombre = Console.ReadLine();

                        Console.Write("Ingresar apellido del cliente: ");
                        apellido = Console.ReadLine();

                        Console.Write("Ingresar numero del cliente: ");
                        numeroTelefonico = Console.ReadLine();

                        Console.Write("Ingresar correo del cliente: ");
                        correo = Console.ReadLine();

                        Console.Write("Ingresar direccion del cliente: ");
                        direccion = Console.ReadLine();

                        Cliente clienteActualizado = new Cliente(
                            idCliente: idActualizar,
                            cedula: cedula,
                            nombre: nombre,
                            apellido: apellido,
                            numeroTelefonico: numeroTelefonico,
                            correo: correo,
                            direccion: direccion
                        );

                        Cliente.Actualizar(listaClientes, clienteActualizado);
                        Console.WriteLine("Cliente actualizado exitosamente.\n");
                        break;

                    case 4:
                        Console.Write("Ingresa el id del cliente a borrar: ");
                        int idBorrar = 0;
                        int.TryParse(Console.ReadLine(), out idBorrar);

                        Cliente.Eliminar(listaClientes, idBorrar);
                        Console.WriteLine("Cliente eliminado exitosamente.\n");
                        break;

                    case 5:
                        List<Cliente> todosLosClientes = Cliente.BuscarTodos(listaClientes);
                        Console.WriteLine("Lista de todos los clientes:");
                        foreach (var cliente in todosLosClientes)
                        {
                            Console.WriteLine(cliente);
                        }
                        break;
                }

                Menu(); // Vuelve a mostrar el menú después de cada operación
            }
        }

        public class Cliente
        {
            // Propiedades
            public int IdCliente { get; set; }
            public string Cedula { get; set; }
            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public string NumeroTelefonico { get; set; }
            public string Correo { get; set; }
            public string Direccion { get; set; }

            // Constructor
            public Cliente(int idCliente, string cedula, string nombre, string apellido, string numeroTelefonico, string correo, string direccion)
            {
                IdCliente = idCliente;
                Cedula = cedula;
                Nombre = nombre;
                Apellido = apellido;
                NumeroTelefonico = numeroTelefonico;
                Correo = correo;
                Direccion = direccion;
            }


            /// <summary>
            /// Metodo de creacion de clientes
            /// </summary>
            /// <param name="listaClientes"></param>
            /// <param name="nuevoCliente"></param>
            public static void Crear(List<Cliente> listaClientes, Cliente nuevoCliente)
            {
                listaClientes.Add(nuevoCliente);
            }

            public static Cliente Buscar(List<Cliente> listaClientes, int idCliente)
            {
                return listaClientes.FirstOrDefault(c => c.IdCliente == idCliente);
            }


            /// <summary>
            /// Metodo que muestra todos los clientes
            /// </summary>
            /// <param name="listaClientes"></param>
            /// <returns></returns>
            public static List<Cliente> BuscarTodos(List<Cliente> listaClientes)
            {
                return listaClientes;
            }


            /// <summary>
            /// Metodo para actualizar clientes
            /// </summary>
            /// <param name="listaClientes"></param>
            /// <param name="clienteActualizado"></param>
            public static void Actualizar(List<Cliente> listaClientes, Cliente clienteActualizado)
            {
                var cliente = Buscar(listaClientes, clienteActualizado.IdCliente);
                if (cliente != null)
                {
                    cliente.Cedula = clienteActualizado.Cedula;
                    cliente.Nombre = clienteActualizado.Nombre;
                    cliente.Apellido = clienteActualizado.Apellido;
                    cliente.NumeroTelefonico = clienteActualizado.NumeroTelefonico;
                    cliente.Correo = clienteActualizado.Correo;
                    cliente.Direccion = clienteActualizado.Direccion;
                }
            }

            /// <summary>
            ///  Metodo de eliminacion de clientes
            /// </summary>
            /// <param name="listaClientes"></param>
            /// <param name="idCliente"></param>
            public static void Eliminar(List<Cliente> listaClientes, int idCliente)
            {
                var cliente = Buscar(listaClientes, idCliente);
                if (cliente != null)
                {
                    listaClientes.Remove(cliente);
                }
            }

            /// <summary>
            /// Metodo para mostrar la informacion de una manera mas ordenada
            /// </summary>
            /// <returns></returns>
            public override string ToString()
            {
                return $"ID: {IdCliente}, Cedula: {Cedula}, Nombre: {Nombre}, Apellido: {Apellido}, NumeroTelefonico: {NumeroTelefonico}, Correo: {Correo}, Direccion: {Direccion}";
            }
        }
    }
}
