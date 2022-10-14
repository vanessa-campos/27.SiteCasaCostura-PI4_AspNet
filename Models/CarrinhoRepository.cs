using System;
using System.Collections.Generic;
using MySqlConnector;


namespace PIE4_VanessaCampos.Models
{
    public class CarrinhoRepository
    {
	    private const string DadosConexao = "Database=casacostura;Data Source=localhost;User Id=root;";

        public void Adicionar(Carrinho carrinho){
	        MySqlConnection Conexao = new MySqlConnection(DadosConexao);
	        Conexao.Open(); 
	        String Query = "Insert into Carrinho (Usuario, Produto, Quantidade) values (@Usuario, @Produto, @Quantidade)";
	        MySqlCommand Comando = new MySqlCommand(Query, Conexao);
	        Comando.Parameters.AddWithValue("@Usuario", carrinho.Usuario);
	        Comando.Parameters.AddWithValue("@Produto", carrinho.Produto);
	        Comando.Parameters.AddWithValue("@Quantidade", carrinho.Quantidade);
	        Comando.ExecuteNonQuery(); 
	        Conexao.Close(); 
        }		

        public List<Carrinho> Listar(){
			MySqlConnection Conexao = new MySqlConnection(DadosConexao);
			Conexao.Open(); 
			String Query = "select * from Carrinho";
			MySqlCommand Comando = new MySqlCommand(Query, Conexao);	
			MySqlDataReader Reader = Comando.ExecuteReader();
			List<Carrinho> Lista = new List<Carrinho>();
			while(Reader.Read()){
				Carrinho carrinho = new Carrinho();
				carrinho.Id = Reader.GetInt32("Id");	
				if(!Reader.IsDBNull(Reader.GetOrdinal("Produto")))
					carrinho.Produto = Reader.GetString("Produto");
				carrinho.Quantidade = Reader.GetInt32("Quantidade");
				Lista.Add(carrinho);
			}
			Conexao.Close(); 
			return Lista;
		}
        
        public void Excluir(Carrinho carrinho){
	        MySqlConnection Conexao = new MySqlConnection(DadosConexao);
	        Conexao.Open(); 
	        String Query = "delete from Carrinho where Id=@Id";
	        MySqlCommand Comando = new MySqlCommand(Query, Conexao);
	        Comando.Parameters.AddWithValue("@Id", carrinho.Id);
	        Comando.ExecuteNonQuery(); 
	        Conexao.Close(); 
        }

		public Carrinho BuscarPorId(int Id){
			MySqlConnection Conexao = new MySqlConnection(DadosConexao);
			Conexao.Open(); 
			String Query = "select * from Carrinho where Id=@Id";
			MySqlCommand Comando = new MySqlCommand(Query, Conexao);		
			Comando.Parameters.AddWithValue("@Id", Id);
			MySqlDataReader Reader = Comando.ExecuteReader();
			Carrinho carrinhoEncontrado = new Carrinho();
			if(Reader.Read()){
				carrinhoEncontrado.Id = Reader.GetInt32("Id");
				carrinhoEncontrado.Usuario = Reader.GetInt32("USuario");
				if(!Reader.IsDBNull(Reader.GetOrdinal("Produto")))
					carrinhoEncontrado.Produto = Reader.GetString("Produto");
				carrinhoEncontrado.Quantidade = Reader.GetInt32("Quantidade");
			}
			Conexao.Close(); 	
			return carrinhoEncontrado;
		}

        public Carrinho BuscarCarrinho(int Id){
			MySqlConnection Conexao = new MySqlConnection(DadosConexao);
			Conexao.Open(); 
			String Query = "select * from Carrinho where Id=@Usuario";
			MySqlCommand Comando = new MySqlCommand(Query, Conexao);		
			Comando.Parameters.AddWithValue("@Usuario", Id);
			MySqlDataReader Reader = Comando.ExecuteReader();
			Carrinho carrinhoEncontrado = new Carrinho();
			if(Reader.Read()){
				carrinhoEncontrado.Usuario = Reader.GetInt32("Id");
			}
			Conexao.Close(); 	
			return carrinhoEncontrado;
		}

		public void Atualizar(Carrinho carrinho){
			MySqlConnection Conexao = new MySqlConnection(DadosConexao);
	        Conexao.Open(); 
	        String Query = "update Carrinho set Quantidade=@Quantidade where Id=@Id";
	        MySqlCommand Comando = new MySqlCommand(Query, Conexao);
	        Comando.Parameters.AddWithValue("@Id", carrinho.Id);
	        Comando.Parameters.AddWithValue("@Quantidade", carrinho.Quantidade);
	        Comando.ExecuteNonQuery(); 
	        Conexao.Close(); 
        }
		                                                                                                                            
		public List<Produto> ListarProdutos(){
			MySqlConnection Conexao = new MySqlConnection(DadosConexao);
			Conexao.Open(); 
			String Query = "select * from Produto";
			MySqlCommand Comando = new MySqlCommand(Query, Conexao);	
			MySqlDataReader Reader = Comando.ExecuteReader();
			List<Produto> Lista = new List<Produto>();
			while(Reader.Read()){
				Produto produto = new Produto();
				produto.Id = Reader.GetInt32("Id");	
				if(!Reader.IsDBNull(Reader.GetOrdinal("Nome")))
					produto.Nome = Reader.GetString("Nome");
				produto.Quantidade = Reader.GetInt32("Quantidade");
				Lista.Add(produto);
			}
			Conexao.Close(); 
			return Lista;
		}
    }
}