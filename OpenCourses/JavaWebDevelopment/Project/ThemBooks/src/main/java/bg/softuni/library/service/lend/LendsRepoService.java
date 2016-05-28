package bg.softuni.library.service.lend;

import java.util.Map;
import java.util.Set;
import java.util.stream.Collectors;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Service;

import bg.softuni.library.dto.book.BookSearch;
import bg.softuni.library.dto.lend.LendSearch;
import bg.softuni.library.entity.book.Book;
import bg.softuni.library.entity.client.Client;
import bg.softuni.library.entity.lend.Lend;
import bg.softuni.library.interfaces.BooksService;
import bg.softuni.library.interfaces.ClientsService;
import bg.softuni.library.interfaces.LendsStorage;
import bg.softuni.library.interfaces.LendsService;

@Service
public class LendsRepoService implements LendsService {
	
	@Autowired
	private LendsStorage lendsDao;
	
	@Autowired
	private BooksService bookService;
	
	@Autowired
	private ClientsService clientService;

	public Set<Lend> getLends(LendSearch search) {
		Set<Lend> result;
		if (search.isNull()) {			
			result = lendsDao.getLends();			
		} else {
			Lend lend = new Lend();

			BookSearch bookSearch = new BookSearch();
			bookSearch.setName(search.getBookName());
			Set<Book> books = bookService.getBooks(bookSearch);
			if (!books.isEmpty() && !bookSearch.getName().isEmpty()) {
				Long bookId = books.stream().findFirst().get().getId();				
				lend.setBookId(bookId);
			}
			
			Client clientSearch = new Client();
			clientSearch.setName(search.getClientName());
			Set<Client> clients = clientService.getClients(clientSearch);
			if (!clients.isEmpty() && !clientSearch.getName().isEmpty()) {
				Long clientId = clients.stream().findFirst().get().getId();	
				lend.setClientId(clientId);
			}
			
			lend.setLendDate(search.getLendDate());
			lend.setReturnDate(search.getReturnDate());
			
			result = lendsDao.getLends(lend);
		}
		
		Map<Long, Book> books = bookService.getBooks()
				.stream().collect(Collectors.toMap(Book::getId, book -> book));
		
		Map<Long, Client> clients = clientService.getClients()
				.stream().collect(Collectors.toMap(Client::getId, client -> client));
		
		for(Lend lend : result) {
			
			lend.setBook(books.get(lend.getBookId()));
			lend.setClient(clients.get(lend.getClientId()));
		}
		
		return result;
	}

	@Override
	public boolean addLend(Lend lend) {
		return lendsDao.addLend(lend);
	}

	@Override
	public boolean editLend(Lend lend) {
		Long lendId = lend.getId();
		
		return lendsDao.editLend(lendId, lend);
	}	
}
