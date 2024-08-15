using System.Data.SqlClient;

namespace LHPets
{
    class Banco
    {
    private List<Clientes> lista=new List<Clientes>();
    public List<Clientes> GetLista()
    {
            return lista;
    }

         public String GetListaString()
         {
             string enviar = "<!DOCTYPE html>\n<html>\n<head>\n<meta charset='utf-8'/>\n" +
                             "<title>Cadastro de Cliente</title>\n" +
                             "<style>table{border-spacing: 0; border-collapse: collapse;} th, td{border: 1px solid black; padding: 0 10px;} tbody tr:nth-child(even){background: #6f47ff;}</style>" +
                             "</head>\n<body>" +
                             "<h1>Lista de Clientes</h1>" +
                             "<table><thead><tr>" +
                             "<th>CPF/CNPJ</th>" +
                             "<th>Nome</th>" +
                             "<th>Endereço</th>" +
                             "<th>RG/IE</th>" +
                             "<th>Tipo</th>" +
                             "<th>Valor</th>" +
                             "<th>Valor Imposto</th>" +
                             "<th>Total</th>" +
                             "</tr></thead><tbody>";

                    int i=0;
                         string corfundo="",cortexto="";
                        foreach (Clientes cli in GetLista())
                                {


                            if (i % 2 == 0)
                                    { corfundo ="#6f47ff"; cortexto="white";}
                                else
                                    { corfundo ="#ffffff"; cortexto="#6f47ff";}
                                    i++;

                                enviar = enviar +
                                            $"\n<br><div style = 'background-color:{corfundo};color:{cortexto};'>" +
                                            "<tr>" +
                                            $"<td>{cli.cpf_cnpj}</td>" +
                                            $"<td>{cli.nome}</td>" +
                                            $"<td>{cli.endereço}</td>" +
                                            $"<td>{cli.rg_ie}</td>" +
                                            $"<td>{cli.tipo}</td>" +
                                            $"<td>{cli.valor.ToString("C")}</td>" +
                                            $"<td>{cli.valor_imposto.ToString("C")}</td>" +
                                            $"<td>{cli.total.ToString("C")}</td>" +
                                            "</tr>" +
                                            "</br></div style>";
             }
             enviar += "</tbody></table></body></html>";
             return enviar;
         }

    public Banco()
    {
        try
                {
                            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(
                                "User ID=sa;Password=1234;" +
                                "Server=localhost\\SQLEXPRESS;" +
                                "Database=vendas;" +
                                "Trusted_Connection=false;"
                            );

                            using (SqlConnection conexao = new SqlConnection(builder.ConnectionString))
                            {
                                String sql = "SELECT * FROM tblclientes";
                                using (SqlCommand comando = new SqlCommand(sql, conexao))
                                {
                                    conexao.Open();
                                    using (SqlDataReader tabela = comando.ExecuteReader())
                                    {
                                    
                                        while(tabela.Read())
                                        {
                                            lista.Add(new Clientes()
                                            {
                                               
                                                cpf_cnpj = tabela["cpf_cnpj"].ToString(),
                                                nome = tabela["nome"].ToString(),
                                                endereço = tabela["endereco"].ToString(),
                                                rg_ie = tabela["rg_ie"].ToString(),
                                                tipo = tabela["tipo"].ToString(),
                                                valor = (float)Convert.ToDecimal(tabela["valor"]),
                                                valor_imposto = (float)Convert.ToDecimal(tabela["valor_imposto"]),
                                                total = (float)Convert.ToDecimal(tabela["total"])

                                            });
                                        }
                                    }
                                }
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.ToString());
                        }
                    }
    }

}

            //         public String GetListaString()
            //         {
            //             string enviar = "<!DOCTYPE html>\n<html>\n<head>\n<meta charset='utf-8'/>\n" +
            //                             "<title>Cadastro de Cliente</title>\n" +
            //                             "<style>table{border-spacing: 0; border-collapse: collapse;} th, td{border: 1px solid black; padding: 0 10px;} tbody tr:nth-child(even){background: #ccc;}</style>" +
            //                             "</head>\n<body>" +
            //                             "<h1>Lista de Clientes</h1>" +
            //                             "<table><thead><tr>" +
            //                             "<th>CPF/CNPJ</th>" +
            //                             "<th>Nome</th>" +
            //                             "<th>Endereço</th>" +
            //                             "<th>RG/IE</th>" +
            //                             "<th>Tipo</th>" +
            //                             "<th>Valor</th>" +
            //                             "<th>Valor Imposto</th>" +
            //                             "<th>Total</th>" +
            //                             "</tr></thead><tbody>";

            //                 enviar = enviar + 
            //                             "<b> CPF / CNPJ - Nome - Endereço - RG / IE - Tipo - Valor - Valor Imposto - Total </b>";
            //             int i=0;
            //             string corfundo="",cortexto="";

            //             foreach (Clientes cli in GetLista())
            //                     {


            //                 if (i % 2 == 0)
            //                         { corfundo ="#6f47ff"; cortexto="white";}
            //                     else
            //                         { corfundo ="#ffffff"; cortexto="#6f47ff";}
            //                         i++;


            //                 enviar = enviar +
            //                             $"\n<br><div style = 'background-color:{corfundo};color:{cortexto};'>" +
            //                             cli.cpf_cnpj + " - " +
            //                             cli.nome + " - " +
            //                             cli.endereço + " - " + 
            //                             cli.rg_ie + " - " +
            //                             cli.tipo + " - " + 
            //                             cli.valor.ToString("C") + " - " +
            //                             cli.valor_imposto.ToString("C") + " - " +
            //                             cli.total.ToString("C") + "<br>"+
            //                             "</div>";
                                            

            //                     }
            //             return enviar;
            //     }

            //         public void imprimirListaConsole(){
                            
            //                     Console.WriteLine(
            //                             " CPF / CNPJ " + " - " + 
            //                             " Nome " + " - " + 
            //                             " Endereço " + " - " + 
            //                             " RG / IE " + " - " + 
            //                             " Tipo " + " - " +
            //                             " Valor " + " - " + 
            //                             " Valor Imposto " + " - " + 
            //                             " Total "
            //                             );

            //                     foreach (Clientes cli in GetLista())
            //                     {
                                
            //                     Console.WriteLine( 
            //                             cli.cpf_cnpj + " - " +
            //                             cli.nome + " - " + 
            //                             cli.endereço + " - " + 
            //                             cli.rg_ie + " - " +
            //                             cli.tipo + " - " + 
            //                             cli.valor.ToString("C") + " - " +
            //                             cli.valor_imposto.ToString("C") + " - " +
            //                             cli.total.ToString("C")
            //                             );
                                
            //                     }
            //         }
            //     }
            // }