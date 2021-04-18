using Newtonsoft.Json;
using System;
using TutorialEF.Models;
using TutorialEF.Repository;

namespace TutorialEF
{
    class Program
    {
        static void Main(string[] args)
        {
            MainMenu();
        }

        private static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("EF Core - Tutorial CRUD");
            Console.WriteLine("1) Adicionar cliente");
            Console.WriteLine("2) Atualizar cliente");
            Console.WriteLine("3) Buscar cliente por ID");
            Console.WriteLine("4) Buscar cliente por nome");
            Console.WriteLine("5) Deletar cliente");

            switch (Console.ReadLine())
            {
                case "1":
                    Add();
                    break;
                case "2":
                    Update();
                    break;
                case "3":
                    GetById();
                    break;
                case "4":
                    GetByName();
                    break;
                case "5":
                    Delete();
                    break;
            }
        }

        private static void GetById()
        {
            Console.WriteLine("Digite o ID:");
            var id = Convert.ToInt32(Console.ReadLine());

            var clientRepository = new ClientRepository();
            var client = clientRepository.GetById(id);

            if (client != null)
            {
                Console.WriteLine(JsonConvert.SerializeObject(client, Formatting.Indented));
            }
            else
            {
                Console.WriteLine("Cliente não encontrado");
            }
        }

        private static void GetByName()
        {
            Console.WriteLine("Digite o nome para pesquisar:");
            var name = Console.ReadLine();

            var clientRepository = new ClientRepository();
            var client = clientRepository.GetByName(name);

            if (client != null)
            {
                Console.WriteLine(JsonConvert.SerializeObject(client, Formatting.Indented));
            }
            else
            {
                Console.WriteLine("Cliente não encontrado");
            }
        }

        private static void Add()
        {
            var clientRepository = new ClientRepository();

            Console.WriteLine("Digite o nome:");
            var name = Console.ReadLine();

            Console.WriteLine("Digite o email:");
            var email = Console.ReadLine();

            var client = new Client
            {
                Name = name,
                Email = email,
                Active = true,
                CreationDate = DateTime.Now
            };

            clientRepository.Add(client);
            Console.WriteLine("Cliente adicionado");
        }

        private static void Update()
        {
            var clientRepository = new ClientRepository();

            Console.WriteLine("Digite o ID:");
            var id = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Digite o nome:");
            var name = Console.ReadLine();

            Console.WriteLine("Digite o email:");
            var email = Console.ReadLine();

            Console.WriteLine("Ativo ?");
            var active = Convert.ToBoolean(Console.ReadLine());

            var client = new Client
            {
                Id = id,
                Name = name,
                Email = email,
                Active = active
            };

            clientRepository.Update(client);
            Console.WriteLine("Cliente atualizado");
        }

        private static void Delete()
        {
            var clientRepository = new ClientRepository();

            Console.WriteLine("Digite o ID:");
            var id = Convert.ToInt32(Console.ReadLine());

            clientRepository.Delete(id);
            Console.WriteLine("Cliente deletado");
        }
    }
}
