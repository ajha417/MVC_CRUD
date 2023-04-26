using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Data.SqlClient;
using System.Net;

namespace MVC_Crud_Operation.Models
{
    public class BooksModel
    {
        SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=""C:\Users\Amit jha\Documents\Final_Exams.mdf"";Integrated Security=True;Connect Timeout=30");


        [Required]
        [DisplayName("bookid")]
        public int bookid { get; set; }

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
                    bookid = Convert.ToInt32(dr["bookid"].ToString()),
                    bookname = dr["bookname"].ToString(),
                    bookprice = Convert.ToInt32(dr["bookprice"].ToString()),
                    author = dr["author"].ToString(),
                    publication = dr["publication"].ToString()
                });
            }
            return lst;
        }

        public BooksModel getData(string id)
        {
            BooksModel bmodel = new BooksModel();
            SqlCommand command = new SqlCommand("SELECT * FROM Books_tbl WHERE bookid='" + id + "'", connection);
            connection.Open();
            SqlDataReader dr = command.ExecuteReader();
            if (dr.HasRows)
            {
                while(dr.Read())
                {
                    bmodel.bookid = Convert.ToInt32(dr["bookid"].ToString());
                    bmodel.bookname = dr["bookname"].ToString();
                    bmodel.bookprice = Convert.ToInt32(dr["bookprice"].ToString());
                    bmodel.author = dr["author"].ToString();
                    bmodel.publication = dr["publication"].ToString();
                }
            }
            return bmodel;
        }


        //code to insert data
        public bool insert(BooksModel bmodel)
        {
            SqlCommand command = new SqlCommand("INSERT INTO Books_tbl VALUES(@bookname,@bookprice,@author,@publication)", connection);
            command.Parameters.AddWithValue("@bookname", bmodel.bookname);
            command.Parameters.AddWithValue("@bookprice", Convert.ToInt32(bmodel.bookprice));
            command.Parameters.AddWithValue("@author", bmodel.author);
            command.Parameters.AddWithValue("@publication", bmodel.publication);
            connection.Open();
            int i = command.ExecuteNonQuery();
            if(i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //code to update data
        public bool update(BooksModel bmodel)
        {
            SqlCommand command = new SqlCommand("UPDATE Books_tbl SET bookname=@bookname,bookprice=@bookprice,author=@author,publication=@publication WHERE bookid=@bookid", connection);
            command.Parameters.AddWithValue("@bookid",bmodel.bookid);
            command.Parameters.AddWithValue("@bookname", bmodel.bookname);
            command.Parameters.AddWithValue("@bookprice", Convert.ToInt32(bmodel.bookprice));
            command.Parameters.AddWithValue("@author", bmodel.author);
            command.Parameters.AddWithValue("@publication", bmodel.publication);
            connection.Open();
            int i = command.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool delete(BooksModel bmodel)
        {
            SqlCommand command = new SqlCommand("DELETE FROM Books_tbl WHERE bookId=@bookid", connection);
            command.Parameters.AddWithValue("@bookid", bmodel.bookid);
            
            connection.Open();
            int i = command.ExecuteNonQuery();
            if (i >= 1)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
