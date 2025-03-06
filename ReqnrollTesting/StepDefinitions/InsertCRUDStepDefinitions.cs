using System;
using Reqnroll;
using FluentAssertions;
using TDDTestingMVC.data;

namespace ReqnrollTesting.StepDefinitions
{
    [Binding]
    public class InsertCRUDStepDefinitions
    {
        private readonly ClienteDataAccessLayer _clienteDAL = new ClienteDataAccessLayer();

        [Given("llenar los campos dentro del Formulario")]
        public void GivenLlenarLosCamposDentroDelFormulario(DataTable dataTable)
        {
            var resultado = dataTable.Rows.Count;

            resultado.Should().BeGreaterThanOrEqualTo(1);
        }

        [When("Registros ingresados en la BDD")]
        public void WhenRegistrosIngresadosEnLaBDD(DataTable dataTable)
        {
            var cliente = dataTable.CreateSet<Cliente>().ToList();

            Cliente cls = new Cliente();

            foreach (var item in cliente)
            {
                cls.Cedula = item.Cedula;
                cls.Apellidos = item.Apellidos;
                cls.Nombres = item.Nombres;
                cls.FechaNacimiento = item.FechaNacimiento;
                cls.Mail = item.Mail;
                cls.Telefono = item.Telefono;
                cls.Direccion = item.Direccion;
                cls.Estado = item.Estado;
            }

            _clienteDAL.AddCliente(cls);
        }

        [Then("Resultado del ingreso a la BDD")]
        public void ThenResultadoDelIngresoALaBDD(DataTable dataTable)
        {
            var resultadoBDD = _clienteDAL.GetAllClientes();
            var cliente = dataTable.CreateSet<Cliente>().ToList();

            int encontrado = 0;
            foreach (var clienteE in resultadoBDD)
            {
                if (resultadoBDD.Contains(clienteE))
                {
                    encontrado = 1;
                    break;
                }
            }

            Assert.True(encontrado> 0);
        }
    }
}
