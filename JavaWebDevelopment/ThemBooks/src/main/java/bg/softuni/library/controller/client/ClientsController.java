package bg.softuni.library.controller.client;

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
import bg.softuni.library.entity.client.Client;
import bg.softuni.library.interfaces.ClientsService;
import bg.softuni.library.util.SecurityUtil;

@Controller
public class ClientsController {
	
	@Autowired
	private ClientsService clientService;
	
	@RequestMapping(value = UrlConstants.CLIENT_REGISTRY_URL, method = RequestMethod.GET)
	public String clientsRegistry(Model model, @ModelAttribute("Client") Client client) {
		model.addAttribute("clients", clientService.getClients(client));

		model.addAttribute("userRegistryUrl", UrlConstants.USER_REGISTRY_URL);
		model.addAttribute("bookRegistryUrl", UrlConstants.BOOK_REGISTRY_URL);
		model.addAttribute("clientRegistryUrl", UrlConstants.CLIENT_REGISTRY_URL);
		model.addAttribute("lendRegistryUrl", UrlConstants.LEND_REGISTRY_URL);
		
		model.addAttribute("editClientUrl", UrlConstants.EDIT_CLIENT_URL);
		model.addAttribute("deleteClientUrl", UrlConstants.DELETE_CLIENT_URL);
		model.addAttribute("addClientUrl", UrlConstants.ADD_CLIENT_URL);
		
		return "clientRegistry";
	}
		
	@RequestMapping(value = UrlConstants.ADD_CLIENT_URL, method = RequestMethod.GET)
	public String addClient(Model model) {
		model.addAttribute("addClientUrl", UrlConstants.ADD_CLIENT_URL);
		
		return "addClient";
	}
	
	@RequestMapping(value = UrlConstants.ADD_CLIENT_URL, method = RequestMethod.POST)
	public String addClient(Model model, @ModelAttribute("Client") Client client) {
		model.addAttribute("addClientUrl", UrlConstants.ADD_CLIENT_URL);

		this.clientService.addClient(client);
		
		return this.clientsRegistry(model, new Client());
	}
	
	@RequestMapping(value = UrlConstants.EDIT_CLIENT_URL, method = RequestMethod.GET)
	public String editClientGet(Model model, @ModelAttribute("Client") Client client) {
		model.addAttribute("editClientUrl", UrlConstants.EDIT_CLIENT_URL);
		model.addAttribute("client", client);
		
		return "editClient";
	}
	
	@RequestMapping(value = UrlConstants.EDIT_CLIENT_URL, method = RequestMethod.POST)
	public String editClientPost(Model model, @ModelAttribute("Client") Client client) {
		model.addAttribute("editClientUrl", UrlConstants.EDIT_CLIENT_URL);

		this.clientService.editClient(client);
		
		return this.clientsRegistry(model, new Client());
	}
	
	@RequestMapping(value = UrlConstants.DELETE_CLIENT_URL, method = RequestMethod.GET)
	public String deleteClient(Model model, @ModelAttribute("Client") Client client) {

		this.clientService.deleteClient(client);
		
		return this.clientsRegistry(model, new Client());
	}
	
	@InitBinder
	public void initBinder(WebDataBinder binder) {
	    SimpleDateFormat simpleDateFormat = new SimpleDateFormat("dd-MM-yyyy");
	    simpleDateFormat.setLenient(true);
	    binder.registerCustomEditor(Date.class, new CustomDateEditor(simpleDateFormat, true));
	}
}
