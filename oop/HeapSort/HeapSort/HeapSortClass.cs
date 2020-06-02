namespace HeapSort
{
    internal class HeapSortClass
    {
		public static int Left(int index) => (index + 1) * 2 - 1;
		public static int Right(int index) => (index + 1) * 2;

		public static void sort(ref int[] data)
		{
			int temp;
			int heapSize = data.Length;

			for (int p = (heapSize - 1) / 2; p >= 0; --p)
				maxHeapify(ref data, heapSize, p);

			for (int i = data.Length - 1; i > 0; --i)
			{
				temp = data[i];
				data[i] = data[0];
				data[0] = temp;

				--heapSize;
				maxHeapify(ref data, heapSize, 0);
			}
		}

		private static void maxHeapify(ref int[] data, int heapSize, int index)
		{
			int left = Left(index);
			int right = Right(index);
			int largest = 0;
			int temp;

			if (left < heapSize && data[left] > data[index])
				largest = left;
			else
				largest = index;

			if (right < heapSize && data[right] > data[largest])
				largest = right;

			if (largest != index)
			{
				temp = data[index];
				data[index] = data[largest];
				data[largest] = temp;

				maxHeapify(ref data, heapSize, largest);
			}
		}
	}
}