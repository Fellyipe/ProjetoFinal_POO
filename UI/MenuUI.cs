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
        private Cliente _cliente;

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
                Console.Clear();
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
                        AperteEnter();
                        break;
                    case "2":
                        _clienteUI.CreateCliente();
                        AperteEnter();
                        break;
                    case "0":
                        Console.WriteLine("Saindo do programa...");
                        AperteEnter();
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        AperteEnter();
                        break;
                }
            }
        }

        public void MenuPrincipal()
        {
            while (true)
            {
                Console.Clear();
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
                        AperteEnter();
                        break;
                    case "2":
                        ListarPratosPorRestaurante();
                        AperteEnter();
                        break;
                    case "3":
                        ConfirmarRecebimentoPedido();
                        AperteEnter();
                        break;
                    case "4":
                        ListarPedidosRealizados();
                        AperteEnter();
                        break;
                    case "0":
                        Console.WriteLine("Saindo do programa...");
                        AperteEnter();
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        AperteEnter();
                        break;
                }
            }
        }

        public void MenuAdm()
        {
            while (true)
            {
                Console.Clear();
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
                        AperteEnter();
                        break;
                    case "2":
                        GerenciarClientes();
                        AperteEnter();
                        break;
                    case "3":
                        GerenciarItemPedidos();
                        AperteEnter();
                        break;
                    case "4":
                        GerenciarPedidos();
                        AperteEnter();
                        break;
                    case "5":
                        GerenciarPratos();
                        AperteEnter();
                        break;
                    case "6":
                        GerenciarRestaurantes();
                        AperteEnter();
                        break;
                    case "0":
                        Console.WriteLine("Saindo do menu administrador...");
                        AperteEnter();
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        AperteEnter();
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

            Cliente cliente = _uteis.Login(email, senha);
            if (cliente != null)
            {
                Console.WriteLine("Login realizado com sucesso!");
                _cliente = cliente;

                if (email == "adm@mail.com")
                {
                    Console.WriteLine("Bem-vindo, administrador!");
                    AperteEnter();
                    MenuAdm();
                }
                else
                {
                    Console.WriteLine("Bem-vindo, usuário!");
                    AperteEnter();
                    MenuPrincipal();
                }
            }
            else
            {
                Console.WriteLine("Falha no login. Verifique suas credenciais e tente novamente.");
                AperteEnter();
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
            Console.Clear();
            Console.Write("Digite o ID do restaurante: ");
            int restauranteId = int.Parse(Console.ReadLine());
            _pedidoUI.CreatePedido(_cliente.Id, restauranteId);
            // Console.WriteLine("Id do pedido: " + _uteis.GetLastPedidoIdAsync());
            // Console.WriteLine("Lembre-se de guardá-lo bem");
            // Implementar lógica para realizar um novo pedido

            int pedidoId = _uteis.GetLastPedido().Id;
            Console.WriteLine("PedidoId: " + pedidoId);
            var listaPratos = _uteis.GetAllPratosByRestauranteId(restauranteId);
            List<int> listaPratosId = new List<int>();
            Console.WriteLine("Cardápio");
            foreach (var item in listaPratos)
            {
                Console.WriteLine(item);
                listaPratosId.Add(item.Id);
            }
            if (listaPratos.Count == 0) 
            {
                Console.WriteLine("Não há nenhum prato no cardápio deste restaurante :(");
                Console.WriteLine("Deletando pedido...");
                _pedidoUI.DeletePedido(pedidoId);
                return;
            }
            Console.WriteLine("Adicione os pratos disponíveis (digite o Id para adicionar ao carrinho ou 0 para encerrar o pedido):");
            int pratoId;
            decimal totalPedido = 0;
            while (true)
            {
                Console.Write("Digite o Id do prato: ");
                pratoId = Convert.ToInt32(Console.ReadLine());
                if (pratoId == 0)
                {
                    break;
                }
                if(!listaPratosId.Contains(pratoId))
                {
                    Console.WriteLine("Por favor, adicione apenas os pratos disponíveis no cardápio do restaurante");
                    continue;
                }
                decimal precoUnitario = _pratoUI.GetPratoById(pratoId).Preco;
                Console.Write("Digite a quantidade: ");
                int quantidade = Convert.ToInt32(Console.ReadLine());
                decimal total = precoUnitario * quantidade;
                totalPedido = totalPedido + total;
                ItemPedido itemPedido = new ItemPedido
                {
                    PedidoId = pedidoId,
                    PratoId = pratoId,
                    Quantidade = quantidade,
                    PrecoUnitario = precoUnitario,
                    Total = total
                };
                Console.WriteLine("PedidoId: " + pedidoId);
                _itemPedidoUI.CreateItemPedido(itemPedido);
            }
            Pedido pedido = _pedidoUI.GetPedidoById(pedidoId);
            pedido.Id = pedidoId;
            _pedidoUI.UpdatePedido(pedido);
        }

        private async void ListarPratosPorRestaurante()
        {
            // Implementar lógica para listar pratos por restaurante
            _restauranteUI.ListAllRestaurantes();
            Console.WriteLine("Digite o Id para abrir o cardápio de um restaurante");
            int restauranteId = Convert.ToInt32(Console.ReadLine());
            var listaPratos = _uteis.GetAllPratosByRestauranteId(restauranteId);
            foreach(var item in listaPratos)
            {
                Console.WriteLine(item);
            }
        }

        private async void ConfirmarRecebimentoPedido()
        {
            _pedidoUI.ListAllPedidos();
            var listaPedidos = _uteis.GetAllPedidosEntregues();
            foreach (var item in listaPedidos)
            {
                Console.WriteLine(item);
            }
            Console.Write("Digite o Id do pedido: ");
            int pedidoId = Convert.ToInt32(Console.ReadLine());
            Pedido pedido = _pedidoUI.GetPedidoById(pedidoId);
            pedido.Status = "Entregue";
            _pedidoUI.UpdatePedido(pedido);
            Console.WriteLine("Avalie seu pedido!");
            _avaliacaoUI.CreateAvaliacao(pedido);

        }

        private void ListarPedidosRealizados()
        {
            // Implementar lógica para listar pedidos realizados
        }

        private void GerenciarRestaurantes()
        {
            while (true)
            {
                Console.Clear();
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
                        Console.WriteLine(_restauranteUI.GetRestauranteById(restauranteId));
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
    
        private void GerenciarPratos()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== GERENCIAR PRATOS ===");
                Console.WriteLine("1. Criar Prato");
                Console.WriteLine("2. Ler Prato");
                Console.WriteLine("3. Atualizar Prato");
                Console.WriteLine("4. Excluir Prato");
                Console.WriteLine("5. Listar todos os Pratos");
                Console.WriteLine("0. Sair");

                Console.Write("Digite a opção desejada: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        _pratoUI.CreatePrato();
                        break;
                    case "2":
                        Console.Write("Digite o Id do prato: ");
                        int pratoId = Convert.ToInt32(Console.ReadLine());
                        
                        Console.WriteLine("Digite um número:");
                        string entrada = Console.ReadLine();

                        int numero;

                        if (int.TryParse(entrada, out numero))
                        {
                            // A conversão para int foi bem-sucedida
                            Console.WriteLine("Número válido: " + numero);
                        }
                        else
                        {
                            // A conversão falhou, o usuário digitou uma letra ou um valor inválido
                            Console.WriteLine("Entrada inválida. Digite um número.");
                        }
                        Console.WriteLine(_pratoUI.GetPratoById(pratoId));
                        break;
                    case "3":
                        Console.Write("Digite o Id do prato que quer atualizar: ");
                        Prato prato = _pratoUI.GetPratoById(Convert.ToInt32(Console.ReadLine()));
                        _pratoUI.UpdatePrato(prato);
                        break;
                    case "4":
                        Console.Write("Digite o Id do prato que quer excluir: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        _pratoUI.DeletePrato(id);
                        break;
                    case "5":
                        _pratoUI.ListAllPratos();
                        break;
                    case "0":
                        Console.WriteLine("Saindo do menu Gerenciar Pratos...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        private void GerenciarPedidos()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== GERENCIAR PEDIDOS ===");
                Console.WriteLine("1. Criar Pedido");
                Console.WriteLine("2. Ler Pedido");
                Console.WriteLine("3. Atualizar Pedido");
                Console.WriteLine("4. Excluir Pedido");
                Console.WriteLine("5. Listar todos os Pedidos");
                Console.WriteLine("0. Sair");

                Console.Write("Digite a opção desejada: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        Console.Write("Digite o ID do restaurante: ");
                        int restauranteId = int.Parse(Console.ReadLine());
                        _pedidoUI.CreatePedido(_cliente.Id, restauranteId);
                        break;
                    case "2":
                        Console.Write("Digite o Id do pedido: ");
                        int pedidoId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(_pedidoUI.GetPedidoById(pedidoId));
                        break;
                    case "3":
                        Console.Write("Digite o Id do pedido que quer atualizar: ");
                        Pedido pedido = _pedidoUI.GetPedidoById(Convert.ToInt32(Console.ReadLine()));
                        _pedidoUI.UpdatePedido(pedido);
                        break;
                    case "4":
                        Console.Write("Digite o Id do pedido que quer excluir: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        _pedidoUI.DeletePedido(id);
                        break;
                    case "5":
                        _pedidoUI.ListAllPedidos();
                        break;
                    case "0":
                        Console.WriteLine("Saindo do menu Gerenciar Pedidos...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        private void GerenciarItemPedidos()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== GERENCIAR ITEMPEDIDOS ===");
                Console.WriteLine("1. Criar ItemPedido");
                Console.WriteLine("2. Ler ItemPedido");
                Console.WriteLine("3. Atualizar ItemPedido");
                Console.WriteLine("4. Excluir ItemPedido");
                Console.WriteLine("5. Listar todos os ItemPedidos");
                Console.WriteLine("0. Sair");

                Console.Write("Digite a opção desejada: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        //_itemPedidoUI.CreateItemPedido();
                        break;
                    case "2":
                        Console.Write("Digite o Id do itemPedido: ");
                        int itemPedidoId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(_itemPedidoUI.GetItemPedidoById(itemPedidoId));
                        break;
                    case "3":
                        Console.Write("Digite o Id do itemPedido que quer atualizar: ");
                        ItemPedido itemPedido = _itemPedidoUI.GetItemPedidoById(Convert.ToInt32(Console.ReadLine()));
                        _itemPedidoUI.UpdateItemPedido(itemPedido);
                        break;
                    case "4":
                        Console.Write("Digite o Id do itemPedido que quer excluir: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        _itemPedidoUI.DeleteItemPedido(id);
                        break;
                    case "5":
                        _itemPedidoUI.ListAllItemPedidos();
                        break;
                    case "0":
                        Console.WriteLine("Saindo do menu Gerenciar ItemPedidos...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        private void GerenciarClientes()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== GERENCIAR CLIENTES ===");
                Console.WriteLine("1. Criar Cliente");
                Console.WriteLine("2. Ler Cliente");
                Console.WriteLine("3. Atualizar Cliente");
                Console.WriteLine("4. Excluir Cliente");
                Console.WriteLine("5. Listar todos os Clientes");
                Console.WriteLine("0. Sair");

                Console.Write("Digite a opção desejada: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        _clienteUI.CreateCliente();
                        break;
                    case "2":
                        Console.Write("Digite o Id do cliente: ");
                        int clienteId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(_clienteUI.GetClienteById(clienteId));
                        break;
                    case "3":
                        Console.Write("Digite o Id do cliente que quer atualizar: ");
                        Cliente cliente = _clienteUI.GetClienteById(Convert.ToInt32(Console.ReadLine()));
                        _clienteUI.UpdateCliente(cliente);
                        break;
                    case "4":
                        Console.Write("Digite o Id do cliente que quer excluir: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        _clienteUI.DeleteCliente(id);
                        break;
                    case "5":
                        _clienteUI.ListAllClientes();
                        break;
                    case "0":
                        Console.WriteLine("Saindo do menu Gerenciar Clientes...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        private void GerenciarAvaliacoes()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("=== GERENCIAR AVALIACOES ===");
                Console.WriteLine("1. Criar Avaliacao");
                Console.WriteLine("2. Ler Avaliacao");
                Console.WriteLine("3. Atualizar Avaliacao");
                Console.WriteLine("4. Excluir Avaliacao");
                Console.WriteLine("5. Listar todos os Avaliacaos");
                Console.WriteLine("0. Sair");

                Console.Write("Digite a opção desejada: ");
                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        //_avaliacaoUI.CreateAvaliacao();
                        break;
                    case "2":
                        Console.Write("Digite o Id do avaliacao: ");
                        int avaliacaoId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine(_avaliacaoUI.GetAvaliacaoById(avaliacaoId));
                        break;
                    case "3":
                        Console.Write("Digite o Id do avaliacao que quer atualizar: ");
                        Avaliacao avaliacao = _avaliacaoUI.GetAvaliacaoById(Convert.ToInt32(Console.ReadLine()));
                        _avaliacaoUI.UpdateAvaliacao(avaliacao);
                        break;
                    case "4":
                        Console.Write("Digite o Id do avaliacao que quer excluir: ");
                        int id = Convert.ToInt32(Console.ReadLine());
                        _avaliacaoUI.DeleteAvaliacao(id);
                        break;
                    case "5":
                        _avaliacaoUI.ListAllAvaliacaos();
                        break;
                    case "0":
                        Console.WriteLine("Saindo do menu Gerenciar Avaliacaos...");
                        return;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
        }

        private void AperteEnter()
        {
            Console.WriteLine("Aperte qualquer tecla para continuar");
            Console.ReadKey();
        }
    
        bool VerificarNumero(string entrada, out int numero)
        {
            return int.TryParse(entrada, out numero);
        }

    }
}