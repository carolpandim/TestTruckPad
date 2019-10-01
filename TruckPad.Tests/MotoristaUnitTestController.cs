using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using TruckPad.Services.Controllers;
using TruckPad.Services.Models;
using TruckPad.Services.Repository;
using TruckPad.Services.ViewModel;
using Xunit;

namespace TruckPad.Tests
{
    public class MotoristaUnitTestController
    {
        private MotoristaRepository repository;
        public static DbContextOptions<TruckPadContext> dbContextOptions { get; }

        //Usaria outra conexão, em caso de haver criado um banco de teste
        public static string connectionString = "Server=L0002986\\SQLEXPRESS14;Initial Catalog=TruckPad;Persist Security Info=True;User ID=sa;Password=LocalTeste123;";

        static MotoristaUnitTestController()
        {
            dbContextOptions = new DbContextOptionsBuilder<TruckPadContext>()
            .UseSqlServer(connectionString)
            .Options;
        }

        public MotoristaUnitTestController()
        {
            var context = new TruckPadContext(dbContextOptions);

            //Aqui faria uma primeira carga nas tabelas
            //DummyDataDBInitializer db = new DummyDataDBInitializer();
            //db.Seed(context);

            repository = new MotoristaRepository(context);
        }

        #region GetMotoristas
        [Fact]
        public async void Task_GetMotoristas_Return_OkResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);

