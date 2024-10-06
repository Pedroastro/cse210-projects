using System;
using System.Globalization;
using System.Text.Json;


class Program
{
    static void Main(string[] args)
    {
        string filePath = "C:/Users/Pedro Castro/Desktop/BYU/CSE 210/cse210-projects/prove/Develop03/t_kjv.json";

        string jsonContent = File.ReadAllText(filePath);

        List<Field> fields = JsonSerializer.Deserialize<List<Field>>(jsonContent);
        
        Dictionary<int, string> bibleBooks = new Dictionary<int, string>()
        {
            { 1, "Genesis" },
            { 2, "Exodus" },
            { 3, "Leviticus" },
            { 4, "Numbers" },
            { 5, "Deuteronomy" },
            { 6, "Joshua" },
            { 7, "Judges" },
            { 8, "Ruth" },
            { 9, "1 Samuel" },
            { 10, "2 Samuel" },
            { 11, "1 Kings" },
            { 12, "2 Kings" },
            { 13, "1 Chronicles" },
            { 14, "2 Chronicles" },
            { 15, "Ezra" },
            { 16, "Nehemiah" },
            { 17, "Esther" },
            { 18, "Job" },
            { 19, "Psalms" },
            { 20, "Proverbs" },
            { 21, "Ecclesiastes" },
            { 22, "Song of Solomon" },
            { 23, "Isaiah" },
            { 24, "Jeremiah" },
            { 25, "Lamentations" },
            { 26, "Ezekiel" },
            { 27, "Daniel" },
            { 28, "Hosea" },
            { 29, "Joel" },
            { 30, "Amos" },
            { 31, "Obadiah" },
            { 32, "Jonah" },
            { 33, "Micah" },
            { 34, "Nahum" },
            { 35, "Habakkuk" },
            { 36, "Zephaniah" },
            { 37, "Haggai" },
            { 38, "Zechariah" },
            { 39, "Malachi" },
            { 40, "Matthew" },
            { 41, "Mark" },
            { 42, "Luke" },
            { 43, "John" },
            { 44, "Acts" },
            { 45, "Romans" },
            { 46, "1 Corinthians" },
            { 47, "2 Corinthians" },
            { 48, "Galatians" },
            { 49, "Ephesians" },
            { 50, "Philippians" },
            { 51, "Colossians" },
            { 52, "1 Thessalonians" },
            { 53, "2 Thessalonians" },
            { 54, "1 Timothy" },
            { 55, "2 Timothy" },
            { 56, "Titus" },
            { 57, "Philemon" },
            { 58, "Hebrews" },
            { 59, "James" },
            { 60, "1 Peter" },
            { 61, "2 Peter" },
            { 62, "1 John" },
            { 63, "2 John" },
            { 64, "3 John" },
            { 65, "Jude" },
            { 66, "Revelation" }
        };

        string userBook = "";
        int userBookKey = 0;
        bool bookMatch = false;
        while (!bookMatch)
        {
            Console.WriteLine("Please write the book of the scripture that you would like to memorize:");
            userBook += Console.ReadLine().ToLower();
            foreach (string bibleBook in bibleBooks.Values)
            {
                userBookKey ++;
                if (userBook == bibleBook.ToLower())
                {
                    bookMatch = true;
                    break;
                }
            }
            if (!bookMatch)
            {
                Console.WriteLine("Invalid Book Name.");
                userBookKey = 0;
                userBook = "";
            }
        }

        int userChapter = 0;
        bool chapterMatch = false;
        while (!chapterMatch)
        {
            userChapter = 0;
            Console.WriteLine("Please write the chapter book of the scripture that you would like to memorize:");
            string userChapterInput = Console.ReadLine();
            if (!int.TryParse(userChapterInput, out userChapter))
            {
                Console.WriteLine("Chapter invalid.");
                chapterMatch = false;
            }
            else
            {
                userChapter = int.Parse(userChapterInput);
                foreach (Field f in fields)
                {
                    string bookString = $"{f.field[1]}";
                    string chapterString = $"{f.field[2]}";
                    int bookCursor = int.Parse(bookString);
                    int chapterCursor = int.Parse(chapterString);
                    if (bookCursor == userBookKey)
                    {
                        if (chapterCursor == userChapter)
                        {
                            chapterMatch = true;
                            break;
                        }
                    }
                }
            }
        }

        int userVerse = 0;
        bool verseMatch = false;
        string scriptureText = "";
        while (!verseMatch)
        {
            userVerse = 0;
            Console.WriteLine("Please write the verse book of the scripture that you would like to memorize:");
            string userVerseInput = Console.ReadLine();
            if (!int.TryParse(userVerseInput, out userVerse))
            {
                Console.WriteLine("Verse invalid.");
                verseMatch = false;
            }
            else
            {
                userVerse = int.Parse(userVerseInput);
                foreach (Field f in fields)
                {
                    string bookString = $"{f.field[1]}";
                    string chapterString = $"{f.field[2]}";
                    string verseString = $"{f.field[3]}";
                    int bookCursor = int.Parse(bookString);
                    int chapterCursor = int.Parse(chapterString);
                    int verseCursor = int.Parse(verseString);
                    if (bookCursor == userBookKey)
                    {
                        if (chapterCursor == userChapter)
                        {
                            if (verseCursor == userVerse)
                            {
                                verseMatch = true;
                                scriptureText = $"{f.field[4]}";
                                break;
                            }
                        }
                    }
                }
            }
        }

        int userEndVerse = 0;
        bool endVerseMatch = false;
        while (!endVerseMatch)
        {
            userEndVerse = 0;
            Console.WriteLine("Please write the verse book of the scripture that you would like to memorize or type no:");
            string userEndVerseInput = Console.ReadLine();
            if (userEndVerseInput.ToLower() == "no")
            {
                break;
            }
            else if (!int.TryParse(userEndVerseInput, out userEndVerse))
            {
                Console.WriteLine("Verse invalid.");
                endVerseMatch = false;
            }
            else if (int.Parse(userEndVerseInput) < userVerse)
            {
                Console.WriteLine("End verse smaller than start verse.");
                endVerseMatch = false;
            }
            else
            {
                userEndVerse = int.Parse(userEndVerseInput);
                foreach (Field f in fields)
                {
                    string bookString = $"{f.field[1]}";
                    string chapterString = $"{f.field[2]}";
                    string verseString = $"{f.field[3]}";
                    int bookCursor = int.Parse(bookString);
                    int chapterCursor = int.Parse(chapterString);
                    int verseCursor = int.Parse(verseString);
                    if (bookCursor == userBookKey)
                    {
                        if (chapterCursor == userChapter)
                        {
                            if (verseCursor > userVerse)
                            {
                                scriptureText += $" {f.field[4]}";
                                if (verseCursor == userEndVerse)
                                {
                                    endVerseMatch = true;
                                    break;
                                }
                            }
                        }
                    }
                }
            }
        }

        TextInfo textInfo = CultureInfo.CurrentCulture.TextInfo;
        Reference reference = new Reference(textInfo.ToTitleCase(userBook), userChapter, userVerse, userEndVerse);
        Scripture scripture = new Scripture(reference, scriptureText);
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            if (scripture.IsCompletelyHidden())
            {
                break;
            }
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            string userInput = Console.ReadLine();
            if (userInput == "quit")
            {
                break;
            }
            else
            {
                scripture.HideRandomWords(3);
            }
        }
    }
}