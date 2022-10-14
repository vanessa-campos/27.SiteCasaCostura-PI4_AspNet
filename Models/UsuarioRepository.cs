using System;
using System.Collections.Generic;
using MySqlConnector;

namespace PIE4_VanessaCampos.Models
{
    public class UsuarioRepository
    {       
	    private const string DadosConexao = "Database=casacostura;Data Source=localhost;User Id=root;";

	    public void TestarConexao(){
		    MySqlConnection Conexao = new MySqlConnection(DadosConexao);
		    Conexao.Open();
		    Console.WriteLine("Banco de dados funcionando!");
		    Conexao.Close();
	    }

		public void Cadastrar(Usuario user){
	        MySqlConnection Conexao = new MySqlConnection(DadosConexao);
	        Conexao.Open(); 
	        String Query = "Insert into Usuario (Nome, Email, Senha, DataNascimento, Telefone, Cep, Endereco) values (@Nome, @Email, @Senha, @DataNascimento, @Telefone, @Cep, @Endereco)";
	        MySqlCommand Comando = new MySqlCommand(Query, Conexao);
	        Comando.Parameters.AddWithValue("@Nome", user.Nome);
	        Comando.Parameters.AddWithValue("@Email", user.Email);
	        Comando.Parameters.AddWithValue("@Senha", user.Senha);
	        Comando.Parameters.AddWithValue("@DataNascimento", user.DataNascimento);
	        Comando.Parameters.AddWithValue("@Telefone", user.Telefone);	
	        Comando.Parameters.AddWithValue("@Cep", user.Cep);	
	        Comando.Parameters.AddWithValue("@Endereco", user.Endereco);
	        Comando.ExecuteNonQuery(); 
	        Conexao.Close(); 
        }   

