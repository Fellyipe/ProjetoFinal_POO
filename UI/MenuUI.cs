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
        private Verificacao _verificacao;
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
            _verificacao = new Verificacao();
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
                        break;
                    case "2":
                        Console.Clear();
                        _clienteUI.CreateCliente();
                        AperteEnter();
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Saindo do programa...");
                        return;
                    default:
                        Console.Clear();
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
                        Console.WriteLine("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
                        break;
                    case "0":
                        Console.WriteLine("Saindo do programa...");
                        AperteEnter();
                        return;
                    default:
                        Console.Clear();
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
                        Console.Clear();
                        Console.WriteLine("Saindo do menu administrador...");
                        AperteEnter();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        AperteEnter();
                        break;
                }
            }
        }

        public void RealizarLogin()
        {
            Console.Clear();

            Console.Write("Digite seu e-mail: ");
            string email = _verificacao.VerificarNulidade(Console.ReadLine());
            while(!_clienteUI.ValidarEmail(email))
            {
                Console.WriteLine("Formato de email não válido!");
                Console.WriteLine("Digite um email válido");
                email = _verificacao.VerificarNulidade(Console.ReadLine());
            }
            Console.Write("Digite sua senha: ");
            string senha = _verificacao.VerificarNulidade(Console.ReadLine());
            
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

        private void RealizarNovoPedido()
        {
            Console.Clear();
            Console.Write("Digite o ID do restaurante: ");
            int restauranteId = _verificacao.VerificarNumero(/*_verificacao.VerificarNulidade(*/Console.ReadLine()/*)*/);
            // _pedidoUI.CreatePedido(_cliente.Id, restauranteId);
            /*int pedidoId = _uteis.GetLastPedido().Id;
            Console.WriteLine("PedidoId: " + pedidoId);*/
            var listaPratos = _uteis.GetAllPratosByRestauranteId(restauranteId);
            List<int> listaPratosId = new List<int>();
            Console.WriteLine("\r\nCardápio\r\n");
            foreach (var item in listaPratos)
            {
                Console.WriteLine(item + "\r\n");
                listaPratosId.Add(item.Id);
            }
            if (listaPratos.Count == 0) 
            {
                Console.WriteLine("Não há nenhum prato no cardápio deste restaurante");
                Console.WriteLine("Deletando pedido...");
                //_pedidoUI.DeletePedido(pedidoId);
                return;
            }
            _pedidoUI.CreatePedido(_cliente.Id, restauranteId);
            int pedidoId = _uteis.GetLastPedido().Id;
            
            Console.WriteLine("Adicione os pratos disponíveis (digite o Id para adicionar ao carrinho ou 0 para encerrar o pedido):");
            int pratoId;
            decimal totalPedido = 0;
            bool vazio = true;
            while (true)
            {
                Console.Write("Digite o Id do prato: ");
                pratoId = _verificacao.VerificarNumero(Console.ReadLine());
                if (pratoId == 0)
                {
                    if(vazio)
                    {
                        Console.WriteLine("Certeza que não quer adicionar nenhum prato ao pedido?\r\nO pedido será cancelado");
                        Console.WriteLine("1 - Voltar à seleção de pratos\r\n2 - Encerrar");
                        string opcao = Console.ReadLine();
                        while(opcao != "1" && opcao != "2")
                        {
                            Console.Clear();
                            Console.WriteLine("Por favor, selecione uma das duas opções\r\n1 - Voltar à seleção de pratos\r\n2 - Encerrar");
                            opcao = Console.ReadLine();
                        }
                        if(opcao == "1")
                        {
                            continue;
                        }
                        else if(opcao == "2")
                        {
                            break;
                        }
                    }
                    break;
                }
                if(!listaPratosId.Contains(pratoId))
                {
                    Console.WriteLine("Por favor, adicione apenas os pratos disponíveis no cardápio do restaurante");
                    continue;
                }
                vazio = false;
                decimal precoUnitario = _pratoUI.GetPratoById(pratoId).Preco;
                Console.Write("Digite a quantidade: ");
                int quantidade = _verificacao.VerificarNumero(Console.ReadLine());
                while(quantidade <= 0)
                {
                    Console.WriteLine("Digite apenas valores maiores 0");
                    quantidade = _verificacao.VerificarNumero(Console.ReadLine());
                }
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
                var possivelItemPedido = _uteis.GetItemPedidoByPedidoIdAndPratoId(pedidoId, pratoId);
                if(possivelItemPedido == null)
                {
                    _itemPedidoUI.CreateItemPedido(itemPedido);
                }
                else
                {
                    _uteis.UpdateQuantidadeInItemPedido(pedidoId, pratoId, possivelItemPedido.Quantidade + quantidade);
                }
            }
            Pedido pedido = _pedidoUI.GetPedidoById(pedidoId);
            pedido.Id = pedidoId;
            pedido.Total = totalPedido;
            _pedidoUI.UpdatePedido(pedido);
            Console.Clear();
            Console.WriteLine("Pedido realizado!");
            Console.WriteLine("Id do pedido: " + pedidoId);
            Console.WriteLine("Valor total: " + pedido.Total);
        }

        private void ListarPratosPorRestaurante()
        {
            // Implementar lógica para listar pratos por restaurante
            Console.Clear();
            _restauranteUI.ListAllRestaurantes();
            Console.WriteLine("Digite o Id para abrir o cardápio de um restaurante");
            int restauranteId = _verificacao.VerificarNumero(Console.ReadLine());
            if(_restauranteUI.GetRestauranteById(restauranteId) == null)
            {
                return;
            }
            var listaPratos = _uteis.GetAllPratosByRestauranteId(restauranteId);
            Console.Clear();
            Console.WriteLine("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            Console.WriteLine(_restauranteUI.GetRestauranteById(restauranteId)._nome + "\r\nCardápio\r\n");
            foreach(var item in listaPratos)
            {
                Console.WriteLine(item + "\r\n");
            }
        }

        private void ConfirmarRecebimentoPedido()
        {
            Console.Clear();
            var listaPedidos = _uteis.GetAllPedidosByStatus("Em andamento");
            Console.WriteLine("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            listaPedidos = listaPedidos.Where(item => item.ClienteId == _cliente.Id).ToList();
            if(listaPedidos.Count() == 0)
            {
                Console.Clear();
                Console.WriteLine("Não há nenhum pedido em andamento em seu nome");
                return;
            }
            List<int> listaPedidosId = new List<int>();
            foreach (var item in listaPedidos)
            {
                if(item.ClienteId == _cliente.Id)
                {
                    listaPedidosId.Add(item.Id);
                    Console.WriteLine(item + "\r\n");
                }
            }
            Console.Write("Digite o Id do pedido: ");
            int pedidoId = _verificacao.VerificarNumero(Console.ReadLine());
            Pedido pedido = _pedidoUI.GetPedidoById(pedidoId);
            if(pedido == null)
            {
                return;
            }
            if(!listaPedidosId.Contains(pedidoId))
            {
                Console.WriteLine("Não há nenhum pedido com esse Id em seu nome");
                return;
            }
            pedido.Status = "Entregue";
            _pedidoUI.UpdatePedido(pedido);
            Console.Clear();
            Console.WriteLine("Avalie seu pedido!");
            _avaliacaoUI.CreateAvaliacao(pedido);

        }

        private void ListarPedidosRealizados()
        {
            Console.Clear();
            Console.WriteLine("Selecione uma opção\r\n1 - Pedidos em andamento\r\n2 - Pedidos entregues");
            string opcao = Console.ReadLine();
            while(opcao != "1" && opcao != "2")
            {
                Console.Clear();
                Console.WriteLine("Por favor, selecione uma das duas opções\r\n1 - Pedidos em andamento\r\n2 - Pedidos entregues");
                opcao = Console.ReadLine();
            }
            List<Pedido> listaPedidos = null;
            Console.Clear();
            Console.WriteLine("\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n\r\n");
            if(opcao == "1")
            {
                listaPedidos = _uteis.GetAllPedidosByStatus("Em andamento");
                listaPedidos = listaPedidos.Where(item => item.ClienteId == _cliente.Id).ToList();
                if(listaPedidos.Count() == 0)
                {
                    Console.WriteLine("Não há nenhum pedido em andamento em seu nome");
                    return;
                }
                Console.WriteLine("Pedidos em andamento:");
                foreach (var item in listaPedidos)
                {
                    Console.WriteLine(item + "\r\n");
                }
                //Console.Clear();
            }
            else if(opcao == "2")
            {
                listaPedidos = _uteis.GetAllPedidosByStatus("Entregue");
                listaPedidos = listaPedidos.Where(item => item.ClienteId == _cliente.Id).ToList();
                if(listaPedidos.Count() == 0)
                {
                    Console.WriteLine("Não há nenhum pedido entregue em seu nome");
                    return;
                }
                Console.WriteLine("Pedidos entregues:");
                foreach (var item in listaPedidos)
                {
                    Console.WriteLine(item + "\r\n");
                }
            }
            
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
                        Console.Clear();
                        _restauranteUI.CreateRestaurante();
                        AperteEnter();
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("Digite o Id do restaurante: ");
                        int restauranteId_GET = _verificacao.VerificarNumero(Console.ReadLine());
                        Restaurante restaurante_GET = _restauranteUI.GetRestauranteById(restauranteId_GET);
                        AperteEnter();
                        break;
                    case "3":
                        Console.Clear();
                        Console.Write("Digite o Id do restaurante que quer atualizar: ");
                        int restauranteId_UPDATE = _verificacao.VerificarNumero(Console.ReadLine());
                        Restaurante restaurante_UPDATE = _restauranteUI.GetRestauranteById(restauranteId_UPDATE);
                        if(restaurante_UPDATE == null)
                        {
                            return;
                        }
                        AperteEnter();
                        break;
                    case "4":
                        Console.Clear();
                        Console.Write("Digite o Id do restaurante que quer excluir: ");
                        int restauranteId_DELETE = _verificacao.VerificarNumero(Console.ReadLine());
                        Restaurante restaurante_DELETE = _restauranteUI.GetRestauranteById(restauranteId_DELETE);
                        AperteEnter();
                        break;
                    case "5":
                        Console.Clear();
                        _restauranteUI.ListAllRestaurantes();
                        AperteEnter();
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Saindo do menu Gerenciar Restaurantes...");
                        AperteEnter();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        AperteEnter();
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
                        Console.Clear();
                        _pratoUI.CreatePrato();
                        AperteEnter();
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("Digite o Id do prato: ");
                        int pratoId = _verificacao.VerificarNumero(Console.ReadLine());
                        Console.WriteLine(_pratoUI.GetPratoById(pratoId));
                        AperteEnter();
                        break;
                    case "3":
                        Console.Clear();
                        Console.Write("Digite o Id do prato que quer atualizar: ");
                        Prato prato = _pratoUI.GetPratoById(_verificacao.VerificarNumero(Console.ReadLine()));
                        if(prato == null)
                        {
                            return;
                        }
                        _pratoUI.UpdatePrato(prato);
                        AperteEnter();
                        break;
                    case "4":
                        Console.Clear();
                        Console.Write("Digite o Id do prato que quer excluir: ");
                        int id = _verificacao.VerificarNumero(Console.ReadLine());
                        _pratoUI.DeletePrato(id);
                        AperteEnter();
                        break;
                    case "5":
                        Console.Clear();
                        _pratoUI.ListAllPratos();
                        AperteEnter();
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Saindo do menu Gerenciar Pratos...");
                        AperteEnter();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        AperteEnter();
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
                        Console.Clear();
                        Console.Write("Digite o ID do restaurante: ");
                        int restauranteId = int.Parse(Console.ReadLine());
                        _pedidoUI.CreatePedido(_cliente.Id, restauranteId);
                        AperteEnter();
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("Digite o Id do pedido: ");
                        int pedidoId = _verificacao.VerificarNumero(Console.ReadLine());
                        Console.WriteLine(_pedidoUI.GetPedidoById(pedidoId));
                        AperteEnter();
                        break;
                    case "3":
                        Console.Clear();
                        Console.Write("Digite o Id do pedido que quer atualizar: ");
                        Pedido pedido = _pedidoUI.GetPedidoById(_verificacao.VerificarNumero(Console.ReadLine()));
                        if(pedido == null)
                        {
                            return;
                        }
                        _pedidoUI.UpdatePedido(pedido, 1);
                        AperteEnter();
                        break;
                    case "4":
                        Console.Clear();
                        Console.Write("Digite o Id do pedido que quer excluir: ");
                        int id = _verificacao.VerificarNumero(Console.ReadLine());
                        _pedidoUI.DeletePedido(id);
                        AperteEnter();
                        break;
                    case "5":
                        Console.Clear();
                        _pedidoUI.ListAllPedidos();
                        AperteEnter();
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Saindo do menu Gerenciar Pedidos...");
                        AperteEnter();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        AperteEnter();
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

                int pedidoId;
                int pratoId;

                switch (opcao)
                {
                    case "1":
                        Console.Clear();
                        //_itemPedidoUI.CreateItemPedido();
                        AperteEnter();
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("Digite o Id do Pedido: ");
                        pedidoId = _verificacao.VerificarNumero(Console.ReadLine());
                        Console.Write("Digite o Id do Prato: ");
                        pratoId = _verificacao.VerificarNumero(Console.ReadLine());
                        Console.WriteLine(_itemPedidoUI.GetItemPedidoById(pedidoId, pratoId));
                        AperteEnter();
                        break;
                    case "3":
                        Console.Clear();
                        Console.Write("Digite o Id do Pedido: ");
                        pedidoId = _verificacao.VerificarNumero(Console.ReadLine());
                        Console.Write("Digite o Id do Prato: ");
                        pratoId = _verificacao.VerificarNumero(Console.ReadLine());
                        ItemPedido itemPedido = _itemPedidoUI.GetItemPedidoById(pedidoId, pratoId);
                        _itemPedidoUI.UpdateItemPedido(itemPedido);
                        AperteEnter();
                        break;
                    case "4":
                        Console.Clear();
                        Console.Write("Digite o Id do Pedido: ");
                        pedidoId = _verificacao.VerificarNumero(Console.ReadLine());
                        Console.Write("Digite o Id do Prato: ");
                        pratoId = _verificacao.VerificarNumero(Console.ReadLine());
                        _itemPedidoUI.DeleteItemPedido(pedidoId, pratoId);
                        AperteEnter();
                        break;
                    case "5":
                        Console.Clear();
                        _itemPedidoUI.ListAllItemPedidos();
                        AperteEnter();
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Saindo do menu Gerenciar ItemPedidos...");
                        AperteEnter();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        AperteEnter();
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
                        Console.Clear();
                        _clienteUI.CreateCliente();
                        AperteEnter();
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("Digite o Id do cliente: ");
                        int clienteId = _verificacao.VerificarNumero(Console.ReadLine());
                        Console.WriteLine(_clienteUI.GetClienteById(clienteId));
                        AperteEnter();
                        break;
                    case "3":
                        Console.Clear();
                        Console.Write("Digite o Id do cliente que quer atualizar: ");
                        Cliente cliente = _clienteUI.GetClienteById(_verificacao.VerificarNumero(Console.ReadLine()));
                        if(cliente == null)
                        {
                            return;
                        }
                        _clienteUI.UpdateCliente(cliente);
                        AperteEnter();
                        break;
                    case "4":
                        Console.Clear();
                        Console.Write("Digite o Id do cliente que quer excluir: ");
                        int id = _verificacao.VerificarNumero(Console.ReadLine());
                        _clienteUI.DeleteCliente(id);
                        AperteEnter();
                        break;
                    case "5":
                        Console.Clear();
                        _clienteUI.ListAllClientes();
                        AperteEnter();
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Saindo do menu Gerenciar Clientes...");
                        AperteEnter();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        AperteEnter();
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
                        Console.Clear();
                        //_avaliacaoUI.CreateAvaliacao();
                        AperteEnter();
                        break;
                    case "2":
                        Console.Clear();
                        Console.Write("Digite o Id do avaliacao: ");
                        int avaliacaoId = _verificacao.VerificarNumero(Console.ReadLine());
                        Console.WriteLine(_avaliacaoUI.GetAvaliacaoById(avaliacaoId));
                        AperteEnter();
                        break;
                    case "3":
                        Console.Clear();
                        Console.Write("Digite o Id do avaliacao que quer atualizar: ");
                        Avaliacao avaliacao = _avaliacaoUI.GetAvaliacaoById(_verificacao.VerificarNumero(Console.ReadLine()));
                        if(avaliacao == null)
                        {
                            return;
                        }
                        _avaliacaoUI.UpdateAvaliacao(avaliacao);
                        AperteEnter();
                        break;
                    case "4":
                        Console.Clear();
                        Console.Write("Digite o Id do avaliacao que quer excluir: ");
                        int id = _verificacao.VerificarNumero(Console.ReadLine());
                        _avaliacaoUI.DeleteAvaliacao(id);
                        AperteEnter();
                        break;
                    case "5":
                        Console.Clear();
                        _avaliacaoUI.ListAllAvaliacaos();
                        AperteEnter();
                        break;
                    case "0":
                        Console.Clear();
                        Console.WriteLine("Saindo do menu Gerenciar Avaliacaos...");
                        AperteEnter();
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        AperteEnter();
                        break;
                }
            }
        }

        private void AperteEnter()
        {
            Console.WriteLine("Aperte qualquer tecla para continuar");
            Console.ReadKey();
        }
    
        

        

    }
}