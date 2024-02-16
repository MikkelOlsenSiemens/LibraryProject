namespace LibraryProject
{
    public class Book
    {
        public Book(string title, string author, int publicationYear, string isbn, IValidationService validationService)
        {
            var isValid = validationService.IsValidBookPubYear(publicationYear);
            if (!isValid ) { throw new ArgumentException(); }
            Title = title;
            Author = author;
            PublicationYear = publicationYear;
            ISBN = isbn;
        }

        public Book()
        {
            
        }

        public string Title { get; set; }
        public string Author { get; set; }
        public int PublicationYear { get; set; }
        public string ISBN { get; set; }

        public string DisplayBookInfo()
        {
            return $"Title: {Title}, Author: {Author}, Publication Year: {PublicationYear}, ISBN: {ISBN}";
        }
    }
}
