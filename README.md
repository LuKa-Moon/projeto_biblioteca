# Projeto: Sistema de gerenciamento de biblioteca

## Contexto do Sistema
* Sistema para uma biblioteca de um campus universitário, que permite reserva e busca de livros digitalmente;
* O número de alunos não vai aumentar consideravelmente;
* A biblioteca atende cerca de mil alunos por dia;
* A equipe é pequena e não tem experiência com sistemas distribuídos;
* É necessário integrar os dados dos alunos com o sistema legado da universidade;
* Os dados sobre disponibilidade de livros precisam ser o mais consistentes possível, para que não haja casos de empréstimo acidental de livros indisponíveis;
* O sistema não é crítico, ou seja, pode apresentar instabilidade sem grandes consequências;
* As regras de negócio não mudam com frequência;
* O mecanismo de notificação deve ser independente do resto do sistema, visto que poderá ser trocado futuramente;
* Um livro não precisa ser apresentado como disponível no exato momento de sua criação;
* Não podem ser registradas duas reservas / empréstimos exatamente iguais

### Partes diferentes do sistema:
* Consulta de livros e reserva
* Empréstimo e devolução
* Monitoramento de reservas e empréstimos (atrasos)
* Crud de livros
* Controle de disponibilidade de livros (torna disponíveis ou indisponíveis)

## Principais Atores
* Estudante: consulta, reserva, solicita empréstimo e devolução
* Assistente: efetiva empréstimo e devolução e muda disponibilidade
* Arquivista: crud de livros e muda disponibilidade 
