# Proposta Arquitetural

## 1. Organização arquitetural

O sistema combina quatro estilos, cada um com um papel claro.

Foi decidido usar cliente-servidor na relação entre a Aplicação Web,
usada por estudante, assistente e arquivista, e o servidor, que é o
monólito. A conversa é síncrona e acontece exclusivamente através
do WebAdapter.

O monólito modular (ADR1) é dividido em módulos por caso de uso:
Consulta e reserva, empréstimo e devolução, CRUD de livros, controle
de disponibilidade, botificação e login e cadastro. Cada módulo tem
seu controller, seu service e seu repository, e só se comunicam por
interfaces IServices.

Seguindo arquitetura hexagonal (ADR2), casos de uso, modelos e repositório
central formam o núcleo. Tudo que é externo (web, relógio, banco,
autenticação, notificador) entra ou sai por uma porta, implementada
por um adaptador.

Também seguindo o estilo MVC (ADR3), o núcleo é organizado em
controllers, services e repositórios/modelos. A View é a aplicação web, o Controller são os controllers
de caso de uso e o Model são as classes de domínio (Livro, Exemplar,
Reserva, Emprestimo, Prazo, Usuario).

Uma requisição segue este fluxo principal: A aplicação web envia
uma requisição HTTP ao WebAdapter, que chama o controller do caso
de uso. O controller coordena o caso de uso e chama os services por
suas interfaces. Os services aplicam as regras dos modelos e usam o
repositório central, que acessa o banco pela porta BDPort, implementada
pelo BDAdapter. Quando há aviso ao estudante, o NotificacaoService usa
a porta NotificadorPort, implementada pelo NotificadorAdapter.

Além disso, a API relógio aciona o RelogioAdapter, que chama a
RelogioPort e dispara o NotificadorController para verificar atrasos
e vencimentos.

## 2. Principais componentes ou módulos

Fora do hexágono ficam a aplicação web, API relógio, banco de dados,
autenticação institucional e notificador. Na borda do hexágono ficam os
adaptadores (WebAdapter, RelogioAdapter, BDAdapter, AutenticadorAdapter
e NotificadorAdapter) e as portas (UsuarioPort, LivrosPort, ReservaPort,
EmprestimoPort, RelogioPort, BDPort, AutenticadorPort e NotificadorPort).

Dentro do núcleo ficam os controllers (UsuarioController,
EmprestimoController, ReservaController, LivrosController e
NotificadorController), os Modelos (Livro, Exemplar, Reserva, Emprestimo,
Prazo, Usuario e subclasses) e o Repositório central (Repository e um
repository por entidade).

## 3. Responsabilidade de cada componente

### 3.1 Fora do hexágono

A aplicação web tem quatro módulos: CRUD de livros, controle de
disponibilidade, empréstimo e devolução, e consulta e reserva. Ela
é a View do MVC, apresenta dados e captura as ações de estudante,
assistente e arquivista.

A API relógio é a fonte de tempo e o gatilho que dispara a verificação
de prazos. O banco de dados faz a persistência relacional única de
livros, exemplares, reservas, empréstimos e usuários.

O serviço de autenticação institucional é o sistema legado da
universidade: autentica o usuário e fornece os dados dos alunos. O
notificador é o mecanismo de envio de mensagens, que pode ser trocado.

### 3.2 Adaptadores

Os adaptadores de entrada são o WebAdapter e o RelogioAdapter (ou
APIAdapter). O WebAdapter recebe as requisições HTTP da Aplicação
Web, valida e converte para chamadas às portas de entrada e devolve a
resposta. O RelogioAdapter recebe o gatilho de tempo e chama a RelogioPort,
que aciona o NotificadorController.

Os adaptadores de saída são o BDAdapter, que implementa a BDPort,
o AutenticadorAdapter, que implementa a AutenticadorPort e o
NotificadorAdapter, que implementa a NotificadorPort.

### 3.3 Núcleo

Os controllers (UsuarioController, EmprestimoController, ReservaController,
LivrosController e NotificadorController) recebem o evento vindo da
porta e coordenam as operações do caso de uso.

Os services (EstudanteService, AssistenteService, ArquivistaService,
LivroService, ExemplarService, EmprestimoService, ReservaService,
AutenticacaoService e NotificacaoService) têm uma interface cada. Eles
executam a lógica de aplicação, por exemplo o ExemplarService, que
altera o estado de empréstimo, e criam as instâncias do domínio
(Creator). As interfaces isolam os pontos de mudança (Protected
Variations).

Os modelos (Livro, Exemplar, Reserva, Emprestimo, Prazo, ContratoTemporal
e Usuario, com as subclasses Estudante e Funcionario, e Funcionario
com Assistente e Arquivista) contém as regras e atributos do negócio
(Information Expert).

O repositório central tem o Repository como base (get, set,
criar, remover) e um repository por entidade: LivrosRepository,
ExemplaresRepository, ReservasRepository, EmprestimosRepository,
UsuariosRepository, EstudanteRepository, AssistenteRepository e
ArquivistaRepository. Ele é a única passagem do núcleo para o banco,
pela BDPort, e apenas busca e grava dados (alta coesão).

## 4. Dependências entre os componentes

