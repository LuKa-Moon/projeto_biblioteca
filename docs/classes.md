# Classes

* Livro, Exemplar, Reserva, Emprestimo, Prazo, Usuario, Estudante, Funcionario, Arquivista, Assistente: classes de modelo, concentram as regras de negócio e atributos do núcleo da aplicação, tendo relação direta com entidades do mundo real. 
    * Pelo padrão Information Expert do GRASP, estão responsáveis por responder dados sobre si mesmas, já que têm acesso direto a eles. Exemplo: um Exemplar tem a função EstaDisponivel(), que retorna se ele está ou não disponível;
* UsuariosRepository, EmprestimosRepository, ReservasRepository, ExemplaresRepository, LivrosRepository, Repository: fazem o intermédio entre a porta BDPport e o resto da aplicação, contendo instruções como acessar o banco de dados e realizar consultas, alterações, deleções e inserções. Cada uma implementa as funções de Repository (classe mãe).
    * Pelo padrão High Cohesion do GRASP, essas classes somente mandam buscar informações do banco;
* Services: há um service para cada classe não abstrata de modelo, além de um para notificação. Eles executam a lógica necessária para o funcionamento da aplicação com relação às suas classes, para que esta não fique acoplada no controller. Por exemplo, o service de exemplar faz a alteração do estado de empréstimo de um exemplar.
    * Pelo padrão Creator do GRASP, o service é quem cria novas instâncias das classes, já que usa intensamente os objetos criados;
    * Por SRP, é interessante separar do controller funções mais específicas das classes, para que ele tenho menos motivos para ser alterado;
* IServices: há uma interface para cada service, estabelecendo as funções que eles devem implementar, como um contrato entre o service e as classes que o utilizarem.
    * Pelo padrão Protected Variations do GRASP, isolamos pontos de mudança (services) dos controllers, assim, caso os serviços venham a mudar, as classes que os utilizam não são afetadas;
* UsuarioController, EmprestimoController, ReservaController, LivrosController: controlam os casos de uso chamando as ações necessárias para realizá-los.
    * Pelo padrão Controller do GRASP, recebem os eventos do sistema e delegam as responsabilidades;
* UsuarioPort, RelogioPort, BDPort, AutenticadorPort, NotificadorPort: definem um contrato estável entre os adaptadores e o domínio.
    * Pelo padrão indirection do GRASP, as portas são inseridas para não gerar acoplamento entre o núcleo e os adaptadores, que podem mudar sem alterar o domínio;
    * Por OCP, estabelecemos uma interface estável (porta) que pode ser implementada por qualquer novo adapter que precisarmos;
* WebAdapter, RelogioAdapter, BDAdapter, AutenticadorAdapter, NotificadorAdapter: adaptam o input bruto vindo do sistema externo a uma entrada compreensível à aplicação, implementando a interface da sua respectiva porta.
