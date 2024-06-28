# Controle de mensalidades e aprovação de alunos

Este sistema é projetado para uso em escolas, oferecendo funcionalidades para a gestão das mensalidades e do desempenho acadêmico dos alunos. Ele permite a checagem do pagamento das mensalidades, garantindo com que os alunos estejam com o pagamento em dia. Além disso, o sistema verifica a média de notas de um aluno, checando se o mesmo tem os requisitos para passar de ano.

O sistema atualmente disponibiliza as fuções:
- CRUD de Alunos, Mensalidades e Avaliações;
- Cálculo de média; 
- Checagem do pagamento de mensalidades.

## Micosserviços

1. Alunos
   - Microsserviço de Alunos. Contém o CRUD de Alunos.
     
2. Avaliações
   - Microsserviço de Avaliações. Contém o CRUD de Avaliações e cálculo de média.
  
3. Mensalidades
   - Microsserviço de Mensalidades. Contém CRUD de Mensalidades e checagem do pagamento das mensalidades.

## Operações

### Alunos
- **Inserir:** Insere um novo aluno.

  Request:
  ```
   {
     "nome": "string",
     "curso": "string",
     "idade": int,
     "endereco": "string",
     "telefone": "string"
   }
  ```
- **Editar:** Edita os dados de um aluno, conforme o Id de aluno fornecido.

   Request:
   ```
   {
     "nome": "string",
     "curso": "string",
     "idade": int,
     "endereco": "string",
     "telefone": "string"
   }
   ```
- **BuscarTodos:** Busca todos os registros de aluno.

- **Buscar:** Busca um registro de aluno conforme o Id de aluno fornecido.

- **Remover:** Remove um registro de aluno conforme o Id de aluno fornecido.

- **Aprovar:** Muda o status de aprovação do aluno, utilizado pelo MS de avaliações após o cálculo de média.

  Request:
  ```
  {
     "id": int,
     "aprovar": enum (0 - EmAguardo, 1 - Aprovado, 2 - Reprovado) 
  }
   ```



### Avaliações
- **Inserir:** Insere uma nova avaliação.

  Request:
  ```
   {
     "nota": int,
     "materia": string,
     "idAluno": int
   }
  ```
- **Editar:** Edita os dados de uma avaliação, conforme o Id de avaliação fornecido.

   Request:
   ```
   {
     "nota": int,
     "materia": string
   }
   ```
- **BuscarTodos:** Busca todos os registros de avaliação.

- **Buscar:** Busca um registro de avaliação conforme o Id de avaliação fornecido.

- **BuscarPorAluno:** Busca todos registro de avaliação de um aluno, conforme o Id de aluno fornecido.

- **Remover:** Remove um registro de avaliação conforme o Id fornecido.

- **AprovarMedia:** Muda o status de aprovação de um aluno, conforme a média de todas as suas avaliações. Recebe o Id de um aluno para realizar o calculo.
  
### Mensalidades

- **Inserir:** Insere uma nova mensalidade.

  Request:
  ```
   {
     "mes": "string",
     "valor": int,
     "situacao": enum (0 - EmAberto, 1 - Paga),
     "idAluno": int
   }
  ```
- **Editar:** Edita os dados de uma mensalidade, conforme o Id de mensalidade fornecido.

   Request:
   ```
   {
     "valor": int,
     "situacao": int,
     "mes": "string"
   }
   ```
- **BuscarTodos:** Busca todos os registros de mensalidade.

- **BuscarMensalidade:** Busca um registro de mensalidade conforme o Id de mensalidade fornecido.

- **BuscarPorAluno:** Busca a última mensalidade de um aluno, conforme o Id de aluno fornecido.

- **Remover:** Remove um registro de mensalidade conforme o Id fornecido.

- **AprovarMedia:** Muda o status de mensalidade de um aluno aluno, conforme a o status da última mensalidade dele. Recebe o Id de um aluno.