A aplicação web depende apenas do WebAdapter, que é o único ponto
de acesso ao servidor. O WebAdapter depende das portas UsuarioPort,
LivrosPort, ReservaPort e EmprestimoPort e encaminha cada ação à porta
do seu caso de uso. O RelogioAdapter depende da RelogioPort e entrega o
trigger de tempo ao núcleo. Cada porta de entrada é implementada por
um controller correspondente.

O EmprestimoController orquestra empréstimo e devolução e
depende de IEmprestimoService, IEstudanteService, ILivroService,
IAssistenteService, INotificacaoService, EmprestimosRepository
e dos modelos. ReservaController orquestra reserva e depende de
IReservaService, IEstudanteService, ILivroService, INotificacaoService,
ReservasRepository e dos modelos. LivrosController gerencia o
CRUD de livros e a disponibilidade e depende de ILivroService,
IArquivistaService e LivrosRepository. UsuarioController gerencia login,
logout e cadastro e depende de IAutenticacaoService, AutenticadorPort e
UsuariosRepository. O NotificadorController varre reservas e empréstimos e
gera notificações de atraso e vencimento, depende de ReservasRepository,
EmprestimosRepository, INotificacaoService e RelogioPort.

Os services dependem dos modelos, do repositório central e de
outras IServices. Por exemplo, ReservaService usa IEstudanteService
e LivroService usa IExemplarService. NotificacaoService depende de
NotificadorPort e envia sem conhecer o notificador.  AutenticacaoService
depende de AutenticadorPort e autentica sem conhecer o sistema legado. O
repositório central depende da BDPort e dos modelos, para persistir e
reconstruir entidades.

Por fim, BDAdapter, AutenticadorAdapter e NotificadorAdapter dependem,
respectivamente, do banco, do sistema de autenticação e do Notificador,
e fazem a integração com cada um.

## 5. Interfaces relevantes

### 5.1 Portas

As portas de entrada são cinco. A UsuarioPort, LivrosPort, ReservaPort,
EmprestimoPort e RelogioPort.  Simplesmente chamam os controladores
correspondentes.

As portas de saída são BDPort, AutenticadorPort e NotificadorPort,
que conectam o sistema aos serviços externos.

### 5.2 Interfaces internas entre módulos

As interfaces internas são IEmprestimoService, IReservaService,
ILivroService, IExemplarService, IEstudanteService, IAssistenteService,
IArquivistaService, IAutenticacaoService, INotificacaoService e
INotificavel.

## 6. Mecanismos de comunicação

A comunicação entre a aplicação web e WebAdapter usa HTTP/REST com
JSON. É síncrona, pois o cliente-servidor é simples e adequado à carga
prevista. Entre os adaptadores e o núcleo, e entre controllers, services e
repositories, a comunicação é feita por chamada de método em processo,
via portas e interfaces. Também é síncrona, pois o monólito não usa
rede para comunicação interna e isso mantém o acoplamento mais baixo.

Registrar empréstimo, reserva, devolução e indisponibilidade no banco
é síncrono, devido ao RNF2.

Disponibilizar e inserir livros é assíncrono, e aceita até 5 minutos
de atraso. Notificar o estudante também é assíncrono, por envio pela
NotificadorPort, pois falhas no notificador não podem travar empréstimos
nem reservas. A verificação de atrasos e vencimentos é feita por
um trigger do Relógio para o NotificadorController e é assíncrona,
pois a varredura periódica é independente de outras ações .

## 7. Persistência

O banco é relacional e único, acessado só por BDPort e BDAdapter. Há
um repository por agregado (livros, exemplares, reservas, empréstimos
e usuários), todos herdando de Repository.

Os dados sobre a disponibilidade dos livros precisam ser consistêntes
de pelo menos 99,99% do tempo (RNF2), para que não haja empréstimo
acidental de livros indisponíveis. Portanto, informar ao banco o
empréstimo, a reserva, a devolução e a indisponibilidade é uma
comunicação síncrona.

Reservas e empréstimos devem ser idempotentes (RNF6), de modo que
não sejam registradas duas reservas ou dois empréstimos exatamente
iguais. Um livro novo não precisa ser apresentado como disponível
no exato momento de sua criação, e a inserção pode demorar até 5
minutos para ficar consistente.

## 8. Integrações externas

A autenticação institucional (legado) é acessada por AutenticadorPort
e AutenticadorAdapter e é usada para login e leitura dos dados dos alunos.

O banco de dados é acessado por BDPort e BDAdapter e é usado para
persistência.

O Notificador é acessado por NotificadorPort e NotificadorAdapter e é
usado para avisos de vencimento, atraso, indisponibilidade, remoção
ou mudança de livro reservado.

O Relógio é acessado por RelogioPort e APIAdapter e é usado como
trigger periódico.

## 9. Decisões de comunicação

As operações de informar ao banco o empréstimo, a reserva, a
devolução e a indisponibilidade de um livro são síncronas, para
proteger a consistência dos dados.

A disponibilização e a inserção de livros, e a notificação do
estudante, podem ser assíncronas, pois toleram atraso.

Se o notificador for trocado, a mudança fica restrita ao
NotificadorAdapter.

O monitoramento não deve ser impactado por manutenções (RF2), por
isso ele é acionado pello trigger do relógio externo.
