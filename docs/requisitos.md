# Requisitos

## Requisitos Funcionais:
1. Um estudante deve ser notificado do atraso de um livro que emprestou, bem como da indisponibilidade, remoção ou mudança de um livro que reservou;
2. A manutenção de outras partes do sistema não deve afetar o monitoramento de reservas e atrasos; 
3. O arquivista deve modificar a disponibilidade de um livro e inserir/remover/modificar o registro de um livro;
4. O assistente deve poder registrar empréstimo e devolução e modificar a disponibilidade de um livro;
5. O sistema deve notificar o estudante quando um empréstimo feito está perto de expirar;
6. O sistema deve informar o estudante quando houver atraso na devolução de um livro;
7. O sistema deve fornecer ao estudante opção de renovar o empréstimo de livros;
8. O sistema deve permitir ao estudante a  consulta de livros e reserva de livros disponíveis

## Requisitos não-funcionais:
1. Não é necessário que o sistema escale;
2. Os dados sobre disponibilidade de livros precisam estar consistentes pelo menos 99,99% do tempo;
3. O sistema deve apresentar pelo menos 80% de estabilidade (baixa);
4. As regras de negócio devem ficar isoladas e estáveis;
5. A inserção de um novo livro no sistema pode demorar até 5 minutos para ficar consistente;
6. Reservas e empréstimos devem ser idempotentes

## Restrições: 
1. Integração com sistema de login da universidade;
2. A parte de consulta de livros deve suportar até 500 usuários simultâneos;
3. Equipe pequena sem experiência com sistemas distribuídos

## ASRs 
* RF 2 
* RNs 2,4,5,6 
* Ls 1,2,3

## Comunicação:
Deve ser síncrono:
* informar empréstimo ao bd
* informar reserva ao bd
* informar devolução ao bd
* informar indisponibilidade ao bd
Pode ser assíncrono:
* disponibilizar e inserir livros
* notificar o estudante
