# ConsoleMenu

## Usage

```c#
var consolePainter = new ConsolePainter();
var menu = new Menu(consolePainter);
menu.Add("Test", () => Task.Run(() => { return true; }));
menu.Add("Test_2", () => Task.Run(async () => {
    menu.Add("Test_4", () => Task.Run( () => { return true; }));
    await menu.RepaintMenu(menu);
    return false; }));
menu.Add("Test_3", () => Task.Run(() => { return true; }));

menu = await menu.GetOptionsOnly(menu);

```
