# TestTruckPad

1 - Clonar projeto

2 - Unzip arquivo DUMP_DB, copiar conteúdo e anexar a um banco SQL Server Express 2017.

3 - Alterar "conexion string" dentro do projeto, colocando as configurações do seu banco local:
    - .\TruckPad\TruckPad.Services\appsettings.json
    - .\TruckPad\TruckPad.Tests\MotoristaUnitTestController.cs
		
4 - Abrir projeto no Visual Studio Community 2017

5 - Buildar projeto

6 - Executar projeto através do botão IIS Express. Ao executá-lo, abrirá uma página do Sweeger no seu navegador de preferência, onde poderá visualizar e testar todos os serviços requeridos no teste.

7 - Para realizar os testes unitários, vá até Test>Windows>Test Explorer, selecione a opção Run All.
