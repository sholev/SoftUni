package bg.softuni.library.controller.lend;

import java.sql.Date;
import java.text.SimpleDateFormat;

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
import bg.softuni.library.dto.lend.LendSearch;
import bg.softuni.library.entity.lend.Lend;
import bg.softuni.library.interfaces.BooksService;
import bg.softuni.library.interfaces.ClientsService;
import bg.softuni.library.interfaces.LendsService;

@Controller
public class LendsController {
	
	@Autowired
	private LendsService lendsService;	
	
	@Autowired
	private BooksService booksService;	
	
	@Autowired
	private ClientsService clientsService;
	
	@RequestMapping(value = UrlConstants.LEND_REGISTRY_URL, method = RequestMethod.GET)
	public String lendsRegistry(Model model, @ModelAttribute("LendSearch") LendSearch search) {
		model.addAttribute("lends", lendsService.getLends(search));
		model.addAttribute("books", booksService.getBooks());
		model.addAttribute("clients", clientsService.getClients());

		model.addAttribute("lendRegistryUrl", UrlConstants.LEND_REGISTRY_URL);
		model.addAttribute("clientRegistryUrl", UrlConstants.CLIENT_REGISTRY_URL);
		model.addAttribute("userRegistryUrl", UrlConstants.USER_REGISTRY_URL);
		model.addAttribute("bookRegistryUrl", UrlConstants.BOOK_REGISTRY_URL);
		
		model.addAttribute("editLendUrl", UrlConstants.EDIT_LEND_URL);
		model.addAttribute("addLendUrl", UrlConstants.ADD_LEND_URL);
		
		return "lendRegistry";
	}
	
	
	@RequestMapping(value = UrlConstants.ADD_LEND_URL, method = RequestMethod.GET)
	public String addLend(Model model) {		
		model.addAttribute("books", booksService.getBooks());
		model.addAttribute("clients", clientsService.getClients());
		
		model.addAttribute("addLendUrl", UrlConstants.ADD_LEND_URL);
		
		return "addLend";
	}
	
	@RequestMapping(value = UrlConstants.ADD_LEND_URL, method = RequestMethod.POST)
	public String addLend(Model model, @ModelAttribute("Lend") Lend lend) {
		
		model.addAttribute("addLendUrl", UrlConstants.ADD_LEND_URL);

		this.lendsService.addLend(lend);
		
		return this.lendsRegistry(model, new LendSearch());
	}
	
	@RequestMapping(value = UrlConstants.EDIT_LEND_URL, method = RequestMethod.GET)
	public String editLendGet(Model model, @ModelAttribute("Lend") Lend lend) {
		model.addAttribute("books", booksService.getBooks());
		model.addAttribute("clients", clientsService.getClients());
		
		model.addAttribute("editLendUrl", UrlConstants.EDIT_LEND_URL);
		model.addAttribute("lend", lend);
		
		return "editLend";
	}
	
	@RequestMapping(value = UrlConstants.EDIT_LEND_URL, method = RequestMethod.POST)
	public String editLendPost(Model model, @ModelAttribute("Lend") Lend lend) {
		model.addAttribute("editLendUrl", UrlConstants.EDIT_LEND_URL);

		this.lendsService.editLend(lend);
		
		return this.lendsRegistry(model, new LendSearch());
	}
	
	@InitBinder
	public void initBinder(WebDataBinder binder) {
	    SimpleDateFormat simpleDateFormat = new SimpleDateFormat("dd-MM-yyyy");
	    simpleDateFormat.setLenient(true);
	    binder.registerCustomEditor(Date.class, new CustomDateEditor(simpleDateFormat, true));
	}
}
