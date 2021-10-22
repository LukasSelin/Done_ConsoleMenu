
namespace Menu_2._0
{
    public class ConsolePainter : IPainter
    {
        public ConsolePainter(ConsoleColor selectedColor = ConsoleColor.Yellow) => this.selectedColor = selectedColor;
        private Menu menu;
        private readonly ConsoleColor selectedColor;
        private int ItemCursorIndex { get; set; } = 2;
        private bool IsFirstRun { get; set; } = true;
        private int _ItemIndex { get;set; }
        private int ItemIndex
        {
            get { return _ItemIndex; }
            set
            {
                if (value < menu.Count)
                {
                    _ItemIndex = value;
                }
                else
                {
                    _ItemIndex = 0;
                }
            }
        }
        public void Paint(ref Menu menu)
        {
            this.menu = menu;

            if(IsFirstRun)
            {
                ItemIndex = 0;

                foreach (var item in menu.Keys)
                {
                    PrintItem(item, ConsoleColor.Gray);
                    ItemIndex++;
                }
                IsFirstRun = false;
            }
            else
            {
                PrintItem(menu.SelectedTitle(), ConsoleColor.Gray);
                ItemIndex = menu.SelectedIndex();
                PrintItem(menu.SelectedTitle(), selectedColor);
            }
        }
        internal void PrintItem(string item, ConsoleColor consoleColor)
        {
            PrintItemArrow(ConsoleColor.Black);
            PrintItemContent(item, consoleColor);
        }
        internal void PrintItemArrow(ConsoleColor color)
        {
            Console.SetCursorPosition(0, ItemCursorIndex + ItemIndex);
            Console.ForegroundColor = color;
            Console.Write("->");
            Console.ResetColor();
        }
        internal void PrintItemContent(string item, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.SetCursorPosition(2, ItemCursorIndex + ItemIndex);
            Console.Write(item);
            Console.ResetColor();
        }
    }
}