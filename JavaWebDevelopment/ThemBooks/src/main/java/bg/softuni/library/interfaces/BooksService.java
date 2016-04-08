package bg.softuni.library.interfaces;

import java.util.Set;

import bg.softuni.library.dto.book.BookSearch;
import bg.softuni.library.entities.book.Book;

public interface BooksService {

	Set<Book> getBooks(BookSearch book);

	boolean addBook(Book book);

	boolean deleteBook(Book book);

	boolean editBook(Book book);

}