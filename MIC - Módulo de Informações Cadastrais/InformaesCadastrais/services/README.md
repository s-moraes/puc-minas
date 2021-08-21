# MIC - Módulo de Informações Cadastrais  
  
## Ferramentas para build:  
- dotNET 3.1 SDK  
  
## Passos para execução (ambiente de teste/local):
1) dotnet ef migrations add InitialCreate --context SqliteDataContext --output-dir Migrations/SqliteMigrations  
2) dotnet run  
    
## Exemplo de uso:  
Para mais detalher, verificar a página da documentação pelo swagger: http://< address >:< port >/swagger/index.html  
  
  > **Registrar novo cliente:** POST http://< ADDRESS >:< PORT >/cadastro/register  
  >  Exemplo de requisição:   
> {  
> "firstName": "Cliente",  
> "lastName": "ZeroUm",  
> "username": "cliente01",  
> "password": "aaaaaa",  
> "documento": "11232345434",  
> "cidade": "Campinas",  
> "endereco": "Av Um Dois, n22",  
> "cep": "12121-111"  
> }  
  
> **Autenticação:** POST http://< ADDRESS >:< PORT >/cadastro/authenticate  
>  Exemplo de requisição:   
> {  
> "username": "cliente01",  
> "password": "aaaaaa"  
> }  
> Exemplo de resposta:  
> {  
> "id": 1,  
> "username": "cliente01",  
> "firstName": "Cliente",  
> "lastName": "ZeroUm",  
> "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjEiLCJuYmYiOjE2Mjg2ODQwMTYsImV4cCI6MTYyOTI4ODgxNiwiaWF0IjoxNjI4Njg0MDE2fQ.L68mzqz8PJtFo3GXhZoUvoG4yvuX2yxkZQ4xlui_mm8"  
> }  
