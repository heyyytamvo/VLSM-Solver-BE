namespace VLSMsolver
{
	public class BinaryCalculator
	{
		public BinaryCalculator()
		{
		}

		public string DecimalToBinary8bit(int number)
		{
			string result = Convert.ToString(number, 2).PadLeft(8, '0');
			return result;
		}

		public int BinaryToInteger(string binaryNum)
        {
			int result = Convert.ToInt32(binaryNum, 2);
			return result;
		}
	}
}