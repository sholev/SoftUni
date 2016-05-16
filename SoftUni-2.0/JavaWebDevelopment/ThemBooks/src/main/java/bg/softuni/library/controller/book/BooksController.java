package bg.softuni.library.controller.book;

import java.text.SimpleDateFormat;
import java.sql.Date;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.beans.propertyeditors.CustomDateEditor;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.WebDataBinder;
import org.springframework.web.bind.annotation.InitBinder;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

import bg.softuni.library.constants.UrlConstants;
import bg.softuni.library.dto.book.BookSearch;
import bg.softuni.library.entity.book.Book;
import bg.softuni.library.interfaces.BooksService;


@Controller
public class BooksController {
	
	@Autowired
	private BooksService bookService;
	
	@RequestMapping(value = {"/", UrlConstants.BOOK_REGISTRY_URL}, method = RequestMethod.GET)
	public String booksRegistry(Model model, @ModelAttribute("Book") BookSearch book) {
		model.addAttribute("books", bookService.getBooks(book));

		model.addAttribute("userRegistryUrl", UrlConstants.USER_REGISTRY_URL);
		model.addAttribute("bookRegistryUrl", UrlConstants.BOOK_REGISTRY_URL);
		model.addAttribute("clientRegistryUrl", UrlConstants.CLIENT_REGISTRY_URL);
		model.addAttribute("lendRegistryUrl", UrlConstants.LEND_REGISTRY_URL);
		
		model.addAttribute("editBookUrl", UrlConstants.EDIT_BOOK_URL);
		model.addAttribute("deleteBookUrl", UrlConstants.DELETE_BOOK_URL);
		model.addAttribute("addBookUrl", UrlConstants.ADD_BOOK_URL);
		
		return "bookRegistry";
	}
	
	@RequestMapping(value = UrlConstants.ADD_BOOK_URL, method = RequestMethod.GET)
	public String addBook(Model model) {
		model.addAttribute("addBookUrl", UrlConstants.ADD_BOOK_URL);
		
		return "addBook";
	}
	
	@RequestMapping(value = UrlConstants.ADD_BOOK_URL, method = RequestMethod.POST)
	public String addBook(Model model, @ModelAttribute("Book") Book book) {
		model.addAttribute("addBookUrl", UrlConstants.ADD_BOOK_URL);

		this.bookService.addBook(book);
		
		return this.booksRegistry(model, new BookSearch());
	}
	
	@RequestMapping(value = UrlConstants.EDIT_BOOK_URL, method = RequestMethod.GET)
	public String editBookGet(Model model, @ModelAttribute("Book") Book book) {
		model.addAttribute("editBookUrl", UrlConstants.EDIT_BOOK_URL);
		model.addAttribute("book", book);
		
		return "editBook";
	}
	
	@RequestMapping(value = UrlConstants.EDIT_BOOK_URL, method = RequestMethod.POST)
	public String editBookPost(Model model, @ModelAttribute("Book") Book book) {
		model.addAttribute("editBookUrl", UrlConstants.EDIT_BOOK_URL);

		this.bookService.editBook(book);
		
		return this.booksRegistry(model, new BookSearch());
	}
	
	@RequestMapping(value = UrlConstants.DELETE_BOOK_URL, method = RequestMethod.GET)
	public String deleteBook(Model model, @ModelAttribute("Book") Book book) {

		this.bookService.deleteBook(book);
		
		return this.booksRegistry(model, new BookSearch());
	}
	
	@InitBinder
	public void initBinder(WebDataBinder binder) {
	    SimpleDateFormat simpleDateFormat = new SimpleDateFormat("dd-MM-yyyy");
	    simpleDateFormat.setLenient(true);
	    binder.registerCustomEditor(Date.class, new CustomDateEditor(simpleDateFormat, true));
	}
}
