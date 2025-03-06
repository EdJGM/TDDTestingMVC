using System;
using Reqnroll;
using TDDTestingMVC.Models;

namespace ReqnrollTesting.StepDefinitions
{
    [Binding]
    public class AreaCirculoStepDefinitions
    {
        private readonly AreaCirculo _areaCirculo = new AreaCirculo();
        private int _resultado;

        [Given("el radio es {int}")]
        public void GivenElRadioEs(int number)
        {
            _areaCirculo.area = number;
        }

        [Given("el valor de PI es {float}")]
        public void GivenElValorDePIEs(float number)
        {
            _areaCirculo.pi = number;
        }

        [When("se calcula el area del circulo")]
        public void WhenSeCalculaElAreaDelCirculo()
        {
            _resultado = _areaCirculo.CalcularArea();
        }

        [Then("el resultado debe ser {int}")]
        public void ThenElResultadoDebeSer(int result)
        {
            _resultado.CompareTo(result);
        }
    }
}
