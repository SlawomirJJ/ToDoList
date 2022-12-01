using System.Data;
using System.Data.SqlClient;
using TODOList.Models;




namespace TODOList.services
{
    public class TasksDAO : ITaskDataService
    {
        string connectionString = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=TODOList;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        public int Delete(int Id)
        {
            int newIdNumber = -1;
            string sqlStatement = "DELETE FROM dbo.Tasks WHERE Id=@Id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("Id", Id);
                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return newIdNumber;
        }


        public List<TaskModel> GetAllTasksForDay(DateOnly date)
        {
            List<TaskModel> TasksForDay = new();
            string sqlStatement = "SELECT * FROM dbo.Tasks WHERE Date = @stringDate";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                string stringDate = date.Year + "-" + date.Month + "-" + date.Day;
                //command.Parameters.AddWithValue("@stringDate", DateTimeOffset.Parse(stringDate));
                command.Parameters.Add("@stringDate", SqlDbType.Date);
                command.Parameters["@stringDate"].Value = stringDate;
                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        TasksForDay.Add(new TaskModel { Id = (int)reader[0], Name = (string)reader[1], IsDone = (bool)reader[2], Date = DateOnly.FromDateTime((DateTime)reader[3]), Priority = (string)reader[4], Regularity = (bool)reader[5], StartTime = ((TimeSpan)reader[6]), EndTime = ((TimeSpan)reader[7]), Description = (string)reader[8] });
                    }

                    reader.Close();//DateOnly dateOnlyToday = DateOnly.FromDateTime(today);

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return TasksForDay;
        }

        public TaskModel GetTask(int Id)
        {
            TaskModel Task=new();
            string sqlStatement = "SELECT * FROM dbo.Tasks Where Id=@id";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("@id", Id);
                try
                {
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        Task = (new TaskModel { Id = (int)reader[0], Name = (string)reader[1], IsDone = (bool)reader[2], Date = DateOnly.FromDateTime((DateTime)reader[3]), Priority = (string)reader[4], Regularity = (bool)reader[5], StartTime = ((TimeSpan)reader[6]), EndTime = ((TimeSpan)reader[7]), Description = (string)reader[8] });
                    }

                    reader.Close();
                }
                catch (Exception ex)
                {

                    Console.WriteLine(ex.Message);
                }
            }
            return Task;
        }

        public int Insert(TaskModel task)
        {
            int newIdNumber = -1;
            string sqlStatement = "INSERT INTO dbo.Tasks (Name, IsDone,DateAndTime,Priority,Regularity) VALUES (@Name,@IsDone, @DateAndTime, @Priority, @Regularity)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("Name", task.Name);
                command.Parameters.AddWithValue("IsDone", task.IsDone);
                command.Parameters.AddWithValue("DateAndTime", task.Date);
                command.Parameters.AddWithValue("Priority", task.Priority);
                command.Parameters.AddWithValue("Regularity", task.Regularity);
                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return newIdNumber;
        }

        
        public int Update(TaskModel task)
        {
            int newIdNumber = -1;
            string sqlStatement = "UPDATE dbo.Tasks SET Name = @Name, IsDone = @IsDone, Date=@Date, Priority=@Priority, @Regularity=Regularity WHERE Id=@Id; ";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sqlStatement, connection);
                command.Parameters.AddWithValue("Name", task.Name);
                command.Parameters.AddWithValue("IsDone", task.IsDone);
                string stringDate = task.Date.Year + "-" + task.Date.Month + "-" + task.Date.Day;
                command.Parameters.AddWithValue("Date", stringDate);
                command.Parameters.AddWithValue("Priority", task.Priority);
                command.Parameters.AddWithValue("Regularity", task.Regularity);
                command.Parameters.AddWithValue("Id", task.Id);

                try
                {
                    connection.Open();
                    newIdNumber = Convert.ToInt32(command.ExecuteScalar());


                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }

            return newIdNumber;
        }
    }
}


