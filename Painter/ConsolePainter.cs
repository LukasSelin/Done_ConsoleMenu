
namespace Menu_2._0
{
    public class ConsolePainter : IPainter
    {
        public ConsolePainter(ConsoleColor selectedColor = ConsoleColor.Yellow) => this.selectedColor = selectedColor;
        private Menu menu;
        private readonly ConsoleColor selectedColor;
        private int ItemCursorIndex { get; set; } = 0;
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
            Console.CursorVisible = false;
            this.menu = menu;

            if(IsFirstRun)
            {
                ItemIndex = 0;

                foreach (var item in menu.Keys)
                {
                    PrintItem(item, false);
                    ItemIndex++;
                }
                PrintItem(menu.Keys.ElementAt(0), true);

                IsFirstRun = false;
            }
            else
            {
                PrintItem(menu.Keys.ElementAt(ItemIndex), false);
                ItemIndex = menu.SelectedIndex();
                PrintItem(menu.Keys.ElementAt(ItemIndex), true);
            }
        }
        internal void PrintItem(string item, bool isSelected)
        {
            var arrowColor = isSelected ? selectedColor : Console.BackgroundColor;
            var itemColor = isSelected ? selectedColor : ConsoleColor.Gray;
            PrintItemArrow(arrowColor);
            PrintItemContent(item, itemColor);
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

        public void Reset()
        {
            Console.Clear();
            IsFirstRun = true;
        }
    }
}