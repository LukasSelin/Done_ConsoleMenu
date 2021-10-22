namespace Menu_2._0
{
    public class Menu : Dictionary<string, Func<bool>> 
    {
        private readonly IPainter _painter;
        public Menu(IPainter consolePainter)
        {
            _painter = consolePainter; 
        }
        internal void MoveUp() => Index = Math.Max(Index - 1, 0);      // Rör dig ett steg uppåt om du inte är på högsta nivån
        internal void MoveDown() => Index = Math.Min(Index + 1, this.Count - 1); // Rör dig ett steg neråt om du inte är på lägsta nivån   
        private int Index = 0;
        internal int SelectedIndex()
        {
            return Index;
        }
        internal KeyValuePair<string, Func<bool>> Selected()
        {
            return this.ElementAt(Index); 
        }
        internal string SelectedTitle()
        {
            return Selected().Key;
        }
        internal Func<bool> SelctedFunction()
        {
            return Selected().Value;
        }
        public async Task<Menu> GetOptionsOnly(Menu menu)
        {
            bool done = false;
            await Task.Run(() =>
            {
                do
                {
                    Console.CursorVisible = false;
                    _painter.Paint(ref menu);
                    var keyInfo = Console.ReadKey();
                    switch (keyInfo.Key)
                    {
                        case ConsoleKey.UpArrow:
                            MoveUp();
                            break;
                        case ConsoleKey.DownArrow:
                            MoveDown();
                            break;
                        case ConsoleKey.Enter:
                            Console.Clear();
                            done = SelctedFunction().Invoke();
                            break;
                    }
                }
                while (!done);
            });
            return this;
        }
    }
}