            //Act  
            var data = await controller.GetMotoristas();

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_GetMotoristas_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);

            //Act  
            var data = controller.GetMotoristas();
            data = null;

            if (data != null)
            {
                //Assert  
                Assert.IsType<BadRequestResult>(data);
            }
        }

        [Fact]
        public async void Task_GetMotoristas_MatchResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);

            //Act  
            var data = await controller.GetMotoristas();

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var motoristas = okResult.Value.Should().BeAssignableTo<List<Motorista>>().Subject;

            Assert.Equal("José da Silva", motoristas[0].Nome);
            Assert.Equal(40, motoristas[0].Idade);
            Assert.Equal("M", motoristas[0].Sexo);
            Assert.True(motoristas[0].PossuiVeiculo);
            Assert.Equal("D", motoristas[0].TipoCnh.Trim());
            Assert.Null(motoristas[0].Telefone);
            Assert.Equal("(11) 91111-1111", motoristas[0].Celular);
            Assert.Equal("12345678901", motoristas[0].Cpf);
            Assert.Equal(Convert.ToDateTime("1979-09-01 00:00:00.0000000"), motoristas[0].DataNascimento);
            Assert.Equal("jose.silva@gmail.com", motoristas[0].Email);
            Assert.True(motoristas[0].Ativo);
            Assert.Equal(Convert.ToDateTime("2019-09-24 15:26:01.740"), motoristas[0].DataRegistro);

            Assert.Equal("Claudio de Abreu", motoristas[1].Nome);
            Assert.Equal(40, motoristas[1].Idade);
            Assert.Equal("M", motoristas[1].Sexo);
            Assert.False(motoristas[1].PossuiVeiculo);
            Assert.Equal("D", motoristas[1].TipoCnh.Trim());
            Assert.Null(motoristas[1].Telefone);
            Assert.Equal("(11) 91111-1111", motoristas[1].Celular);
            Assert.Equal("23456789012", motoristas[1].Cpf);
            Assert.Equal(Convert.ToDateTime("1979-09-01 00:00:00.0000000"), motoristas[1].DataNascimento);
            Assert.Equal("claudio.abreu@gmail.com", motoristas[1].Email);
            Assert.True(motoristas[1].Ativo);
            Assert.Equal(Convert.ToDateTime("2019-09-24 15:27:44.310"), motoristas[1].DataRegistro);

            Assert.Equal("Marcelo Castro", motoristas[2].Nome);
            Assert.Equal(40, motoristas[2].Idade);
            Assert.Equal("M", motoristas[2].Sexo);
            Assert.True(motoristas[2].PossuiVeiculo);
            Assert.Equal("D", motoristas[2].TipoCnh.Trim());
            Assert.Null(motoristas[2].Telefone);
            Assert.Equal("(11) 91111-1111", motoristas[2].Celular);
            Assert.Equal("34567890123", motoristas[2].Cpf);
            Assert.Equal(Convert.ToDateTime("1979-09-01 00:00:00.0000000"), motoristas[2].DataNascimento);
            Assert.Equal("marcelo.castro@gmail.com", motoristas[2].Email);
            Assert.True(motoristas[2].Ativo);
            Assert.Equal(Convert.ToDateTime("2019-09-24 15:27:44.313"), motoristas[2].DataRegistro);
        }
        #endregion

        #region GetMotorista
        [Fact]
        public async void Task_GetMotorista_Return_OkResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);
            var idMotorista = 1;

            //Act  
            var data = await controller.GetMotorista(idMotorista);

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public async void Task_GetMotorista_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);
            var idMotorista = 4;

            //Act  
            var data = await controller.GetMotorista(idMotorista);

            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Task_GetMotorista_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);
            int? idMotorista = null;

            //Act  
            var data = await controller.GetMotorista(idMotorista);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_GetMotorista_MatchResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);
            int? idMotorista = 1;

            //Act  
            var data = await controller.GetMotorista(idMotorista);

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var motorista = okResult.Value.Should().BeAssignableTo<Motorista>().Subject;

            Assert.Equal("José da Silva", motorista.Nome);
            Assert.Equal(40, motorista.Idade);
            Assert.Equal("M", motorista.Sexo);
            Assert.True(motorista.PossuiVeiculo);
            Assert.Equal("D", motorista.TipoCnh.Trim());
            Assert.Null(motorista.Telefone);
            Assert.Equal("(11) 91111-1111", motorista.Celular);
            Assert.Equal("12345678901", motorista.Cpf);
            Assert.Equal(Convert.ToDateTime("1979-09-01 00:00:00.0000000"), motorista.DataNascimento);
            Assert.Equal("jose.silva@gmail.com", motorista.Email);
            Assert.True(motorista.Ativo);
            Assert.Equal(Convert.ToDateTime("2019-09-24 15:26:01.740"), motorista.DataRegistro);
        }
        #endregion

        #region AddMotorista
        [Fact]
        public async void Task_Add_ValidData_Return_OkResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);
            var motorista = new Motorista()
            {
                Nome = "Tom Jobim",
                Idade = 39,
                Sexo = "M",
                PossuiVeiculo = false,
                TipoCnh = "D",
                Telefone = "(11) 1111-1111",
                Celular = "(11) 91111-1111",
                Cpf = "45678901234",
                DataNascimento = Convert.ToDateTime("1980-07-01"),
                Email = "tom.jobim@gmail.com",
                Ativo = true
            };

            //Act               
            var data = await controller.PostMotorista(motorista);

            //Assert  
            Assert.IsType<CreatedAtActionResult>(data.Result);
        }

        [Fact]
        public async void Task_Add_InvalidData_Return_BadRequest()
        {
            //Arrange  
            var controller = new MotoristasController(repository);
            var motorista = new Motorista()
            {
                Nome = "Tom Jobim Tom Jobim Tom Jobim Tom Jobim Tom Jobim Tom Jobim Tom Jobim Tom Jobim Tom Jobim Tom Jobim Tom Jobim",
                Idade = 39,
                Sexo = "MM",
                PossuiVeiculo = false,
                TipoCnh = "DDDDDDDDDDD",
                Telefone = "(11) 1111-111111",
                Celular = "(11) 91111-111111",
                Cpf = "4567890123422",
                DataNascimento = Convert.ToDateTime("1980-07-01"),
                Email = "tom.jobim@gmail.com tom.jobim@gmail.com tom.jobim@gmail.com",
                Ativo = true
            };

            //Act              
            var data = await controller.PostMotorista(motorista);

            //Assert  
            Assert.IsType<BadRequestResult>(data.Result);
        }

        [Fact]
        public async void Task_Add_ValidData_MatchResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);
            var motorista = new Motorista()
            {
                Nome = "Nelson Mandela",
                Idade = 39,
                Sexo = "M",
                PossuiVeiculo = true,
                TipoCnh = "D",
                Telefone = "(11) 1111-1111",
                Celular = "(11) 91111-1111",
                Cpf = "56789012345",
                DataNascimento = Convert.ToDateTime("1980-07-01"),
                Email = "nelson.mandela@gmail.com",
                Ativo = true,
                DataRegistro = DateTime.Now
            };

            //Act  
            var data = await controller.PostMotorista(motorista);

            //Assert  
            Assert.IsType<CreatedAtActionResult>(data.Result);
        
            var result = (Motorista)((ObjectResult)((ActionResult<Motorista>)data.Should().Subject).Result).Value;

            Assert.Equal(13, result.IdMotorista);
        }
        #endregion

        #region UpdateMotorista
        [Fact]
        public async void Task_Update_ValidData_Return_OkResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);
            var idMotorista = 2;

            //Act  
            var existingMotorista = await controller.GetMotorista(idMotorista);
            var okResult = existingMotorista.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<Motorista>().Subject;

            var motorista = new Motorista();
            motorista.Nome = "Claudio de Abreu Updated";
            motorista.Idade = 39;
            motorista.Sexo = "M";
            motorista.PossuiVeiculo = false;
            motorista.TipoCnh = "D";
            motorista.Telefone = null;
            motorista.Celular = "(11) 90000-0000";
            motorista.Cpf = "23456789012";
            motorista.DataNascimento = Convert.ToDateTime("1980-09-01 00:00:00.0000000");
            motorista.Email = "claudio.abreu@gmail.com";
            motorista.Ativo = true;

            var updatedData = await controller.PutMotorista(motorista);

            //Assert  
            Assert.IsType<OkResult>(updatedData);
        }

        [Fact]
        public async void Task_Update_InvalidData_Return_BadRequest()
        {
            //Arrange  
            var controller = new MotoristasController(repository);
            var idMotorista = 2;

            //Act  
            var existingMotorista = await controller.GetMotorista(idMotorista);
            var okResult = existingMotorista.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<Motorista>().Subject;

            var motorista = new Motorista();
            motorista.Nome = "Claudio de Abreu Updated Claudio de Abreu Updated Claudio de Abreu Updated Claudio de Abreu Updated Claudio de Abreu Updated";
            motorista.Idade = result.Idade;
            motorista.Sexo = result.Sexo;
            motorista.PossuiVeiculo = result.PossuiVeiculo;
            motorista.TipoCnh = result.TipoCnh;
            motorista.Telefone = result.Telefone;
            motorista.Celular = result.Celular;
            motorista.Cpf = result.Cpf;
            motorista.DataNascimento = result.DataNascimento;
            motorista.Email = result.Email;
            motorista.Ativo = result.Ativo;

            var data = await controller.PutMotorista(motorista);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }

        [Fact]
        public async void Task_Update_InvalidData_Return_NotFound()
        {
            //Arrange  
            var controller = new MotoristasController(repository);
            var idMotorista = 2;

            //Act  
            var existingMotorista = await controller.GetMotorista(idMotorista);
            var okResult = existingMotorista.Should().BeOfType<OkObjectResult>().Subject;
            var result = okResult.Value.Should().BeAssignableTo<Motorista>().Subject;

            var motorista = new Motorista();
            motorista.IdMotorista = 5;
            motorista.Nome = "Claudio de Abreu";
            motorista.Idade = result.Idade;
            motorista.Sexo = result.Sexo;
            motorista.PossuiVeiculo = result.PossuiVeiculo;
            motorista.TipoCnh = result.TipoCnh;
            motorista.Telefone = result.Telefone;
            motorista.Celular = result.Celular;
            motorista.Cpf = result.Cpf;
            motorista.DataNascimento = result.DataNascimento;
            motorista.Email = result.Email;
            motorista.Ativo = result.Ativo;
            motorista.DataRegistro = result.DataRegistro;

            var data = await controller.PutMotorista(motorista);

            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }
        #endregion

        #region DeleteMotorista
        [Fact]
        public async void Task_Delete_Post_Return_OkResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);
            var idMotorista = 13;

            //Act  
            var data = await controller.DeleteMotorista(idMotorista);

            //Assert  
            Assert.IsType<OkResult>(data);
        }

        [Fact]
        public async void Task_Delete_Post_Return_NotFoundResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);
            var idMotorista = 5;

            //Act  
            var data = await controller.DeleteMotorista(idMotorista);

            //Assert  
            Assert.IsType<NotFoundResult>(data);
        }

        [Fact]
        public async void Task_Delete_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);
            int? idMotorista = null;

            //Act  
            var data = await controller.DeleteMotorista(idMotorista);

            //Assert  
            Assert.IsType<BadRequestResult>(data);
        }
        #endregion

        #region GetMotoristaSemCargaDestinoOrigem
        [Fact]
        public async void Task_GetMotoristaSemCargaDestinoOrigem_Return_OkResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);

            //Act  
            var data = await controller.GetMotoristaSemCargaDestinoOrigem();

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_GetMotoristaSemCargaDestinoOrigem_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);

            //Act  
            var data = controller.GetMotoristaSemCargaDestinoOrigem();
            data = null;

            if (data != null)
            {
                //Assert  
                Assert.IsType<BadRequestResult>(data);
            }
        }

        [Fact]
        public async void Task_GetMotoristaSemCargaDestinoOrigem_MatchResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);

            //Act  
            var data = await controller.GetMotoristaSemCargaDestinoOrigem();

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var motoristas = okResult.Value.Should().BeAssignableTo<List<MotoristaSemCargaDestinoOrigemViewModel>>().Subject;

            Assert.Equal(2, motoristas[0].IdViagem);
            Assert.Equal("Volta", motoristas[0].SentidoViagem);
            Assert.Equal("Não", motoristas[0].Carregado);
            Assert.Equal(2, motoristas[0].IdMotorista);
            Assert.Equal("Claudio de Abreu", motoristas[0].Nome);

            Assert.Equal(4, motoristas[1].IdViagem);
            Assert.Equal("Volta", motoristas[1].SentidoViagem);
            Assert.Equal("Não", motoristas[1].Carregado);
            Assert.Equal(1, motoristas[1].IdMotorista);
            Assert.Equal("José da Silva", motoristas[1].Nome);
        }
        #endregion

        #region GetMotoristaOrigemDestino
        [Fact]
        public async void Task_GetMotoristaOrigemDestino_Return_OkResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);

            //Act  
            var data = await controller.GetMotoristaOrigemDestino();

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_GetMotoristaOrigemDestino_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);

            //Act  
            var data = controller.GetMotoristaOrigemDestino();
            data = null;

            if (data != null)
            {
                //Assert  
                Assert.IsType<BadRequestResult>(data);
            }
        }

        [Fact]
        public async void Task_GetMotoristaOrigemDestino_MatchResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);

            //Act  
            var data = await controller.GetMotoristaOrigemDestino();

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var motoristas = okResult.Value.Should().BeAssignableTo<List<MotoristaOrigemDestinoViewModel>>().Subject;

            Assert.Equal(1, motoristas[0].IdViagem);
            Assert.Equal(2, motoristas[0].IdMotorista);
            Assert.Equal("Claudio de Abreu", motoristas[0].Nome);
            Assert.Equal(1, motoristas[0].IdEmpresaOrigem);
            Assert.Equal("Movati Transportes Ltda", motoristas[0].NomeEmpresaOrigem);
            Assert.Equal(821708, motoristas[0].IdEnderecoOrigem);
            Assert.Equal("Rua Florestópolis", motoristas[0].EnderecoOrigem);
            Assert.Equal("87", motoristas[0].NumeroLogradouroOrigem);
            Assert.Null(motoristas[0].ComplementoLogradouroOrigem);
            Assert.Equal(29365, motoristas[0].IdBairroOrigem);
            Assert.Equal("Ondas", motoristas[0].BairroOrigem);
            Assert.Equal("07171030", motoristas[0].CepOrigem.Trim());
            Assert.Equal(9205, motoristas[0].IdCidadeOrigem);
            Assert.Equal("Petrolândia", motoristas[0].CidadeOrigem);
            Assert.Equal(24, motoristas[0].IdEstadoOrigem);
            Assert.Equal("Santa Catarina", motoristas[0].EstadoOrigem);
            Assert.Equal("SC", motoristas[0].SiglaEstadoOrigem);
            Assert.Equal("-23.4298271", motoristas[0].LatitudeOrigem);
            Assert.Equal("-46.4382541", motoristas[0].LongitudeOrigem);
            Assert.Equal(2, motoristas[0].IdEmpresaDestino);
            Assert.Equal("Rodocerto Transportes Ltda", motoristas[0].NomeEmpresaDestino);
            Assert.Equal(997281, motoristas[0].IdEnderecoDestino);
            Assert.Equal("Rua Quirino dos Santos", motoristas[0].EnderecoDestino);
            Assert.Equal("380", motoristas[0].NumeroLogradouroDestino);
            Assert.Null(motoristas[0].ComplementoLogradouroDestino);
            Assert.Equal(35664, motoristas[0].IdBairroDestino);
            Assert.Equal("Eldorado", motoristas[0].BairroDestino);
            Assert.Equal("01141020", motoristas[0].CepDestino.Trim());
            Assert.Equal(9484, motoristas[0].IdCidadeDestino);
            Assert.Equal("Arabela (Ouro Verde)", motoristas[0].CidadeDestino);
            Assert.Equal(26, motoristas[0].IdEstadoDestino);
            Assert.Equal("Sergipe", motoristas[0].EstadoDestino);
            Assert.Equal("SE", motoristas[0].SiglaEstadoDestino);
            Assert.Equal("-23.5231029", motoristas[0].LatitudeDestino);
            Assert.Equal("-46.6645877", motoristas[0].LongitudeDestino);

            Assert.Equal(2, motoristas[1].IdViagem);
            Assert.Equal(2, motoristas[1].IdMotorista);
            Assert.Equal("Claudio de Abreu", motoristas[1].Nome);
            Assert.Equal(2, motoristas[1].IdEmpresaOrigem);
            Assert.Equal("Rodocerto Transportes Ltda", motoristas[1].NomeEmpresaOrigem);
            Assert.Equal(997281, motoristas[1].IdEnderecoOrigem);
            Assert.Equal("Rua Quirino dos Santos", motoristas[1].EnderecoOrigem);
            Assert.Equal("380", motoristas[1].NumeroLogradouroOrigem);
            Assert.Null(motoristas[1].ComplementoLogradouroOrigem);
            Assert.Equal(35664, motoristas[1].IdBairroOrigem);
            Assert.Equal("Eldorado", motoristas[1].BairroOrigem);
            Assert.Equal("01141020", motoristas[1].CepOrigem.Trim());
            Assert.Equal(9484, motoristas[1].IdCidadeOrigem);
            Assert.Equal("Arabela (Ouro Verde)", motoristas[1].CidadeOrigem);
            Assert.Equal(26, motoristas[1].IdEstadoOrigem);
            Assert.Equal("Sergipe", motoristas[1].EstadoOrigem);
            Assert.Equal("SE", motoristas[1].SiglaEstadoOrigem);
            Assert.Equal("-23.5231029", motoristas[1].LatitudeOrigem);
            Assert.Equal("-46.6645877", motoristas[1].LongitudeOrigem);
            Assert.Equal(1, motoristas[1].IdEmpresaDestino);
            Assert.Equal("Movati Transportes Ltda", motoristas[1].NomeEmpresaDestino);
            Assert.Equal(821708, motoristas[1].IdEnderecoDestino);
            Assert.Equal("Rua Florestópolis", motoristas[1].EnderecoDestino);
            Assert.Equal("87", motoristas[1].NumeroLogradouroDestino);
            Assert.Null(motoristas[1].ComplementoLogradouroDestino);
            Assert.Equal(29365, motoristas[1].IdBairroDestino);
            Assert.Equal("Ondas", motoristas[1].BairroDestino);
            Assert.Equal("07171030", motoristas[1].CepDestino.Trim());
            Assert.Equal(9205, motoristas[1].IdCidadeDestino);
            Assert.Equal("Petrolândia", motoristas[1].CidadeDestino);
            Assert.Equal(24, motoristas[1].IdEstadoDestino);
            Assert.Equal("Santa Catarina", motoristas[1].EstadoDestino);
            Assert.Equal("SC", motoristas[1].SiglaEstadoDestino);
            Assert.Equal("-23.4298271", motoristas[1].LatitudeDestino);
            Assert.Equal("-46.4382541", motoristas[1].LongitudeDestino);

            Assert.Equal(3, motoristas[2].IdViagem);
            Assert.Equal(1, motoristas[2].IdMotorista);
            Assert.Equal("José da Silva", motoristas[2].Nome);
            Assert.Equal(2, motoristas[2].IdEmpresaOrigem);
            Assert.Equal("Rodocerto Transportes Ltda", motoristas[2].NomeEmpresaOrigem);
            Assert.Equal(997281, motoristas[2].IdEnderecoOrigem);
            Assert.Equal("Rua Quirino dos Santos", motoristas[2].EnderecoOrigem);
            Assert.Equal("380", motoristas[2].NumeroLogradouroOrigem);
            Assert.Null(motoristas[2].ComplementoLogradouroOrigem);
            Assert.Equal(35664, motoristas[2].IdBairroOrigem);
            Assert.Equal("Eldorado", motoristas[2].BairroOrigem);
            Assert.Equal("01141020", motoristas[2].CepOrigem.Trim());
            Assert.Equal(9484, motoristas[2].IdCidadeOrigem);
            Assert.Equal("Arabela (Ouro Verde)", motoristas[2].CidadeOrigem);
            Assert.Equal(26, motoristas[2].IdEstadoOrigem);
            Assert.Equal("Sergipe", motoristas[2].EstadoOrigem);
            Assert.Equal("SE", motoristas[2].SiglaEstadoOrigem);
            Assert.Equal("-23.5231029", motoristas[2].LatitudeOrigem);
            Assert.Equal("-46.6645877", motoristas[2].LongitudeOrigem);
            Assert.Equal(3, motoristas[2].IdEmpresaDestino);
            Assert.Equal("J. C. Thedin Transportes", motoristas[2].NomeEmpresaDestino);
            Assert.Equal(973370, motoristas[2].IdEnderecoDestino);
            Assert.Equal("Rua Carmine Gaeta", motoristas[2].EnderecoDestino);
            Assert.Equal("92", motoristas[2].NumeroLogradouroDestino);
            Assert.Null(motoristas[2].ComplementoLogradouroDestino);
            Assert.Equal(34771, motoristas[2].IdBairroDestino);
            Assert.Equal("Colina Verde", motoristas[2].BairroDestino);
            Assert.Equal("02060100", motoristas[2].CepDestino.Trim());
            Assert.Equal(9416, motoristas[2].IdCidadeDestino);
            Assert.Equal("Poço Verde", motoristas[2].CidadeDestino);
            Assert.Equal(25, motoristas[2].IdEstadoDestino);
            Assert.Equal("São Paulo", motoristas[2].EstadoDestino);
            Assert.Equal("SP", motoristas[2].SiglaEstadoDestino);
            Assert.Equal("-23.5211882", motoristas[2].LatitudeDestino);
            Assert.Equal("-46.6019043", motoristas[2].LongitudeDestino);

            Assert.Equal(4, motoristas[3].IdViagem);
            Assert.Equal(1, motoristas[3].IdMotorista);
            Assert.Equal("José da Silva", motoristas[3].Nome);
            Assert.Equal(3, motoristas[3].IdEmpresaOrigem);
            Assert.Equal("J. C. Thedin Transportes", motoristas[3].NomeEmpresaOrigem);
            Assert.Equal(973370, motoristas[3].IdEnderecoOrigem);
            Assert.Equal("Rua Carmine Gaeta", motoristas[3].EnderecoOrigem);
            Assert.Equal("92", motoristas[3].NumeroLogradouroOrigem);
            Assert.Null(motoristas[3].ComplementoLogradouroOrigem);
            Assert.Equal(34771, motoristas[3].IdBairroOrigem);
            Assert.Equal("Colina Verde", motoristas[3].BairroOrigem);
            Assert.Equal("02060100", motoristas[3].CepOrigem.Trim());
            Assert.Equal(9416, motoristas[3].IdCidadeOrigem);
            Assert.Equal("Poço Verde", motoristas[3].CidadeOrigem);
            Assert.Equal(25, motoristas[3].IdEstadoOrigem);
            Assert.Equal("São Paulo", motoristas[3].EstadoOrigem);
            Assert.Equal("SP", motoristas[3].SiglaEstadoOrigem);
            Assert.Equal("-23.5211882", motoristas[3].LatitudeOrigem);
            Assert.Equal("-46.6019043", motoristas[3].LongitudeOrigem);
            Assert.Equal(2, motoristas[3].IdEmpresaDestino);
            Assert.Equal("Rodocerto Transportes Ltda", motoristas[3].NomeEmpresaDestino);
            Assert.Equal(997281, motoristas[3].IdEnderecoDestino);
            Assert.Equal("Rua Quirino dos Santos", motoristas[3].EnderecoDestino);
            Assert.Equal("380", motoristas[3].NumeroLogradouroDestino);
            Assert.Null(motoristas[3].ComplementoLogradouroDestino);
            Assert.Equal(35664, motoristas[3].IdBairroDestino);
            Assert.Equal("Eldorado", motoristas[3].BairroDestino);
            Assert.Equal("01141020", motoristas[3].CepDestino.Trim());
            Assert.Equal(9484, motoristas[3].IdCidadeDestino);
            Assert.Equal("Arabela (Ouro Verde)", motoristas[3].CidadeDestino);
            Assert.Equal(26, motoristas[3].IdEstadoDestino);
            Assert.Equal("Sergipe", motoristas[3].EstadoDestino);
            Assert.Equal("SE", motoristas[3].SiglaEstadoDestino);
            Assert.Equal("-23.5231029", motoristas[3].LatitudeDestino);
            Assert.Equal("-46.6645877", motoristas[3].LongitudeDestino);
        }
        #endregion

        #region GetMotoristaParada
        [Fact]
        public async void Task_GetMotoristaParada_Return_OkResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);

            //Act  
            var data = await controller.GetMotoristaParada();

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_GetMotoristaParada_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);

            //Act  
            var data = controller.GetMotoristaParada();
            data = null;

            if (data != null)
            {
                //Assert  
                Assert.IsType<BadRequestResult>(data);
            }
        }

        [Fact]
        public async void Task_GetMotoristaParada_MatchResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);

            //Act  
            var data = await controller.GetMotoristaParada();

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var motoristas = okResult.Value.Should().BeAssignableTo<List<MotoristaParadaViewModel>>().Subject;

            Assert.Equal(2, motoristas[0].IdMotorista);
            Assert.Equal("Claudio de Abreu", motoristas[0].Nome);
            Assert.Equal(40, motoristas[0].Idade);
            Assert.Equal("M", motoristas[0].Sexo);
            Assert.Equal("D", motoristas[0].TipoCNH.Trim());
            Assert.Equal("Sim", motoristas[0].Carregado);
            Assert.Equal("Caminhão 3/4", motoristas[0].TipoVeiculo.Trim());
            Assert.Equal(Convert.ToDateTime("2019-09-25"), motoristas[0].DataChegada);
            Assert.Equal("Empresa", motoristas[0].ProprietarioVeiculo);

            Assert.Equal(2, motoristas[1].IdMotorista);
            Assert.Equal("Claudio de Abreu", motoristas[1].Nome);
            Assert.Equal(40, motoristas[1].Idade);
            Assert.Equal("M", motoristas[1].Sexo);
            Assert.Equal("D", motoristas[1].TipoCNH.Trim());
            Assert.Equal("Não", motoristas[1].Carregado);
            Assert.Equal("Caminhão 3/4", motoristas[1].TipoVeiculo.Trim());
            Assert.Equal(Convert.ToDateTime("2019-09-26"), motoristas[1].DataChegada);
            Assert.Equal("Empresa", motoristas[1].ProprietarioVeiculo);

            Assert.Equal(1, motoristas[2].IdMotorista);
            Assert.Equal("José da Silva", motoristas[2].Nome);
            Assert.Equal(40, motoristas[2].Idade);
            Assert.Equal("M", motoristas[2].Sexo);
            Assert.Equal("D", motoristas[2].TipoCNH.Trim());
            Assert.Equal("Sim", motoristas[2].Carregado);
            Assert.Equal("Carreta Simples", motoristas[2].TipoVeiculo.Trim());
            Assert.Equal(Convert.ToDateTime("2019-09-25"), motoristas[2].DataChegada);
            Assert.Equal("Motorista", motoristas[2].ProprietarioVeiculo);

            Assert.Equal(1, motoristas[3].IdMotorista);
            Assert.Equal("José da Silva", motoristas[3].Nome);
            Assert.Equal(40, motoristas[3].Idade);
            Assert.Equal("M", motoristas[3].Sexo);
            Assert.Equal("D", motoristas[3].TipoCNH.Trim());
            Assert.Equal("Não", motoristas[3].Carregado);
            Assert.Equal("Carreta Simples", motoristas[3].TipoVeiculo.Trim());
            Assert.Equal(Convert.ToDateTime("2019-09-26"), motoristas[3].DataChegada);
            Assert.Equal("Motorista", motoristas[3].ProprietarioVeiculo);
        }
        #endregion

        #region GetMotoristaParadaCarregadoPorPeriodo
        [Fact]
        public async void Task_GetMotoristaParadaCarregadoPorPeriodo_Return_OkResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);

            //Act  
            var data = await controller.GetMotoristaParadaCarregadoPorPeriodo();

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_GetMotoristaParadaCarregadoPorPeriodo_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);

            //Act  
            var data = controller.GetMotoristaParadaCarregadoPorPeriodo();
            data = null;

            if (data != null)
            {
                //Assert  
                Assert.IsType<BadRequestResult>(data);
            }
        }

        [Fact]
        public async void Task_GetMotoristaParadaCarregadoPorPeriodo_MatchResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);

            //Act  
            var data = await controller.GetMotoristaParadaCarregadoPorPeriodo();

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var motoristas = okResult.Value.Should().BeAssignableTo<List<MotoristaParadaCarregadoPorPeriodoViewModel>>().Subject;

            Assert.Equal("Dia/Mês/Ano", motoristas[0].Periodo);
            Assert.Equal("25/09/2019", motoristas[0].Data);
            Assert.Equal(2, motoristas[0].TotalMotoristaParada);

            Assert.Equal("Mês/Semana", motoristas[1].Periodo);
            Assert.Equal("9/4", motoristas[1].Data);
            Assert.Equal(2, motoristas[1].TotalMotoristaParada);

            Assert.Equal("Mês", motoristas[2].Periodo);
            Assert.Equal("9", motoristas[2].Data);
            Assert.Equal(2, motoristas[2].TotalMotoristaParada);
        }
        #endregion

        #region GetMotoristaTipoVeiculoOrigemDestino
        [Fact]
        public async void Task_GetMotoristaTipoVeiculoOrigemDestino_Return_OkResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);

            //Act  
            var data = await controller.GetMotoristaTipoVeiculoOrigemDestino();

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_GetMotoristaTipoVeiculoOrigemDestino_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);

            //Act  
            var data = controller.GetMotoristaTipoVeiculoOrigemDestino();
            data = null;

            if (data != null)
            {
                //Assert  
                Assert.IsType<BadRequestResult>(data);
            }
        }

        [Fact]
        public async void Task_GetMotoristaTipoVeiculoOrigemDestino_MatchResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);

            //Act  
            var data = await controller.GetMotoristaTipoVeiculoOrigemDestino();

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var motoristas = okResult.Value.Should().BeAssignableTo<List<MotoristaTipoVeiculoOrigemDestinoViewModel>>().Subject;

            Assert.Equal("Caminhão 3/4", motoristas[0].TipoVeiculo);
            Assert.Equal(1, motoristas[0].IdViagem);
            Assert.Equal(2, motoristas[0].IdMotorista);
            Assert.Equal("Claudio de Abreu", motoristas[0].Nome);
            Assert.Equal(1, motoristas[0].IdEmpresaOrigem);
            Assert.Equal("Movati Transportes Ltda", motoristas[0].NomeEmpresaOrigem);
            Assert.Equal(821708, motoristas[0].IdEnderecoOrigem);
            Assert.Equal("Rua Florestópolis", motoristas[0].EnderecoOrigem);
            Assert.Equal("87", motoristas[0].NumeroLogradouroOrigem);
            Assert.Null(motoristas[0].ComplementoLogradouroOrigem);
            Assert.Equal(29365, motoristas[0].IdBairroOrigem);
            Assert.Equal("Ondas", motoristas[0].BairroOrigem);
            Assert.Equal("07171030", motoristas[0].CepOrigem.Trim());
            Assert.Equal(9205, motoristas[0].IdCidadeOrigem);
            Assert.Equal("Petrolândia", motoristas[0].CidadeOrigem);
            Assert.Equal(24, motoristas[0].IdEstadoOrigem);
            Assert.Equal("Santa Catarina", motoristas[0].EstadoOrigem);
            Assert.Equal("SC", motoristas[0].SiglaEstadoOrigem);
            Assert.Equal("-23.4298271", motoristas[0].LatitudeOrigem);
            Assert.Equal("-46.4382541", motoristas[0].LongitudeOrigem);
            Assert.Equal(2, motoristas[0].IdEmpresaDestino);
            Assert.Equal("Rodocerto Transportes Ltda", motoristas[0].NomeEmpresaDestino);
            Assert.Equal(997281, motoristas[0].IdEnderecoDestino);
            Assert.Equal("Rua Quirino dos Santos", motoristas[0].EnderecoDestino);
            Assert.Equal("380", motoristas[0].NumeroLogradouroDestino);
            Assert.Null(motoristas[0].ComplementoLogradouroDestino);
            Assert.Equal(35664, motoristas[0].IdBairroDestino);
            Assert.Equal("Eldorado", motoristas[0].BairroDestino);
            Assert.Equal("01141020", motoristas[0].CepDestino.Trim());
            Assert.Equal(9484, motoristas[0].IdCidadeDestino);
            Assert.Equal("Arabela (Ouro Verde)", motoristas[0].CidadeDestino);
            Assert.Equal(26, motoristas[0].IdEstadoDestino);
            Assert.Equal("Sergipe", motoristas[0].EstadoDestino);
            Assert.Equal("SE", motoristas[0].SiglaEstadoDestino);
            Assert.Equal("-23.5231029", motoristas[0].LatitudeDestino);
            Assert.Equal("-46.6645877", motoristas[0].LongitudeDestino);

            Assert.Equal("Caminhão 3/4", motoristas[1].TipoVeiculo);
            Assert.Equal(2, motoristas[1].IdViagem);
            Assert.Equal(2, motoristas[1].IdMotorista);
            Assert.Equal("Claudio de Abreu", motoristas[1].Nome);
            Assert.Equal(2, motoristas[1].IdEmpresaOrigem);
            Assert.Equal("Rodocerto Transportes Ltda", motoristas[1].NomeEmpresaOrigem);
            Assert.Equal(997281, motoristas[1].IdEnderecoOrigem);
            Assert.Equal("Rua Quirino dos Santos", motoristas[1].EnderecoOrigem);
            Assert.Equal("380", motoristas[1].NumeroLogradouroOrigem);
            Assert.Null(motoristas[1].ComplementoLogradouroOrigem);
            Assert.Equal(35664, motoristas[1].IdBairroOrigem);
            Assert.Equal("Eldorado", motoristas[1].BairroOrigem);
            Assert.Equal("01141020", motoristas[1].CepOrigem.Trim());
            Assert.Equal(9484, motoristas[1].IdCidadeOrigem);
            Assert.Equal("Arabela (Ouro Verde)", motoristas[1].CidadeOrigem);
            Assert.Equal(26, motoristas[1].IdEstadoOrigem);
            Assert.Equal("Sergipe", motoristas[1].EstadoOrigem);
            Assert.Equal("SE", motoristas[1].SiglaEstadoOrigem);
            Assert.Equal("-23.5231029", motoristas[1].LatitudeOrigem);
            Assert.Equal("-46.6645877", motoristas[1].LongitudeOrigem);
            Assert.Equal(1, motoristas[1].IdEmpresaDestino);
            Assert.Equal("Movati Transportes Ltda", motoristas[1].NomeEmpresaDestino);
            Assert.Equal(821708, motoristas[1].IdEnderecoDestino);
            Assert.Equal("Rua Florestópolis", motoristas[1].EnderecoDestino);
            Assert.Equal("87", motoristas[1].NumeroLogradouroDestino);
            Assert.Null(motoristas[1].ComplementoLogradouroDestino);
            Assert.Equal(29365, motoristas[1].IdBairroDestino);
            Assert.Equal("Ondas", motoristas[1].BairroDestino);
            Assert.Equal("07171030", motoristas[1].CepDestino.Trim());
            Assert.Equal(9205, motoristas[1].IdCidadeDestino);
            Assert.Equal("Petrolândia", motoristas[1].CidadeDestino);
            Assert.Equal(24, motoristas[1].IdEstadoDestino);
            Assert.Equal("Santa Catarina", motoristas[1].EstadoDestino);
            Assert.Equal("SC", motoristas[1].SiglaEstadoDestino);
            Assert.Equal("-23.4298271", motoristas[1].LatitudeDestino);
            Assert.Equal("-46.4382541", motoristas[1].LongitudeDestino);

            Assert.Equal("Carreta Simples", motoristas[2].TipoVeiculo.Trim());
            Assert.Equal(3, motoristas[2].IdViagem);
            Assert.Equal(1, motoristas[2].IdMotorista);
            Assert.Equal("José da Silva", motoristas[2].Nome);
            Assert.Equal(2, motoristas[2].IdEmpresaOrigem);
            Assert.Equal("Rodocerto Transportes Ltda", motoristas[2].NomeEmpresaOrigem);
            Assert.Equal(997281, motoristas[2].IdEnderecoOrigem);
            Assert.Equal("Rua Quirino dos Santos", motoristas[2].EnderecoOrigem);
            Assert.Equal("380", motoristas[2].NumeroLogradouroOrigem);
            Assert.Null(motoristas[2].ComplementoLogradouroOrigem);
            Assert.Equal(35664, motoristas[2].IdBairroOrigem);
            Assert.Equal("Eldorado", motoristas[2].BairroOrigem);
            Assert.Equal("01141020", motoristas[2].CepOrigem.Trim());
            Assert.Equal(9484, motoristas[2].IdCidadeOrigem);
            Assert.Equal("Arabela (Ouro Verde)", motoristas[2].CidadeOrigem);
            Assert.Equal(26, motoristas[2].IdEstadoOrigem);
            Assert.Equal("Sergipe", motoristas[2].EstadoOrigem);
            Assert.Equal("SE", motoristas[2].SiglaEstadoOrigem);
            Assert.Equal("-23.5231029", motoristas[2].LatitudeOrigem);
            Assert.Equal("-46.6645877", motoristas[2].LongitudeOrigem);
            Assert.Equal(3, motoristas[2].IdEmpresaDestino);
            Assert.Equal("J. C. Thedin Transportes", motoristas[2].NomeEmpresaDestino);
            Assert.Equal(973370, motoristas[2].IdEnderecoDestino);
            Assert.Equal("Rua Carmine Gaeta", motoristas[2].EnderecoDestino);
            Assert.Equal("92", motoristas[2].NumeroLogradouroDestino);
            Assert.Null(motoristas[2].ComplementoLogradouroDestino);
            Assert.Equal(34771, motoristas[2].IdBairroDestino);
            Assert.Equal("Colina Verde", motoristas[2].BairroDestino);
            Assert.Equal("02060100", motoristas[2].CepDestino.Trim());
            Assert.Equal(9416, motoristas[2].IdCidadeDestino);
            Assert.Equal("Poço Verde", motoristas[2].CidadeDestino);
            Assert.Equal(25, motoristas[2].IdEstadoDestino);
            Assert.Equal("São Paulo", motoristas[2].EstadoDestino);
            Assert.Equal("SP", motoristas[2].SiglaEstadoDestino);
            Assert.Equal("-23.5211882", motoristas[2].LatitudeDestino);
            Assert.Equal("-46.6019043", motoristas[2].LongitudeDestino);

            Assert.Equal("Carreta Simples", motoristas[3].TipoVeiculo.Trim());
            Assert.Equal(4, motoristas[3].IdViagem);
            Assert.Equal(1, motoristas[3].IdMotorista);
            Assert.Equal("José da Silva", motoristas[3].Nome);
            Assert.Equal(3, motoristas[3].IdEmpresaOrigem);
            Assert.Equal("J. C. Thedin Transportes", motoristas[3].NomeEmpresaOrigem);
            Assert.Equal(973370, motoristas[3].IdEnderecoOrigem);
            Assert.Equal("Rua Carmine Gaeta", motoristas[3].EnderecoOrigem);
            Assert.Equal("92", motoristas[3].NumeroLogradouroOrigem);
            Assert.Null(motoristas[3].ComplementoLogradouroOrigem);
            Assert.Equal(34771, motoristas[3].IdBairroOrigem);
            Assert.Equal("Colina Verde", motoristas[3].BairroOrigem);
            Assert.Equal("02060100", motoristas[3].CepOrigem.Trim());
            Assert.Equal(9416, motoristas[3].IdCidadeOrigem);
            Assert.Equal("Poço Verde", motoristas[3].CidadeOrigem);
            Assert.Equal(25, motoristas[3].IdEstadoOrigem);
            Assert.Equal("São Paulo", motoristas[3].EstadoOrigem);
            Assert.Equal("SP", motoristas[3].SiglaEstadoOrigem);
            Assert.Equal("-23.5211882", motoristas[3].LatitudeOrigem);
            Assert.Equal("-46.6019043", motoristas[3].LongitudeOrigem);
            Assert.Equal(2, motoristas[3].IdEmpresaDestino);
            Assert.Equal("Rodocerto Transportes Ltda", motoristas[3].NomeEmpresaDestino);
            Assert.Equal(997281, motoristas[3].IdEnderecoDestino);
            Assert.Equal("Rua Quirino dos Santos", motoristas[3].EnderecoDestino);
            Assert.Equal("380", motoristas[3].NumeroLogradouroDestino);
            Assert.Null(motoristas[3].ComplementoLogradouroDestino);
            Assert.Equal(35664, motoristas[3].IdBairroDestino);
            Assert.Equal("Eldorado", motoristas[3].BairroDestino);
            Assert.Equal("01141020", motoristas[3].CepDestino.Trim());
            Assert.Equal(9484, motoristas[3].IdCidadeDestino);
            Assert.Equal("Arabela (Ouro Verde)", motoristas[3].CidadeDestino);
            Assert.Equal(26, motoristas[3].IdEstadoDestino);
            Assert.Equal("Sergipe", motoristas[3].EstadoDestino);
            Assert.Equal("SE", motoristas[3].SiglaEstadoDestino);
            Assert.Equal("-23.5231029", motoristas[3].LatitudeDestino);
            Assert.Equal("-46.6645877", motoristas[3].LongitudeDestino);
        }
        #endregion

        #region GetMotoristaVeiculoProprio
        [Fact]
        public async void Task_GetMotoristaVeiculoProprio_Return_OkResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);

            //Act  
            var data = await controller.GetMotoristaVeiculoProprio();

            //Assert  
            Assert.IsType<OkObjectResult>(data);
        }

        [Fact]
        public void Task_GetMotoristaVeiculoProprio_Return_BadRequestResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);

            //Act  
            var data = controller.GetMotoristaVeiculoProprio();
            data = null;

            if (data != null)
            {
                //Assert  
                Assert.IsType<BadRequestResult>(data);
            }
        }

        [Fact]
        public async void Task_GetMotoristaVeiculoProprio_MatchResult()
        {
            //Arrange  
            var controller = new MotoristasController(repository);

            //Act  
            var data = await controller.GetMotoristaVeiculoProprio();

            //Assert  
            Assert.IsType<OkObjectResult>(data);

            var okResult = data.Should().BeOfType<OkObjectResult>().Subject;
            var motoristas = okResult.Value.Should().BeAssignableTo<List<MotoristaVeiculoProprioViewModel>>().Subject;

            Assert.Equal(1, motoristas[0].IdMotorista);
            Assert.Equal("José da Silva", motoristas[0].Nome);
            Assert.Equal(40, motoristas[0].Idade);
            Assert.Equal("M", motoristas[0].Sexo);
            Assert.True(motoristas[0].PossuiVeiculo);
            Assert.Equal("D", motoristas[0].TipoCNH.Trim());
            Assert.Null(motoristas[0].Telefone);
            Assert.Equal("(11) 91111-1111", motoristas[0].Celular);
            Assert.Equal("12345678901", motoristas[0].CPF);
            Assert.Equal(Convert.ToDateTime("1979-09-01 00:00:00.0000000"), motoristas[0].DataNascimento);
            Assert.Equal("jose.silva@gmail.com", motoristas[0].Email);
            Assert.True(motoristas[0].Ativo);        

            Assert.Equal(3, motoristas[1].IdMotorista);
            Assert.Equal("Marcelo Castro", motoristas[1].Nome);
            Assert.Equal(40, motoristas[1].Idade);
            Assert.Equal("M", motoristas[1].Sexo);
            Assert.True(motoristas[1].PossuiVeiculo);
            Assert.Equal("D", motoristas[1].TipoCNH.Trim());
            Assert.Null(motoristas[1].Telefone);
            Assert.Equal("(11) 91111-1111", motoristas[1].Celular);
            Assert.Equal("34567890123", motoristas[1].CPF);
            Assert.Equal(Convert.ToDateTime("1979-09-01 00:00:00.0000000"), motoristas[1].DataNascimento);
            Assert.Equal("marcelo.castro@gmail.com", motoristas[1].Email);
            Assert.True(motoristas[1].Ativo);
        }
        #endregion
    }


}
