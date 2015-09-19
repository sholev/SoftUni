using System;

/* Можеше просто да ги принтирам, но опитах да го
 * направя да прави равнобедрен триъгълник в зависимост
 * от броя на редовете, които се въвеждат.
 */

class PrintIsoscelesTriangle
{
    static void Main()
    {
        char triangleSymbol = '\u00A9';     // Copyright символа.
        char emptySpace = ' ';              // Останалото място.
        int rows = 4;                       // Брой редове, 4 = 9 символа.
        

        int count = rows;   // Брояч, който ще използваме в циклите.

        while (count > 1) // За всеки ред по един цикъл. Не е 0 защото пропускаме последния ред.
        {
            for (int i = count; i > 1; i--) // Празно място преди triangleSymbol.
            {
                Console.Write(emptySpace);
            }

            Console.Write(triangleSymbol);

            if (count < rows) // Пропускаме една итерация, когато count==rows,
            {                 // защото в началото ни трябва само един triangleSymbol.

                for (int i = count; i < rows; i++) // Празно място между triangleSymbol
                {                                  // на следващите редове.
                    Console.Write(emptySpace);
                }

                for (int i = count + 1; i < rows; i++)
                {
                    Console.Write(emptySpace);
                }

                Console.Write(triangleSymbol);  // Всеки втори triangleSymbol
            }                                   // след празното място.

            for (int i = count; i > 1; i--)     // Празното място след triangleSymbol
            {                                   // което може и да се пропусне, ако
                Console.Write(emptySpace);      // ни интересува само триъгълника.
            }

            count--;                            // Намаляме броя редове, които остават
            Console.Write('\n');                // и продължаваме на нов ред.
        }

        for (int i = 1; i < rows; i++)          // Довършваме си последния ред,
        {                                       // който пропуснахме, без последния
            Console.Write(triangleSymbol);      // символ.
            Console.Write(emptySpace);
        }

        Console.WriteLine(triangleSymbol);      // Добавяме и последния символ.
    }
}
