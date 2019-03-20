namespace OOP.Task2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            var worker = new FileWorker(@"D:\MySystem\Downloads\shpora_ml");
            worker.isRecursive = true;
            worker.Execute(new Md5Executor());
        }
    }
}