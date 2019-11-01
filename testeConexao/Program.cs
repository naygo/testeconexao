using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace testeConexao
{
    class Program
    {
        static void Main(string[] args)
        {
            SqlConnection con;
            string str;

            try
            {
                //conexão com o banco
                str = @"Data Source=PBR02INFLB31926;Initial Catalog=teste;Integrated Security=True";
                con = new SqlConnection(str);
                con.Open();
                Console.WriteLine("Banco de dados conectado");

                ////inserindo dados
                Console.Write("ID: ");
                int id = int.Parse(Console.ReadLine());
                Console.Write("Nome: ");
                string nome = Console.ReadLine();

                string inserir = "INSERT INTO produtos (id, produto) VALUES (" + id + ", '" + nome + "')";
                SqlCommand ins = new SqlCommand(inserir, con);
                ins.ExecuteNonQuery();
                Console.WriteLine("Dados cadastrados no banco.");

                //selecionando dados
                string select = "SELECT * FROM produtos";
                SqlCommand view = new SqlCommand(select, con);
                SqlDataReader dr = view.ExecuteReader();
                while (dr.Read())
                {
                    Console.WriteLine("ID: " + dr.GetValue(0).ToString());
                    Console.WriteLine("Nome: " + dr.GetValue(1).ToString());
                }
                con.Close();
            }
            catch(SqlException x)
            {
                Console.WriteLine(x.Message);
            }



            Console.ReadKey();
        }

    }
}
