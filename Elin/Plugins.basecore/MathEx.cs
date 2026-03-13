public static class MathEx
{
	public static int Min(long a, int b = int.MaxValue)
	{
		if (a > b)
		{
			return b;
		}
		return (int)a;
	}

	public static long Max(long a, long b)
	{
		if (a >= b)
		{
			return a;
		}
		return b;
	}
}
