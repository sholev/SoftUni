package bg.softuni.library.services.book;

import java.util.Set;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import bg.softuni.library.dto.book.BookSearch;
import bg.softuni.library.entities.book.Book;
import bg.softuni.library.interfaces.BooksStorage;
import bg.softuni.library.interfaces.BooksService;

@Service
public class BooksRepositoryService implements BooksService {

	@Autowired
	private BooksStorage booksDao;

	@Override
	public Set<Book> getBooks(BookSearch search) {
		Set<Book> result = this.booksDao.getBooks(search);
		
		return result;
	}

	@Override
	public boolean addBook(Book book) {
		return booksDao.addBook(book);
	}

	@Override
	public boolean deleteBook(Book book) {
		return booksDao.deleteBook(book);
	}

	@Override
	public boolean editBook(Book book) {
		Long bookId = book.getId();
		
		return booksDao.editBook(bookId, book);
	}	
}
