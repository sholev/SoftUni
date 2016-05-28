package bg.softuni.library.interfaces;

import java.util.Set;

import bg.softuni.library.dto.book.BookSearch;
import bg.softuni.library.entity.book.Book;

public interface BooksStorage {
	
	Set<Book> getBooks();
	
	Set<Book> getBooks(BookSearch search);

	boolean addBook(Book book);

	boolean deleteBook(Book book);

	boolean editBook(Long bookId, Book updatedBook);
}
