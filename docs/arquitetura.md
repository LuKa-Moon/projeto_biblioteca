# Proposta Arquitetural

## Principais componentes (ou módulos)
## Responsabilidade de cada componente
## Dependências 
## Interfaces relevantes
## Mecanismos de comunicação
## Persistência
## Integrações externas
## Documentação de API (se tiver)


## Análise de Evolução
Como o sistema pode lidar com alterações nas integrações e tecnologias usadas: 

### Caso 1: Mudança no mecanismo de persistência:
O BDAdapter precisaria ser alterado para que se integrasse devidamente com o novo mecanismo, mas as outras classes não necessitariam de alteração. Isso se dá pelo fato de que a Arquitetura Hexagonal isola componentes externos como o banco de dados do restante da aplicação.

### Caso 2: Inclusão de um aplicativo mobile para consulta e reserva:
Nesse caso, seria necessário criar a classe MobileAdapter, que não precisaria implementar todas as portas, apenas UsuarioPort, ReservaPort e LivrosPort. O resto do código não precisaria ser alterado. Uma decisão arquitetural que beneficia essa mudança é a decisão de criar uma porta de entrada para cada uma das grandes funcionalidades do sistema. 
