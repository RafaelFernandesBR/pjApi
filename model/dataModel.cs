using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace testeAc.models
{
	//class that will fetch data from mysql em table aplicativos, and return in json.
	public class dataModel
{
        private MySqlConnection conm {get; set;}

        public int id{ get; set; }
        public string Nome { get; set; }
public string disponivel_ate{get; set; }
public string descricao{get; set; }

        public dataModel()
        {
//get a file json
StreamReader r = new StreamReader("conect-sql.json");
string readFile= r.ReadToEnd();
conectSql conectData= JsonConvert.DeserializeObject<conectSql>(readFile);

            this.conm = new MySqlConnection("Server="+conectData.server+";Database="+conectData.Database+";Uid="+conectData.user+";Pwd="+conectData.senha+";SSL Mode=None");
        }

        public List<dataModel> GetAll(string query)
        {
			            List<dataModel> data = new List<dataModel>();

            this.conm.Open();
            MySqlCommand cmd = new MySqlCommand(query, this.conm);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                data.Add(new dataModel
                {
//get a data em mysql
id = Convert.ToInt32(reader["id"]),
                Nome =Convert.ToString(reader["nome"]),
                disponivel_ate =Convert.ToString(reader["disponivel_ate"]),
                descricao =Convert.ToString(reader["descricao"])
                });
            }
            reader.Close();
            this.conm.Close();
return data;
}

//return app for id.
        public List<dataModel> GetId(string query)
        {
			            List<dataModel> data = new List<dataModel>();

            this.conm.Open();
            MySqlCommand cmd = new MySqlCommand(query, this.conm);
            MySqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                data.Add(new dataModel
                {
//get a data em mysql
id = Convert.ToInt32(reader["id"]),
                Nome =Convert.ToString(reader["nome"]),
                disponivel_ate =Convert.ToString(reader["disponivel_ate"]),
                descricao =Convert.ToString(reader["descricao"])
                });
            }
            reader.Close();
            this.conm.Close();
return data;
}

//insert a data fron mysql.
public void Insert(string query)
{
            this.conm.Open();
            MySqlCommand cmd = new MySqlCommand(query, this.conm);
            cmd.ExecuteNonQuery();
            this.conm.Close();
}

}
}
