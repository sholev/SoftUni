package bg.softuni.library.controllers.user;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;

@Controller
public class LoginController {

	@RequestMapping(value = "/login", method = RequestMethod.GET)
	public String loginPage(
			Model model,
			@RequestParam(value = "error", required = false) String error) {
		String output;
		if (error != null) {
			output = "Invalid credentials.";
		} else {
			output = "Enter credentials:";
		}
		model.addAttribute("output", output);
		
		return "login";
	}
}