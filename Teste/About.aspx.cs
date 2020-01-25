using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Teste
{
    public partial class About : Page
    {
        private class Retorno
        {
            public int Id { get; set; }
            public string Telefone { get; set; }
            public string Modelo { get; set; }
            public decimal Valor { get; set; }
            public string Produto { get; set; }
            public DateTime Data { get; set; }

            public Retorno(int id, string telefone, string modelo, decimal valor, string produto, DateTime data)
            {
                Id = id;
                Telefone = telefone;
                Modelo = modelo;
                Valor = valor;
                Produto = produto;
                Data = data;
            }

            public Retorno()
            {

            }
        }

        private class Aparelho
        {
            public int Id { get; set; }
            public string Modelo { get; set; }
            public string Telefone { get; set; }

            public Aparelho(int id, string modelo, string telefone)
            {
                Id = id;
                Modelo = modelo;
                Telefone = telefone;
            }
        }
        private class Transacao
        {
            public decimal Valor { get; set; }
            public string Produto { get; set; }
            public DateTime Data { get; set; }

            public Transacao(decimal valor, string produto, DateTime data)
            {
                Valor = valor;
                Produto = produto;
                Data = data;
            }
        }

        DataTable dataTable = new DataTable();
        List<Retorno> retorno = new List<Retorno>();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            //retorno.Add(new Retorno(1, "993306627", "6s", 15, "Recarga", DateTime.Now));
            //retorno.Add(new Retorno(1, "993306627", "6s", 20, "Bilhete Unico", DateTime.Now));
            //retorno.Add(new Retorno(2, "993306627", "7s", 10, "Recarga", DateTime.Now));
            //retorno.Add(new Retorno(2, "993306627", "7s", 15, "Consulta Veícular", DateTime.Now));
            //retorno.Add(new Retorno(3, "993306627", "8s", 18, "Recarga", DateTime.Now));

            MontaTable();
            dgPrincipal.DataSource = buscaAparelhos();
            dgPrincipal.DataBind();

        }

        private object buscaAparelhos()
        {
            List<Aparelho> aparelhos = new List<Aparelho>();
            foreach(DataRow row in dataTable.Rows)
            {
               
                if (!aparelhos.Exists(a => a.Id == int.Parse(row["Id"].ToString())))
                {
                    aparelhos.Add(new Aparelho(int.Parse(row["Id"].ToString()), row["Modelo"].ToString(), row["Telefone"].ToString()));
                }
            }
             
            return aparelhos;
        }

        public String NovaLinha(object Id)
        {
            /* 
                * 1. Fecha a célula atual (Phone)
                * 2. Fecha a linha Atual
                * 3. Cria uma nova linha com o ID e a classe <TR id='...' style='...'>
                * 4. Cria uma célula em branco: <TD></TD>
                * 5. Cria uma nova célula para conter o gridview gvOrders
                ************************************************************/
            return String.Format(@"</td></tr><tr id ='{0}' class='collapse'>
               <td>Transações</td><td colspan='100' style='padding:0px; margin:0px;'>", Id);
        }


        protected void dgPrincipal_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int customerId =int.Parse( dgPrincipal.DataKeys[e.Row.RowIndex].Value.ToString());
                var gvOrders = (GridView)e.Row.FindControl("gvOrders");

                var pedidos = transacaoAparelho(customerId);
                gvOrders.DataSource = pedidos;
                gvOrders.DataBind();
            }
        }

        private object transacaoAparelho(int customerId)
        {
            List<Transacao> transacao = new List<Transacao>();

            foreach(DataRow row in dataTable.Rows)
            {
                if(int.Parse(row["Id"].ToString()) == customerId)
                {
                    transacao.Add(new Transacao(
                                                Convert.ToDecimal(row["Valor"].ToString()),
                                                row["Produto"].ToString(),
                                                Convert.ToDateTime(row["Data"].ToString())));
                }
            }

            return transacao;
        }

        public void MontaTable()
        {

            dataTable.Columns.Add("Id", typeof(int));
            dataTable.Columns.Add("Telefone", typeof(string));
            dataTable.Columns.Add("Modelo", typeof(string));
            dataTable.Columns.Add("Valor", typeof(decimal));
            dataTable.Columns.Add("Produto", typeof(string));
            dataTable.Columns.Add("Data", typeof(DateTime));
            dataTable.Rows.Add(1, "993306627", "6s", 15, "Recarga", DateTime.Now);
            dataTable.Rows.Add(1, "993306627", "6s", 20, "Bilhete Unico", DateTime.Now);
            dataTable.Rows.Add(2, "993306627", "7s", 10, "Recarga", DateTime.Now);
            dataTable.Rows.Add(2, "993306627", "7s", 1, "Consulta Veícular", DateTime.Now);
            dataTable.Rows.Add(3, "993306627", "8s", 18, "Recarga", DateTime.Now);
           
            
        }
    }
       
}
