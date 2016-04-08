package bg.softuni.library.controllers.user;

import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.ModelAttribute;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;

import bg.softuni.library.constants.UrlConstants;
import bg.softuni.library.dto.user.UserSearch;
import bg.softuni.library.entities.user.User;
import bg.softuni.library.services.user.UsersRepositoryService;
import bg.softuni.library.utils.user.UserUtils;

@Controller
public class UsersController {

	@Autowired
	private UsersRepositoryService userService;

	@RequestMapping(value = UrlConstants.USER_REGISTRY_URL, method = RequestMethod.GET)
	public String getUsers(Model model, @ModelAttribute("UserSearch") UserSearch userSearch) {
		model.addAttribute("users", userService.getUsers(userSearch));
		model.addAttribute("userRegistryUrl", UrlConstants.USER_REGISTRY_URL);
		model.addAttribute("addUserUrl", UrlConstants.ADD_USER_URL);
		model.addAttribute("deactivateUserUrl", UrlConstants.DEACTIVATE_USER_URL);
		model.addAttribute("bookRegistryUrl", UrlConstants.BOOK_REGISTRY_URL);
		model.addAttribute("user", UserUtils.getUser());

		return "userRegistry";
	}
	
	@RequestMapping(value = UrlConstants.ADD_USER_URL, method = RequestMethod.GET)
	public String addUser(Model model) {
		model.addAttribute("addUserUrl", UrlConstants.ADD_USER_URL);
		
		return "addUser";
	}
	
	@RequestMapping(value = UrlConstants.ADD_USER_URL, method = RequestMethod.POST)
	public String addUser(Model model, @ModelAttribute("User") User user) {
		model.addAttribute("addUserUrl", UrlConstants.ADD_USER_URL);
		
		userService.addUser(user);
		
		return getUsers(model, new UserSearch());
	}
	
	@RequestMapping(value = UrlConstants.DEACTIVATE_USER_URL, method = RequestMethod.GET)
	public String deactivateUser(Model model) {
		model.addAttribute("deactivateUserUrl", UrlConstants.DEACTIVATE_USER_URL);
		
		return "deactivateUser";
	}
	
	@RequestMapping(value = UrlConstants.DEACTIVATE_USER_URL, method = RequestMethod.POST)
	public String deactivateUser(Model model, @ModelAttribute("User") User user) {
		model.addAttribute("deactivateUserUrl", UrlConstants.DEACTIVATE_USER_URL);
		
		userService.deactivateUser(user);
		
		return getUsers(model, new UserSearch());
	}
}
