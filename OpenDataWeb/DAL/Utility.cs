namespace OpenDataWeb.DAL
{
    public class Utility
    {
        public static string ConnectionString { get => @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=BusStations;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"; }
        public static int GetAsInt(object value)
        {
            int x = 0;

            try
            {
                x = (int)value;
            }
            catch { }

            return x;
        }


        public static string GetAsString(object value)
        {
            string x = "";

            try
            {
                x = $"{value}";
            }
            catch { }

            return x;
        }

        public static double GetAsDouble(object value)
        {
            double x = 0;

            try
            {
                x = (double)value;
            }
            catch { }

            return x;
        }

    }
}