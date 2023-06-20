using GerenciamentoPedidosComida.Services;
using GerenciamentoPedidosComida.Models;
//  Terminar a UI do menu
//  Terminar a UI das classes
//  Fazer a classe Utils, que vai fazer uso da ApplicationDbContext
//  Perguntar para o professor o que seria melhor, utilizar a GetAll e filtrar isso no programa, ou filtrar no dbcontext
//  Colocar campo
//  Colocar campo
//  Colocar campo
//  Colocar campo
//  Colocar campo
//  Colocar campo
namespace GerenciamentoPedidosComida.UI
{
    class Menu
    {
        private PedidoUI _pedidoUI;
        private RestauranteUI _restauranteUI;
        private AvaliacaoUI _avaliacaoUI;
        private ClienteUI _clienteUI;
        private ItemPedidoUI _itemPedidoUI;
        private PratoUI _pratoUI;
        private Uteis _uteis;

        public Menu()
        {
            _pedidoUI = new PedidoUI();
            _restauranteUI = new RestauranteUI();
            _avaliacaoUI = new AvaliacaoUI();
            _clienteUI = new ClienteUI();
            _itemPedidoUI = new ItemPedidoUI();
            _pratoUI = new PratoUI();
            _uteis = new Uteis();
        }

        public void MenuInicial()
        {
            while (true)
            {
                Console.WriteLine("=== MENU INICIAL ===");
                Console.WriteLine("1. Realizar login");
                Console.WriteLine("2. Cadastrar novo usuário");
                Console.WriteLine("0. Sair");

                Console.Write("Digite a opção desejada: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        RealizarLogin();
                        break;
                    case "2":
                        _clienteUI.CreateCliente();
                        break;
                    case "0":
                        Console.WriteLine("Saindo do programa...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        public void MenuPrincipal()
        {
            while (true)
            {
                Console.WriteLine("=== MENU PRINCIPAL ===");
                Console.WriteLine("1. Realizar um novo pedido");
                Console.WriteLine("2. Listar pratos por restaurante");
                Console.WriteLine("3. Confirmar recebimento do pedido");
                Console.WriteLine("4. Listar pedidos realizados");
                Console.WriteLine("0. Sair");

                Console.Write("Digite a opção desejada: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        RealizarNovoPedido();
                        break;
                    case "2":
                        ListarPratosPorRestaurante();
                        break;
                    case "3":
                        ConfirmarRecebimentoPedido();
                        break;
                    case "4":
                        ListarPedidosRealizados();
                        break;
                    case "0":
                        Console.WriteLine("Saindo do programa...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        public void MenuAdm()
        {
            while (true)
            {
                Console.WriteLine("=== MENU ADMINISTRADOR ===");
                Console.WriteLine("1. Gerenciar Avaliações");
                Console.WriteLine("2. Gerenciar Clientes");
                Console.WriteLine("3. Gerenciar ItemPedidos");
                Console.WriteLine("4. Gerenciar Pedidos");
                Console.WriteLine("5. Gerenciar Pratos");
                Console.WriteLine("6. Gerenciar Restaurantes");
                Console.WriteLine("0. Sair");

                Console.Write("Digite a opção desejada: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        GerenciarAvaliacoes();
                        break;
                    case "2":
                        GerenciarClientes();
                        break;
                    case "3":
                        GerenciarItemPedidos();
                        break;
                    case "4":
                        GerenciarPedidos();
                        break;
                    case "5":
                        GerenciarPratos();
                        break;
                    case "6":
                        GerenciarRestaurantes();
                        break;
                    case "0":
                        Console.WriteLine("Saindo do menu administrador...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        public void RealizarLogin()
        {
            Console.Write("Digite seu e-mail: ");
            string email = Console.ReadLine();

            Console.Write("Digite sua senha: ");
            string senha = Console.ReadLine();

            bool loginSucesso = _uteis.Login(email, senha);

            if (loginSucesso)
            {
                Console.WriteLine("Login realizado com sucesso!");
                Console.WriteLine();

                if (email == "adm@mail.com")
                {
                    Console.WriteLine("Bem-vindo, administrador!");
                    MenuAdm();
                }
                else
                {
                    Console.WriteLine("Bem-vindo, usuário!");
                    MenuPrincipal();
                }
            }
            else
            {
                Console.WriteLine("Falha no login. Verifique suas credenciais e tente novamente.");
                Console.WriteLine();
            }
        }

        private void CadastrarUsuario()
        {
            Console.Write("Digite seu nome: ");
            string nome = Console.ReadLine();

            Console.Write("Digite seu e-mail: ");
            string email = Console.ReadLine();

            Console.Write("Digite sua senha: ");
            string senha = Console.ReadLine();

            Console.Write("Digite seu número de telefone: ");
            string numeroTelefone = Console.ReadLine();

            /*bool cadastroSucesso = clienteService.CadastrarCliente(nome, email, senha, numeroTelefone);

            if (cadastroSucesso)
            {
                Console.WriteLine("Cadastro realizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Falha no cadastro. Verifique os dados informados e tente novamente.");
            }*/

            Console.WriteLine();
        }

        private async void RealizarNovoPedido()
        {
            _pedidoUI.CreatePedido();
            // Console.WriteLine("Id do pedido: " + _uteis.GetLastPedidoIdAsync());
            // Console.WriteLine("Lembre-se de guardá-lo bem");
            // Implementar lógica para realizar um novo pedido
            int pedidoId = Convert.ToInt32(_uteis.GetLastPedidoIdAsync());
            int restauranteId = _pedidoUI.GetRestauranteIdByPedidoId(pedidoId);
            var listaPratosTask = _uteis.GetAllPratosByRestauranteId(restauranteId);
            var listaPratos = await listaPratosTask;
            List<int> listaPratosId = new List<int>();
            foreach (var item in listaPratos)
            {
                Console.WriteLine(item);
                listaPratosId.Add(item.Id);
            }
            if (listaPratos == null) 
            {
                Console.WriteLine("Não há nenhum prato no cardápio deste restaurante :(");
                Console.WriteLine("Deletando pedido...");
                _pedidoUI.DeletePedido(pedidoId);
            }
            Console.WriteLine("Adicione os pratos disponíveis (digite o Id para adicionar ao carrinho ou 0 para encerrar o pedido):");
            int pratoId;
            do
            {
                Console.Write("Digite o Id do prato: ");
                pratoId = Convert.ToInt32(Console.ReadLine());
                if(!listaPratosId.Contains(pratoId))
                {
                    Console.WriteLine("Por favor, adicione apenas os pratos disponíveis no cardápio do restaurante");
                    continue;
                }
                decimal precoUnitario = _pratoUI.GetPratoById(pratoId).Preco;
                Console.Write("Digite a quantidade: ");
                int quantidade = Convert.ToInt32(Console.ReadLine());
                decimal total = precoUnitario * quantidade;
                ItemPedido itemPedido = new ItemPedido
                {
                    PedidoId = pedidoId,
                    PratoId = pratoId,
                    Quantidade = quantidade,
                    PrecoUnitario = precoUnitario,
                    Total = total
                };
                _itemPedidoUI.CreateItemPedido(itemPedido);
            } while (pratoId != 0);
        }

        private async void ListarPratosPorRestaurante()
        {
            // Implementar lógica para listar pratos por restaurante
            _restauranteUI.ListAllRestaurantes();
            Console.WriteLine("Digite o Id para abrir o cardápio de um restaurante");
            int restauranteId = Convert.ToInt32(Console.ReadLine());
            var listaPratosTask = _uteis.GetAllPratosByRestauranteId(restauranteId);
            var listaPratos = await listaPratosTask;
            foreach(var item in listaPratos)
            {
                Console.WriteLine(item);
            }
        }

        private void ConfirmarRecebimentoPedido()
        {
            // Implementar lógica para confirmar recebimento do pedido
        }

        private void ListarPedidosRealizados()
        {
            // Implementar lógica para listar pedidos realizados
        }

        private void GerenciarAvaliacoes()
        {
            // Implementar lógica para gerenciar avaliações (CRUD de avaliações)
        }

        private void GerenciarClientes()
        {
            // Implementar lógica para gerenciar clientes (CRUD de clientes)
        }

        private void GerenciarItemPedidos()
        {
            // Implementar lógica para gerenciar item pedidos (CRUD de item pedidos)
        }

        private void GerenciarPedidos()
        {
            // Implementar lógica para gerenciar pedidos (CRUD de pedidos)
        }

        private void GerenciarPratos()
        {
            // Implementar lógica para gerenciar pratos (CRUD de pratos)
        }

        private void GerenciarRestaurantes()
        {
            while (true)
            {
                Console.WriteLine("=== GERENCIAR RESTAURANTES ===");
                Console.WriteLine("1. Criar Restaurante");
                Console.WriteLine("2. Ler Restaurante");
                Console.WriteLine("3. Atualizar Restaurante");
                Console.WriteLine("4. Excluir Restaurante");
                Console.WriteLine("5. Listar todos os Restaurantes");
                Console.WriteLine("0. Sair");

                Console.Write("Digite a opção desejada: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        _restauranteUI.CreateRestaurante();
                        break;
                    case "2":
                        Console.Write("Digite o Id do restaurante: ");
                        int restauranteId = Convert.ToInt32(Console.ReadLine());
                        _restauranteUI.GetRestauranteById(restauranteId);
                        break;
                    case "3":
                        Console.Write("Digite o Id do restaurante que quer atualizar: ");
                        Restaurante restaurante = _restauranteUI.GetRestauranteById(Convert.ToInt32(Console.ReadLine()));
                        _restauranteUI.UpdateRestaurante(restaurante);
                        break;
                    case "4":
                        Console.Write("Digite o Id do restaurante que quer excluir: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        _restauranteUI.DeleteRestaurante(id);
                        break;
                    case "5":
                        _restauranteUI.ListAllRestaurantes();
                        break;
                    case "0":
                        Console.WriteLine("Saindo do menu Gerenciar Restaurantes...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }
    }
}