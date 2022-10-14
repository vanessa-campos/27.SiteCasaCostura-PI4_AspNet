using System;
using System.Collections.Generic;
using MySqlConnector;

namespace PIE4_VanessaCampos.Models
{
    public class AtendimentoRepository
    {
        private const string DadosConexao = "Database=casacostura;Data Source=localhost;User Id=root;";

        public void Solicitar(Atendimento atendimento){
	        MySqlConnection Conexao = new MySqlConnection(DadosConexao);
	        Conexao.Open(); 
	        String Query = "Insert into Atendimento (Nome, Email, Telefone, Mensagem) values (@Nome, @Email, @Telefone, @Mensagem)";
	        MySqlCommand Comando = new MySqlCommand(Query, Conexao);
	        Comando.Parameters.AddWithValue("@Nome", atendimento.Nome);
	        Comando.Parameters.AddWithValue("@Email", atendimento.Email);
	        Comando.Parameters.AddWithValue("@Telefone", atendimento.Telefone);
	        Comando.Parameters.AddWithValue("@Mensagem", atendimento.Mensagem);
	        Comando.ExecuteNonQuery(); 
	        Conexao.Close(); 
        }

        public List<Atendimento> Listar(){
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String Query = "select * from Atendimento";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            MySqlDataReader Reader = Comando.ExecuteReader();
            List<Atendimento> Lista = new List<Atendimento>();
            while (Reader.Read()){
                Atendimento atendimentoEncontrado = new Atendimento();
                atendimentoEncontrado.Id = Reader.GetInt32("Id");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
                    atendimentoEncontrado.Nome = Reader.GetString("Nome");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Email")))
                    atendimentoEncontrado.Email = Reader.GetString("Email");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Telefone")))
                    atendimentoEncontrado.Telefone = Reader.GetString("Telefone");
                if (!Reader.IsDBNull(Reader.GetOrdinal("Mensagem")))
                    atendimentoEncontrado.Mensagem = Reader.GetString("Mensagem");
                Lista.Add(atendimentoEncontrado);
            }
            Conexao.Close();
            return Lista;
        }

        public void Excluir(Atendimento atendimento) {
            MySqlConnection Conexao = new MySqlConnection(DadosConexao);
            Conexao.Open();
            String Query = "delete from Atendimento where Id=@Id";
            MySqlCommand Comando = new MySqlCommand(Query, Conexao);
            Comando.Parameters.AddWithValue("@Id", atendimento.Id);
            Comando.ExecuteNonQuery();
            Conexao.Close();
        }

        public Atendimento BuscarPorId(int Id){
			MySqlConnection Conexao = new MySqlConnection(DadosConexao);
			Conexao.Open(); 
			String Query = "select * from Atendimento where Id=@Id";
			MySqlCommand Comando = new MySqlCommand(Query, Conexao);		
			Comando.Parameters.AddWithValue("@Id", Id);
			MySqlDataReader Reader = Comando.ExecuteReader();
			Atendimento atendimentoEncontrado = new Atendimento();
			if(Reader.Read()){
				atendimentoEncontrado.Id = Reader.GetInt32("Id");                
				if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
					atendimentoEncontrado.Nome = Reader.GetString("Nome");
                if(!Reader.IsDBNull(Reader.GetOrdinal("Email")))
					atendimentoEncontrado.Email = Reader.GetString("Email");                
				if(!Reader.IsDBNull(Reader.GetOrdinal("Telefone")))
					atendimentoEncontrado.Telefone = Reader.GetString("Telefone");      
			}
			Conexao.Close(); 	
			return atendimentoEncontrado;
		}
    }
}