        public List<Usuario> Listar(){
			MySqlConnection Conexao = new MySqlConnection(DadosConexao);
			Conexao.Open(); 
			String Query = "select * from Usuario";
			MySqlCommand Comando = new MySqlCommand(Query, Conexao);	
			MySqlDataReader Reader = Comando.ExecuteReader();
			List<Usuario> Lista = new List<Usuario>();
			while(Reader.Read()){
				Usuario userEncontrado = new Usuario();
				userEncontrado.Id = Reader.GetInt32("Id");
				if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
					userEncontrado.Nome = Reader.GetString("Nome");
				if(!Reader.IsDBNull(Reader.GetOrdinal("Email")))
					userEncontrado.Email = Reader.GetString("Email");
				if(!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
					userEncontrado.Senha = Reader.GetString("Senha");		
				userEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");	
				if(!Reader.IsDBNull(Reader.GetOrdinal("Telefone")))
					userEncontrado.Telefone = Reader.GetString("Telefone");
				if(!Reader.IsDBNull(Reader.GetOrdinal("Cep")))
					userEncontrado.Cep = Reader.GetString("Cep");
				if(!Reader.IsDBNull(Reader.GetOrdinal("Endereco")))
					userEncontrado.Endereco = Reader.GetString("Endereco");
				Lista.Add(userEncontrado);
			}
			Conexao.Close(); 
			return Lista;
		}

        public void Editar(Usuario user){
	        MySqlConnection Conexao = new MySqlConnection(DadosConexao);
	        Conexao.Open(); 
	        String Query = "update Usuario set Nome=@Nome, Email=@Email, Senha=@Senha, DataNascimento=@DataNascimento, Telefone=@Telefone, Cep=@Cep, Endereco=@Endereco where Id=@Id";
	        MySqlCommand Comando = new MySqlCommand(Query, Conexao);
	        Comando.Parameters.AddWithValue("@Id", user.Id);
	        Comando.Parameters.AddWithValue("@Nome", user.Nome);
	        Comando.Parameters.AddWithValue("@Email", user.Email);
	        Comando.Parameters.AddWithValue("@Senha", user.Senha);
	        Comando.Parameters.AddWithValue("@DataNascimento", user.DataNascimento);	
	        Comando.Parameters.AddWithValue("@Telefone", user.Telefone);
	        Comando.Parameters.AddWithValue("@Cep", user.Cep);
	        Comando.Parameters.AddWithValue("@Endereco", user.Endereco);
	        Comando.ExecuteNonQuery(); 
	        Conexao.Close(); 
        }

        public void Excluir(Usuario user){
	        MySqlConnection Conexao = new MySqlConnection(DadosConexao);
	        Conexao.Open(); 
	        String Query = "delete from Usuario where Id=@Id";
	        MySqlCommand Comando = new MySqlCommand(Query, Conexao);
	        Comando.Parameters.AddWithValue("@Id", user.Id);
	        Comando.ExecuteNonQuery(); 
	        Conexao.Close(); 
        }      

		public Usuario BuscarPorId(int Id){
			MySqlConnection Conexao = new MySqlConnection(DadosConexao);
			Conexao.Open(); 
			String Query = "select * from Usuario where Id=@Id";
			MySqlCommand Comando = new MySqlCommand(Query, Conexao);		
			Comando.Parameters.AddWithValue("@Id", Id);
			MySqlDataReader Reader = Comando.ExecuteReader();
			Usuario userEncontrado = new Usuario();
			if(Reader.Read()){
				userEncontrado.Id = Reader.GetInt32("Id");
				if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
					userEncontrado.Nome = Reader.GetString("Nome");
				if(!Reader.IsDBNull(Reader.GetOrdinal("Email")))
					userEncontrado.Email = Reader.GetString("Email");
				if(!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
					userEncontrado.Senha = Reader.GetString("Senha");
				userEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");
				if(!Reader.IsDBNull(Reader.GetOrdinal("Telefone")))
					userEncontrado.Telefone = Reader.GetString("Telefone");
				if(!Reader.IsDBNull(Reader.GetOrdinal("Cep")))
					userEncontrado.Cep = Reader.GetString("Cep");
				if(!Reader.IsDBNull(Reader.GetOrdinal("Endereco")))
					userEncontrado.Endereco = Reader.GetString("Endereco");
			}
			Conexao.Close(); 	
			return userEncontrado;
		}

		public Usuario ValidarLogin(Usuario user){
	        MySqlConnection Conexao = new MySqlConnection(DadosConexao);
	        Conexao.Open(); 
	        String Query = "select * from Usuario where Email=@Email and Senha=@Senha";
	        MySqlCommand Comando = new MySqlCommand(Query, Conexao);		
	        Comando.Parameters.AddWithValue("@Email", user.Email);
	        Comando.Parameters.AddWithValue("@Senha", user.Senha);
	        MySqlDataReader Reader = Comando.ExecuteReader();
	        Usuario userEncontrado = null; 
	        if(Reader.Read()){
		        userEncontrado = new Usuario();
		        userEncontrado.Id = Reader.GetInt32("Id");
		        if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
		            userEncontrado.Nome = Reader.GetString("Nome");
		        if(!Reader.IsDBNull(Reader.GetOrdinal("Email")))
		            userEncontrado.Email = Reader.GetString("Email");
		        if(!Reader.IsDBNull(Reader.GetOrdinal("Senha")))
			        userEncontrado.Senha = Reader.GetString("Senha");
		        userEncontrado.DataNascimento = Reader.GetDateTime("DataNascimento");
				if(!Reader.IsDBNull(Reader.GetOrdinal("Telefone")))
					userEncontrado.Telefone = Reader.GetString("Telefone");
				if(!Reader.IsDBNull(Reader.GetOrdinal("Cep")))
					userEncontrado.Cep = Reader.GetString("Cep");
				if(!Reader.IsDBNull(Reader.GetOrdinal("Endereco")))
					userEncontrado.Endereco = Reader.GetString("Endereco");
	        }
	        Conexao.Close(); 
	        return userEncontrado;
        }

    }
}
 
