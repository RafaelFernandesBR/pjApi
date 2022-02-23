using MySql.Data.MySqlClient;
using Newtonsoft.Json;

namespace pjApi.models
{
	//class that will fetch data from mysql em table aplicativos, and return in json.
	public class dataModel
{
        private MySqlConnection conm {get; set;}

        public int id{ get; set; }
        public string Nome { get; set; }
public DateTime disponivel_ate{get; set; }
public string descricao{get; set; }
public string url{get; set; }

        public dataModel()
        {
//get a file json
StreamReader r = new StreamReader("conect-sql.json");
string readFile= r.ReadToEnd();
conectSql conectData= JsonConvert.DeserializeObject<conectSql>(readFile);

			this.conm = new MySqlConnection("Server="+conectData.server+";Database="+conectData.Database+";Uid="+conectData.user+";Pwd="+conectData.senha+";SSL Mode=None");
        }

        private List<dataModel> GetAllFClass(string query)
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
disponivel_ate =Convert.ToDateTime(reader["disponivel_ate"]),
descricao =Convert.ToString(reader["descricao"]),
url=Convert.ToString(reader["url"])
});
            }
            reader.Close();
            this.conm.Close();
return data;
}

private void DeletInsert(string query)
{
            this.conm.Open();
            MySqlCommand cmd = new MySqlCommand(query, this.conm);
            cmd.ExecuteNonQuery();
            this.conm.Close();
}

//return all
public List<dataModel> GetAll(string query)
{
var data=GetAllFClass(query);
return data;
}

//return app for id.
        public List<dataModel> GetId(string query)
        {
var data=GetAllFClass(query);
return data;
}

//delet fron id
        public void Delete(string query)
        {
DeletInsert(query);
}

//insert a data fron mysql.
public void Insert(string query)
{
            DeletInsert(query);
}

}
}
