# Alternativas e Trade-offs

Alternativa A (escolhida): Monólito modular com hexagonal
Alternativa B: SOA
Alternativa C: Microsserviços

## Modificabilidade
ASRs relacionados: RF2, RN4 e L3
A: +  B: 0  C: - 
Justificativa: A isola bem os componentes e permite modificá-los de modo independente. B também possui componentes isolados, mas pode ser mais complexo por questões de versionamento. Em C, uma mudança de contrato de um serviço pode propagar mudança para todos os serviços que interagem com ele.

## Desempenho
ASRs relacionados: L2 (sincronização de reservas, empréstimos e devoluções)
A: - B: + C: + 
Justificativa: B e C permitem distribuir carga, enquanto A delega todo processamento a uma única máquina.

## Disponibilidade
Não há ASRs que apontem para esse atributo 
Justificativa: L2 apresenta poucos usuários esperados para questões de disponibilidade.

## Testabilidade
ASRs relacionados: L3
A: +  B: -  C: -
Justificativa: A permite testar com diferentes portas de entrada e saída, enquanto B e C exigem testes mais complexos e análise distribuída.


## Complexidade
ASRs relacionados: L3
A: 0  B: -  C: --
Justificativa: B é mais complexo que A por necessitar de controle de sistemas distribuídos, e C é mais complexo que B, por ser ainda mais distribuído.

## Implantação
ASRs relacionados: L3
A: +  B: -  C: -
Justificativa: A faz um deploy único, enquanto B e C precisam de vários deploys.

## Escalabilidade
Não há ASRs que apontem para esse atributo

## Custo de desenvolvimento e operação
ASRs relacionados: L3
A: +  B: -  C: -
Justificativa: A pode ser desenvolvido por uma equipe pequena sem experiência com sistemas distribuídos, enquanto B e C exigem uma equipe grande com maturidade DevOps. 

## Conclusão baseada nos ASRs
A tabela final para os critérios considerados (os que tinham ASRs que indicavam sua importância) ficou assim:

 -------------------------------------------------
 | Atributo de qualidade       |  A  |  B  |  C  |
 -------------------------------------------------
 | Modificabilidade            |  +  |  0  |  -  |
 | Desempenho                  |  -  |  +  |  +  |
 | Testabilidade               |  +  |  -  |  -  |
 | Complexidade                |  0  |  -  |  –  |
 | Implantação                 |  +  |  -  |  -  |
 | Custo de desenv. e operação |  +  |  -  |  -  |
 -------------------------------------------------

Assim, foi escolhida a opção A: Monólito modular com hexagonal.