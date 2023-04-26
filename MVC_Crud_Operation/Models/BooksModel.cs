using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;

namespace MVC_Crud_Operation.Models
{
    public class BooksModel
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Amit jha\Documents\Final_Exams.mdf"";Integrated Security=True;Connect Timeout=30");


        [Required]
        [DisplayName("Id")]
        public int Id { get; set; }

        [Required]
        [DisplayName("Enter book name")]

        public string bookname {  get; set; }


        [Required]
        [DisplayName("Enter book price")]

        public int bookprice { get; set; }

        [Required]
        [DisplayName("Enter author name:")]

        public string author { get; set; }

        [Required]
        [DisplayName("Enter publication:")]
        public string publication { get; set; }


        public List<BooksModel> getData()
        {
            List<BooksModel> lst = new List<BooksModel>();
            string Query = "SELECT * FROM Books_tbl";
            SqlDataAdapter sda = new SqlDataAdapter(Query, connection);
            DataSet dt = new DataSet();
            sda.Fill(dt);
            foreach(DataRow dr in dt.Tables[0].Rows)
            {
                lst.Add(new BooksModel
                {

                })
            }
            return lst;
        }

    }
}
