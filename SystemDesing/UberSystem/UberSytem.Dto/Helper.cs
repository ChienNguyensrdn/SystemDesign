namespace UberSytem.Dto
{
    public class Helper
    {
        public static long GenerateRandomLong()
        {
            // Create an instance of Random
            Random random = new Random();

            // Use two int values to construct a long value
            byte[] buffer = new byte[8];
            random.NextBytes(buffer);

            // Convert the byte array to a long
            long randomLong = BitConverter.ToInt64(buffer, 0);

            return randomLong;
        }
    }
}
