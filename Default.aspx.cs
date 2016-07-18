using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ConversaoMoeda
{
    public class Moeda
    {
        public string Codigo { get; set; }
        public string NomeMoeda { get; set; }
    }

    public partial class Default : System.Web.UI.Page
    { 
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                List<Moeda> listaMoedaOrigem = new List<Moeda>();
                Moeda m0 = new Moeda();
                m0.Codigo = "";
                m0.NomeMoeda = "Selecione";
                listaMoedaOrigem.Add(m0);

                Moeda m1 = new Moeda();
                m1.Codigo = "USD";
                m1.NomeMoeda = "DOLAR";
                listaMoedaOrigem.Add(m1);

                Moeda m2 = new Moeda();
                m2.Codigo = "BRL";
                m2.NomeMoeda = "REAL";
                listaMoedaOrigem.Add(m2);

                Moeda m3 = new Moeda();
                m3.Codigo = "EUR";
                m3.NomeMoeda = "EURO";
                listaMoedaOrigem.Add(m3);

                if(listaMoedaOrigem.Count > 0)
                {
                    ddlMoedaOrigem.DataSource = listaMoedaOrigem;
                    ddlMoedaOrigem.DataValueField = "Codigo";
                    ddlMoedaOrigem.DataTextField = "NomeMoeda";
                    ddlMoedaOrigem.DataBind();
                }
                ddlMoedaDestino.Visible = false;

            }
            
        }

        protected void ddlMoedaOrigem_SelectedIndexChanged(object sender, EventArgs e)
        {
            ddlMoedaDestino.Visible = true;
            List<Moeda> listaMoedaDestino = new List<Moeda>();
            Moeda m1 = new Moeda();
            m1.Codigo = "USD";
            m1.NomeMoeda = "DOLAR";
            listaMoedaDestino.Add(m1);

            Moeda m2 = new Moeda();
            m2.Codigo = "BRL";
            m2.NomeMoeda = "REAL";
            listaMoedaDestino.Add(m2);

            Moeda m3 = new Moeda();
            m3.Codigo = "EUR";
            m3.NomeMoeda = "EURO";
            listaMoedaDestino.Add(m3);

            String moedaSelected = ddlMoedaOrigem.SelectedItem.Value;
            Moeda moedaRemover = new Moeda();
            foreach (Moeda m in listaMoedaDestino)
            {
                if (m.Codigo.Equals(moedaSelected))
                {
                    moedaRemover = m;
                }
            }
            listaMoedaDestino.Remove(moedaRemover);
            ddlMoedaDestino.DataSource = listaMoedaDestino;
            ddlMoedaDestino.DataValueField = "Codigo";
            ddlMoedaDestino.DataTextField = "NomeMoeda";
            ddlMoedaDestino.DataBind();
        }

        protected void ddlMoedaDestino_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void btnConverter_Click(object sender, EventArgs e)
        {
            try
            {
                WebServiceMoeda service = new WebServiceMoeda();
                decimal valorConvert = System.Convert.ToDecimal(txtValor.Text);
                lblConvertido.Text = service.ConvertGoogle(valorConvert, ddlMoedaOrigem.SelectedValue, ddlMoedaDestino.SelectedValue);
                //lblConvertido.Text = service.ConvertYahoo(valorConvert, ddlMoedaOrigem.SelectedValue, ddlMoedaDestino.SelectedValue);
            }
            catch(Exception ex)
            {
                String erro = "Erro na conversão de moeda: ";
                lblConvertido.Text = "";
                lblErro.Text = erro + ex.Message;
                System.Console.WriteLine(ex.Message);
            }
            
        }
    }
}