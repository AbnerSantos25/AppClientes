using Cadastro;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repositorio
{
    public class ClienteRepositorio
    {
        public List<Cliente> Clientes = new List<Cliente>();


        public void ImprimirCliente(Cliente _cliente)
        {
            Console.WriteLine($"Id........................{_cliente.Id}");
            Console.WriteLine($"Nome......................{_cliente.Nome}");
            Console.WriteLine($"Data de Nascimento........{_cliente.DataNascimento}");
            Console.WriteLine($"Cadastrado em.............{_cliente.CadastradoEm}");
            Console.WriteLine($"Desconto..................{_cliente.Desconto.ToString("0.00")}");
            Console.WriteLine("-------------------------------------------------");
        }

        public void CadastrarCliente()
        {
            Console.Clear();

            Console.WriteLine("Digite o nome do cliente:");
            var nome = Console.ReadLine();
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Digite a data de nascimento:");
            var dataNascimento = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Digite o desconto:");
            var desconto = decimal.Parse(Console.ReadLine());
            Console.WriteLine(Environment.NewLine);

            var cliente = new Cliente();
            cliente.Id = Clientes.Count + 1;
            cliente.Nome = nome;
            cliente.DataNascimento = dataNascimento;
            cliente.Desconto = desconto;
            cliente.CadastradoEm = DateTime.Now;

            Clientes.Add(cliente);

            Console.WriteLine("Cliente cadastrado com sucesso!");
            ImprimirCliente(cliente);
            Console.ReadKey();
        }

        public void GravarDadosClientes()
        {
            var json = System.Text.Json.JsonSerializer.Serialize(Clientes);
            File.WriteAllText("clientes.txt", json);
        }
        public void LerDadosClientes()
        {
            if (File.Exists("clientes.txt"))
            {
                var dados = File.ReadAllText("clientes.txt");
                var ClientesArquivo = System.Text.Json.JsonSerializer.Deserialize<List<Cliente>>(dados);
                Clientes.AddRange(ClientesArquivo);
            }
            else
            {
                
            }
        }

        public void EditarCliente()
        {
            Console.Clear();
            Console.WriteLine("Informe o Código do Cliente: ");
            var codigo = Console.ReadLine();

            var cliente = Clientes.FirstOrDefault(p => p.Id == int.Parse(codigo));

            if(cliente == null)
            {
                Console.WriteLine("Cliente não Encontrado!");
                Console.ReadKey();
                return;
            }

            ImprimirCliente(cliente);

            Console.WriteLine("Digite o nome do cliente:");
            var nome = Console.ReadLine();
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Digite a data de nascimento:");
            var dataNascimento = DateOnly.Parse(Console.ReadLine());
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("Digite o desconto:");
            var desconto = decimal.Parse(Console.ReadLine());
            Console.WriteLine(Environment.NewLine);

            cliente.Nome = nome;
            cliente.DataNascimento = dataNascimento;
            cliente.Desconto = desconto;
            cliente.CadastradoEm = DateTime.Now;

            Console.WriteLine("Cliente Alterado com sucesso!!!");
            ImprimirCliente(cliente);
            Console.ReadKey();
        }

        public void ExcluirCliente()
        {
            Console.Clear();
            Console.WriteLine("Informe o Código do Cliente: ");
            var codigo = Console.ReadLine();

            var cliente = Clientes.FirstOrDefault(p => p.Id == int.Parse(codigo));

            if (cliente == null)
            {
                Console.WriteLine("Cliente não Encontrado!");
                Console.ReadKey();
                return;
            }
            ImprimirCliente(cliente);

            Clientes.Remove(cliente);
            Console.WriteLine("Cliente Excluído com sucesso!!!");
            Console.ReadKey();
        }


        public void ExibirClientes()
        {
            Console.Clear();
            foreach (var cliente in Clientes)
            {
                ImprimirCliente(cliente);
            }
            Console.ReadKey();
        }
    }
}
