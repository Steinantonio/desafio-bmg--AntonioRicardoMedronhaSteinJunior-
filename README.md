# desafio-bmg--AntonioRicardoMedronhaSteinJunior-

Api simples para o desafio proposto, sendo esta a opção B: Promoção → “100 iPhones por R$1 por hora”


Para rodar o Codigo :

1 - Fazer o clone do repositorio no github

2 - Abrir o Visual Studio, selecionar opção de abrir uma solução

3 - Abrir o arquivo .sln dentro do repositorio clonado no windows explorer

4 - "Play" na app, ou F5 executando o compilador do codigo. 

5 - Irá abrir uma aba com o Swagger e os dois endpoints para utilização. 

========================================== // ==========================================

** Endpoint de Comprar Iphones Exemplo de Chamada
    curl -X 'POST' \
      'http://localhost:5019/api/Promocao/comprar' \
      -H 'accept: text/plain' \
      -H 'Content-Type: application/json' \
      -d '3'
      
** Endpoint de ver status das vendas nos horarios
    curl -X 'GET' \
      'http://localhost:5019/api/Promocao/status' \
      -H 'accept: text/plain'
