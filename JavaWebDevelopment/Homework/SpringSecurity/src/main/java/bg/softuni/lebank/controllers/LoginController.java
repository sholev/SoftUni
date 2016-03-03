package bg.softuni.lebank.controllers;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestMethod;
import org.springframework.web.bind.annotation.RequestParam;

import bg.softuni.lebank.constants.OutputMessages;

@Controller
public class LoginController {

	@RequestMapping(value = "/login", method = RequestMethod.GET)
	public String loginPage(
			Model model,
			@RequestParam(value = "error", required = false) String error) {
		String output;
		if (error != null) {
			output = OutputMessages.INVALID_LOGIN_INFO;
		} else {
			output = OutputMessages.ENTER_LOGIN_INFO;
		}
		model.addAttribute("output", output);
		return "login";
	}
}