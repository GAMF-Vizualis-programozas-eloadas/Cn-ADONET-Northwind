using System;
using System.Data.SqlClient;

namespace CnANCA_Northwind
{
	class Program
	{
		static void Main(string[] args)
		{
			ReadData();
			InsertData();
			ReadData();
			DeleteData();
			ReadData();
		}

		private static void DeleteData()
		{
			Console.WriteLine("Connected data access - delete data");
			SqlConnection sc = new SqlConnection("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Northwind;Integrated Security=True;Persist Security Info=True");
			try
			{
				sc.Open();
				SqlCommand sco = new SqlCommand("delete from categories where CategoryName LIKE 'Books' and Description LIKE 'Programming, DOE'", sc);
				sco.ExecuteNonQuery();
				sc.Close();
			}
			catch (Exception exc)
			{
				Console.WriteLine("Database error: " + exc.Message);
			}
		}

		static void InsertData()
		{	Console.WriteLine("Connected data access - insert data");
			SqlConnection sc = new SqlConnection("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Northwind;Integrated Security=True;Persist Security Info=True");
			try
			{	sc.Open();
				SqlCommand sco = new SqlCommand("insert into categories(CategoryName,Description) values ('Books','Programming, DOE')", sc);
				sco.ExecuteNonQuery();
				sc.Close();
			}
			catch (Exception exc)
			{
				Console.WriteLine("Database error: " + exc.Message);
			}
		}

		static void ReadData()
		{
			Console.WriteLine("Connected data access - read data");
			SqlConnection sc = new SqlConnection("Data Source=(localdb)\\mssqllocaldb;Initial Catalog=Northwind;Integrated Security=True;Persist Security Info=True");
			try
			{	sc.Open();
				SqlCommand sco = new SqlCommand("select CategoryName,Description from categories", sc);
				SqlDataReader sdr = sco.ExecuteReader();
				if (sdr != null)
				{	Console.WriteLine("{0,-20}{1,-40}\n", "Categories", "Description");
					while (sdr.Read())
					{	Console.WriteLine("{0,-20}{1,-40}", sdr.GetString(0), sdr.GetString(1));
					}
					sdr.Close();
				}
				sc.Close();
			}
			catch (Exception exc)
			{	Console.WriteLine("Database error: " + exc.Message);
			}
		}
	}


}

