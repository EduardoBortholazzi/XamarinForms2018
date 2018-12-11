using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using App01_ConsultarCEP.Servico.Modelo;
using App01_ConsultarCEP.Servico;

namespace App01_ConsultarCEP
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            BOTAO.Clicked += buscarCEP;
        }

        private void buscarCEP(object sender, EventArgs args)
        {

            string cep = CEP.Text.Trim();

            if (isValidCEP(cep))
            {
                try
                {
                    Endereco end = ViaCEPServico.BuscarEnderecoViaCEP(cep);

                    if( end != null)
                    {
                        RESULTADO.Text = string.Format("Endereco :{2} de {3} {0}, {1}", end.localidade, end.uf, end.logradouro, end.bairro);
                    }
                    else
                    {
                        DisplayAlert("ERRO", "CEP NÃO ENCONTRADO", "OK");
                    }
                    
                }
                catch (Exception e)
                {
                    DisplayAlert("Erro Crítico", e.Message, "OK");
                }
               
            }


        }

        private bool isValidCEP(string cep)
        {
            bool valido = true;

            if (cep.Length != 8)
            {
                DisplayAlert("ERRO", "CEP Inválido! O CEP deve conter 8 caracteres.", "OK");
                valido = false;
                return valido;
            }

            int novoCEP = 0;
            if (int.TryParse(cep, out novoCEP))
            {
                DisplayAlert("ERRO", "CEP Inválido! O CEP deve ser composto apenas por números.", "OK");
                valido = false;
                return valido;
            }

            return valido;

        }

    }
}
